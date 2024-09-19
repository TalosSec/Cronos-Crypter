using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;

namespace CronosCrypter.Obfuscator.String
{
    class StringSplitter
    {
        public static void Execute(ModuleDef module)
        {
            /// <summary>
            /// Simple string splitter, thanks to concatenation, strings can still be used even if they are splitted.
            /// 
            /// This function splits them into groups of 3 chars, here is an example:
            /// "abc" + "def" + "ghi"
            /// </summary>

            foreach (TypeDef type in module.Types)
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody)
                        continue;

                    var body = method.Body;
                    for (int i = 0; i < body.Instructions.Count; i++)
                    {
                        var instr = body.Instructions[i];

                        // Check if instruction is a load string (ldstr) instruction
                        if (instr.OpCode == OpCodes.Ldstr)
                        {
                            string originalString = (string)instr.Operand;

                            // Split the string into multiple parts
                            string newString = SplitString(originalString);

                            // Create the new instructions for the concatenated string
                            var instructions = CreateConcatenatedStringInstructions(newString, module);

                            // Remove the original ldstr instruction
                            body.Instructions.RemoveAt(i);

                            // Insert each new instruction manually
                            for (int j = 0; j < instructions.Count; j++)
                            {
                                body.Instructions.Insert(i + j, instructions[j]);
                            }

                            // Adjust index since we inserted multiple instructions
                            i += instructions.Count - 1;
                        }
                    }
                }
            }
        }

        // Function splits string
        static string SplitString(string str)
        {
            // Example: split the string into groups of 3 characters
            int splitSize = 3;
            string result = "";

            for (int i = 0; i < str.Length; i += splitSize)
            {
                if (i + splitSize <= str.Length)
                    result += str.Substring(i, splitSize) + "\" + \"";
                else
                    result += str.Substring(i);
            }

            return result.TrimEnd("\" + \"".ToCharArray()); // Remove trailing concatenation
        }

        // Function creates instructions to concatenate strings
        static List<Instruction> CreateConcatenatedStringInstructions(string concatenatedString, ModuleDef module)
        {
            string[] parts = concatenatedString.Split(new string[] { "\" + \"" }, StringSplitOptions.None);
            var instructions = new List<Instruction>();

            // Load the first part
            instructions.Add(Instruction.Create(OpCodes.Ldstr, parts[0]));

            // For each additional part, load the string and concatenate
            for (int i = 1; i < parts.Length; i++)
            {
                // Load the next part
                instructions.Add(Instruction.Create(OpCodes.Ldstr, parts[i]));
                // Add string concatenation (OpCodes.Call to System.String.Concat)
                instructions.Add(Instruction.Create(OpCodes.Call,
                    module.Import(typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string) }))));
            }

            return instructions;
        }
    }
}
