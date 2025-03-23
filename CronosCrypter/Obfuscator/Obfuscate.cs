using CronosCrypter.Obfuscator.Class;
using CronosCrypter.Obfuscator.String;
using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronosCrypter.Obfuscator
{
    internal class Obfuscate
    {
        public void Execute(ModuleDefMD module)
        {
            StringSplitter.Execute(module);
            ClassRandomization.Execute(module);
            ClassIncreaser.Execute(module);
            MetadataObfuscation.Execute(module);
            StringEncryption.Execute(module);
            AntiDebugging.Execute(module);
            CodeVirtualization.Execute(module);
        }
    }

    internal class MetadataObfuscation
    {
        public static void Execute(ModuleDefMD module)
        {
            foreach (var type in module.GetTypes())
            {
                type.Name = Randomize.RandomString(10);
                foreach (var method in type.Methods)
                {
                    method.Name = Randomize.RandomString(10);
                }
                foreach (var field in type.Fields)
                {
                    field.Name = Randomize.RandomString(10);
                }
            }
        }
    }

    internal class StringEncryption
    {
        public static void Execute(ModuleDefMD module)
        {
            foreach (var type in module.GetTypes())
            {
                foreach (var method in type.Methods)
                {
                    if (!method.HasBody) continue;

                    var body = method.Body;
                    for (int i = 0; i < body.Instructions.Count; i++)
                    {
                        var instr = body.Instructions[i];
                        if (instr.OpCode == OpCodes.Ldstr)
                        {
                            string originalString = (string)instr.Operand;
                            string encryptedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(originalString));
                            instr.Operand = encryptedString;

                            body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Call, module.Import(typeof(Encoding).GetMethod("get_UTF8"))));
                            body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Call, module.Import(typeof(Convert).GetMethod("FromBase64String", new Type[] { typeof(string) }))));
                            body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Callvirt, module.Import(typeof(Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) }))));
                        }
                    }
                }
            }
        }
    }

    internal class AntiDebugging
    {
        public static void Execute(ModuleDefMD module)
        {
            foreach (var type in module.GetTypes())
            {
                foreach (var method in type.Methods)
                {
                    if (!method.HasBody) continue;

                    var body = method.Body;
                    var instructions = body.Instructions;

                    var antiDebugInstructions = new List<Instruction>
                    {
                        Instruction.Create(OpCodes.Call, module.Import(typeof(System.Diagnostics.Debugger).GetMethod("get_IsAttached"))),
                        Instruction.Create(OpCodes.Brfalse_S, instructions[0]),
                        Instruction.Create(OpCodes.Call, module.Import(typeof(System.Environment).GetMethod("Exit", new Type[] { typeof(int) }))),
                        Instruction.Create(OpCodes.Ldc_I4_1),
                        Instruction.Create(OpCodes.Ret)
                    };

                    instructions.InsertRange(0, antiDebugInstructions);
                }
            }
        }
    }

    internal class CodeVirtualization
    {
        public static void Execute(ModuleDefMD module)
        {
            foreach (var type in module.GetTypes())
            {
                foreach (var method in type.Methods)
                {
                    if (!method.HasBody) continue;

                    var body = method.Body;
                    var instructions = body.Instructions;

                    var virtualMachineInstructions = new List<Instruction>
                    {
                        Instruction.Create(OpCodes.Ldstr, "VirtualMachineStart"),
                        Instruction.Create(OpCodes.Call, module.Import(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }))),
                        Instruction.Create(OpCodes.Ret)
                    };

                    instructions.InsertRange(0, virtualMachineInstructions);
                }
            }
        }
    }
}
