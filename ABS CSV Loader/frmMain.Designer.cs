namespace ABS_CSV_Loader
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.lstPending = new System.Windows.Forms.ListBox();
            this.lstCompleted = new System.Windows.Forms.ListBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.lblUid = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dlgFolderBrowser
            // 
            this.dlgFolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lstPending
            // 
            this.lstPending.FormattingEnabled = true;
            resources.ApplyResources(this.lstPending, "lstPending");
            this.lstPending.Name = "lstPending";
            this.lstPending.SelectedIndexChanged += new System.EventHandler(this.lstPending_SelectedIndexChanged);
            // 
            // lstCompleted
            // 
            this.lstCompleted.FormattingEnabled = true;
            resources.ApplyResources(this.lstCompleted, "lstCompleted");
            this.lstCompleted.Name = "lstCompleted";
            this.lstCompleted.SelectedIndexChanged += new System.EventHandler(this.lstCompleted_SelectedIndexChanged);
            // 
            // txtFolder
            // 
            this.txtFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtFolder, "txtFolder");
            this.txtFolder.Name = "txtFolder";
            // 
            // txtCount
            // 
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtCount, "txtCount");
            this.txtCount.Name = "txtCount";
            // 
            // txtFileName
            // 
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtServer
            // 
            resources.ApplyResources(this.txtServer, "txtServer");
            this.txtServer.Name = "txtServer";
            // 
            // lblDBServer
            // 
            resources.ApplyResources(this.lblDBServer, "lblDBServer");
            this.lblDBServer.Name = "lblDBServer";
            // 
            // txtDatabase
            // 
            resources.ApplyResources(this.txtDatabase, "txtDatabase");
            this.txtDatabase.Name = "txtDatabase";
            // 
            // lblDataBase
            // 
            resources.ApplyResources(this.lblDataBase, "lblDataBase");
            this.lblDataBase.Name = "lblDataBase";
            // 
            // txtUid
            // 
            resources.ApplyResources(this.txtUid, "txtUid");
            this.txtUid.Name = "txtUid";
            // 
            // lblUid
            // 
            resources.ApplyResources(this.lblUid, "lblUid");
            this.lblUid.Name = "lblUid";
            // 
            // txtPwd
            // 
            resources.ApplyResources(this.txtPwd, "txtPwd");
            this.txtPwd.Name = "txtPwd";
            // 
            // lblPwd
            // 
            resources.ApplyResources(this.lblPwd, "lblPwd");
            this.lblPwd.Name = "lblPwd";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblUid);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.lblDBServer);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.lstCompleted);
            this.Controls.Add(this.lstPending);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.ListBox lstPending;
        private System.Windows.Forms.ListBox lstCompleted;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblDBServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label lblUid;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
    }
}

