using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronosCrypter.Obfuscator.Class
{
    class ClassRandomization
    {
        public static void Execute(ModuleDef module)
        {

            /// <summary>
            /// Very simple class randomization obfuscator, based on dnlib
            /// </summary>

            #region Randomizing names

            /// <summary>
            /// Changes names of classes and other names
            /// </summary>

            module.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15);
            module.EntryPoint.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15);
            module.EncBaseId = Guid.NewGuid();
            module.EncId = Guid.NewGuid();
            module.Mvid = Guid.NewGuid();

            #endregion

            #region Namespace obfuscation

            /// <summary>
            /// Changes name of namespace
            /// </summary>
             
            foreach (var type in module.GetTypes())
            {
                type.Namespace = string.Empty; // Hides namespace of project
                type.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15); // Randomizes name of classes
            }

            #endregion

            foreach(TypeDef type in module.Types)
            {
                #region Project name obfuscation

                /// <summary>
                /// Changes name of project
                /// </summary>

                foreach (MethodDef paramMethod in type.Methods)
                {
                    foreach (ParamDef param in paramMethod.ParamDefs)
                    {
                        param.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15); // Randomizes Name of project
                    }
                }

                #endregion

                #region Event obfuscation
                /// <summary>
                /// Changes name of events
                /// </summary>

                foreach (EventDef @event in type.Events)
                {
                    @event.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15);
                }

                #endregion

                #region Method names obfuscation

                /// <summary>
                /// Changes names of methods
                /// </summary>

                foreach (FieldDef field in type.Fields)
                {
                    field.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15);
                }

                #endregion

                #region Variable names obfuscation 

                /// <summary>
                /// Changes names of variables
                /// </summary>

                foreach (MethodDef method in type.Methods)
                {
                    // Empty method checker - if isn't empty: obfuscate it
                    if (!method.HasBody) continue;

                    if (method.IsConstructor) continue;
                    method.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15);
                }


                #region String obfuscation
                /// <summary>
                /// Adds Convert.ToBase64Encode() in front of a string.
                /// </summary>
                foreach (MethodDef strings in type.Methods)
                {
                    if (!strings.HasBody) continue;
                    for (int i = 0; i < strings.Body.Instructions.Count(); i++)
                    {

                        if (strings.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {
                            // c# variable has for loop scope only
                            String regString = strings.Body.Instructions[i].Operand.ToString();
                            String encString = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(regString));
                            Console.WriteLine($"{regString} -> {encString}");
                            // methodology for adding code: write it in plain c#, compile, then view IL in dnspy
                            strings.Body.Instructions[i].OpCode = OpCodes.Nop; // errors occur if instruction not replaced with Nop
                            strings.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, module.Import(typeof(System.Text.Encoding).GetMethod("get_UTF8", new Type[] { })))); // Load string onto stack
                            strings.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, encString)); // Load string onto stack
                            strings.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, module.Import(typeof(System.Convert).GetMethod("FromBase64String", new Type[] { typeof(string) })))); // call method FromBase64String with string parameter loaded from stack, returned value will be loaded onto stack
                            strings.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, module.Import(typeof(System.Text.Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) })))); // call method GetString with bytes parameter loaded from stack 
                            i += 4; //skip the Instructions as to not recurse on them
                        }
                    }
                }
                #endregion

                #endregion

                #region Assemblies obfuscation

                /// <summary>
                /// Changes names of assemblies
                /// </summary>

                module.Assembly.Name = "Cronos-Crypter" + Randomize.RandomCharacters(15);


                string[] attri = { "AssemblyVersionAttribute", "AssemblyDescriptionAttribute",
                    "AssemblyTitleAttribute", "AssemblyProductAttribute", "AssemblyCopyrightAttribute",
                    "AssemblyCompanyAttribute", "AssemblyFileVersionAttribute", "GuidAttribute", "TargetFrameworkAttribute",
                    "TargetFrameworkAttribute.FrameworkDisplayName", "AssemblyConfigurationAttribute", "AssemblyTrademarkAttribute",};


                foreach (CustomAttribute attribute in module.Assembly.CustomAttributes)
                {
                    if (attri.Any(attribute.AttributeType.Name.Contains))
                    {
                        string encAttri = "Cronos-Crypter" + Randomize.RandomCharacters(15);

                        attribute.ConstructorArguments[0] = new CAArgument(module.CorLibTypes.String, new UTF8String(encAttri));
                    }
                }

                #endregion
            }
        }
    }
}
