using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronosCrypter.Core
{
    public struct Settings
    {
        // Build and Stub

        public string buildDirectory;
        public string payloadName;
        public string resourceName;
        public string decryptKey;
        public string stubResources;
        public string encryptedPayload;
        public string injectionType;
        public string injectionName;
        public EncryptionType encryptionType;

        // Startup

        public string fileName;
        public string specialDir;
        public string regeditName;
        public string schtasksName;
        public string folderName;
        public bool doRegedit;
        public bool doSchtasks;
        public bool doInstall;

        // Settings
        public int sleep;
        public bool doSleep;
        public bool doAntiVM;

        // Assembly cloner
        public Assembly assemblyInfo;
    }
}
