using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronosCrypter.Obfuscator.Class
{
    class ClassIncreaser
    {
        public static void Execute(ModuleDef module)
        {
            /// <summary>
            /// Very simple obfuscator that increases the number of classes with Console.WriteLine() in method.
            /// Maybe in the future it will have calculations in the method
            /// </summary>


            for (int i = 0; i < 50; i++)
            {
                CilBody body;

                var junkAttribute = new TypeDefUser("Cronos-Crypter" + Randomize.RandomCharacters(15));

                var bctor = new MethodDefUser(".ctor", MethodSig.CreateInstance(module.CorLibTypes.Void),
                            MethodImplAttributes.IL | MethodImplAttributes.Managed,
                            MethodAttributes.Public |
                            MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

                var systemConsole = module.CorLibTypes.GetTypeRef("System", "Console");

                var writeLine = new MemberRefUser(module, "WriteLine",
                    MethodSig.CreateStatic(module.CorLibTypes.Void, module.CorLibTypes.String, module.CorLibTypes.Object), systemConsole);

                var field1 = new FieldDefUser("Cronos-Crypter" + Randomize.RandomCharacters(20), new FieldSig(module.CorLibTypes.Int32), FieldAttributes.Public | FieldAttributes.Static);
                var methImplFlags = MethodImplAttributes.IL | MethodImplAttributes.Managed;
                var methFlags = MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.ReuseSlot;
                var method1 = new MethodDefUser("Cronos-Crypter" + Randomize.RandomCharacters(20),
                            MethodSig.CreateStatic(module.CorLibTypes.Int32, module.CorLibTypes.Int32, module.CorLibTypes.Int32),
                            methImplFlags, methFlags);

                bctor.Body = body = new CilBody();

                module.Types.Add(junkAttribute);
                junkAttribute.Methods.Add(bctor);
                junkAttribute.Methods.Add(method1);
                junkAttribute.Fields.Add(field1);

                method1.Body = body;
                method1.ParamDefs.Add(new ParamDefUser("Cronos-Crypter" + Randomize.RandomCharacters(20)));
                body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
                body.Instructions.Add(OpCodes.Call.ToInstruction(bctor));
                body.Instructions.Add(OpCodes.Ldstr.ToInstruction("Cronos-Crypter" + Randomize.RandomCharacters(20)));
                body.Instructions.Add(OpCodes.Ldsfld.ToInstruction(field1));
                body.Instructions.Add(OpCodes.Ldnull.ToInstruction());
                body.Instructions.Add(OpCodes.Call.ToInstruction(writeLine));
                body.Instructions.Add(OpCodes.Ret.ToInstruction());

            }
        }
    }
}
