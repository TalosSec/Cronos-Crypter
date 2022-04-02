using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2Simple_Crypter
{
    public partial class MainFrm : Form
    {
        // Needed for moving window
        bool mouseDown;
        private Point offset;

        public MainFrm()
        {
            InitializeComponent();
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

        }
        #endregion

        #region Code

        /// <summary>
        /// This region contains the code, mostly needed for the UI but also stuff like obfuscate
        /// </summary>
       
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
