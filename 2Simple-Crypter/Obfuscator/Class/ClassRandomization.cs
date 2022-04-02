using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Simple_Crypter.Obfuscator.Class
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
