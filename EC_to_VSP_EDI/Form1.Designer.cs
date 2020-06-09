using System.Windows.Forms;

namespace EC_to_BCBS_EDI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnProcessEDI = new System.Windows.Forms.Button();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblInterchangeNumber = new System.Windows.Forms.Label();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.lblOutPutFolder = new System.Windows.Forms.Label();
            this.lblProcess = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbTextOut = new System.Windows.Forms.TextBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.lblOutputSave = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblFileType = new System.Windows.Forms.Label();
            this.lblFileLocation_cnt = new System.Windows.Forms.Label();
            this.lblProcessedCnt = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(13, 12);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(132, 23);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load Census";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // btnProcessEDI
            // 
            this.btnProcessEDI.Enabled = false;
            this.btnProcessEDI.Location = new System.Drawing.Point(302, 138);
            this.btnProcessEDI.Name = "btnProcessEDI";
            this.btnProcessEDI.Size = new System.Drawing.Size(132, 23);
            this.btnProcessEDI.TabIndex = 1;
            this.btnProcessEDI.Text = "Process EDI";
            this.btnProcessEDI.UseVisualStyleBackColor = true;
            this.btnProcessEDI.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.Location = new System.Drawing.Point(158, 17);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(95, 13);
            this.lblFileLocation.TabIndex = 2;
            this.lblFileLocation.Text = "Click Here to Load";
            // 
            // dtPicker
            // 
            this.dtPicker.Enabled = false;
            this.dtPicker.Location = new System.Drawing.Point(158, 55);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(200, 20);
            this.dtPicker.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 54);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Interchange";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // lblInterchangeNumber
            // 
            this.lblInterchangeNumber.AutoSize = true;
            this.lblInterchangeNumber.Location = new System.Drawing.Point(364, 59);
            this.lblInterchangeNumber.Name = "lblInterchangeNumber";
            this.lblInterchangeNumber.Size = new System.Drawing.Size(152, 13);
            this.lblInterchangeNumber.TabIndex = 5;
            this.lblInterchangeNumber.Text = "waiting for interchange number";
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(13, 96);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(132, 23);
            this.btnSaveFile.TabIndex = 6;
            this.btnSaveFile.Text = "Output Folder";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.BtnSaveFile_Click);
            // 
            // lblOutPutFolder
            // 
            this.lblOutPutFolder.AutoSize = true;
            this.lblOutPutFolder.Location = new System.Drawing.Point(158, 101);
            this.lblOutPutFolder.Name = "lblOutPutFolder";
            this.lblOutPutFolder.Size = new System.Drawing.Size(120, 13);
            this.lblOutPutFolder.TabIndex = 7;
            this.lblOutPutFolder.Text = "Waiting for output folder";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(447, 143);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(122, 13);
            this.lblProcess.TabIndex = 8;
            this.lblProcess.Text = "Waiting to be processed";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tbTextOut);
            this.panel1.Location = new System.Drawing.Point(15, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 539);
            this.panel1.TabIndex = 9;
            // 
            // tbTextOut
            // 
            this.tbTextOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTextOut.Location = new System.Drawing.Point(4, 4);
            this.tbTextOut.Multiline = true;
            this.tbTextOut.Name = "tbTextOut";
            this.tbTextOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTextOut.Size = new System.Drawing.Size(845, 524);
            this.tbTextOut.TabIndex = 0;
            // 
            // btnOutput
            // 
            this.btnOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOutput.Enabled = false;
            this.btnOutput.Location = new System.Drawing.Point(15, 713);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(272, 23);
            this.btnOutput.TabIndex = 10;
            this.btnOutput.Text = "Output EDI File";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // lblOutputSave
            // 
            this.lblOutputSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputSave.AutoSize = true;
            this.lblOutputSave.Location = new System.Drawing.Point(293, 718);
            this.lblOutputSave.Name = "lblOutputSave";
            this.lblOutputSave.Size = new System.Drawing.Size(133, 13);
            this.lblOutputSave.TabIndex = 11;
            this.lblOutputSave.Text = "Waiting for file to be saved";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Test",
            "Original",
            "Re-submission",
            "Information Copy"});
            this.cbType.Location = new System.Drawing.Point(76, 139);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(187, 21);
            this.cbType.TabIndex = 12;
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(17, 143);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(53, 13);
            this.lblFileType.TabIndex = 13;
            this.lblFileType.Text = "File Type:";
            // 
            // lblFileLocation_cnt
            // 
            this.lblFileLocation_cnt.AutoSize = true;
            this.lblFileLocation_cnt.Location = new System.Drawing.Point(161, 34);
            this.lblFileLocation_cnt.Name = "lblFileLocation_cnt";
            this.lblFileLocation_cnt.Size = new System.Drawing.Size(97, 13);
            this.lblFileLocation_cnt.TabIndex = 15;
            this.lblFileLocation_cnt.Text = "Waiting for count...";
            // 
            // lblProcessedCnt
            // 
            this.lblProcessedCnt.AutoSize = true;
            this.lblProcessedCnt.Location = new System.Drawing.Point(695, 142);
            this.lblProcessedCnt.Name = "lblProcessedCnt";
            this.lblProcessedCnt.Size = new System.Drawing.Size(16, 13);
            this.lblProcessedCnt.TabIndex = 16;
            this.lblProcessedCnt.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 744);
            this.Controls.Add(this.lblProcessedCnt);
            this.Controls.Add(this.lblFileLocation);
            this.Controls.Add(this.lblFileLocation_cnt);
            this.Controls.Add(this.lblFileType);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lblOutputSave);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.lblOutPutFolder);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.lblInterchangeNumber);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.btnProcessEDI);
            this.Controls.Add(this.btnLoadFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Ease Enrollment Census to BCBS 834 EDI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnLoadFile;
        public System.Windows.Forms.Button btnProcessEDI;
        public System.Windows.Forms.Label lblFileLocation;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblInterchangeNumber;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Label lblOutPutFolder;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTextOut;
        private Button btnOutput;
        private Label lblOutputSave;
        public ComboBox cbType;
        private Label lblFileType;
        private Label lblFileLocation_cnt;
        private Label lblProcessedCnt;
    }
}

