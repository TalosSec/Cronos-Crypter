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
        }
    }
}
