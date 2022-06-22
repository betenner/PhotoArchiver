namespace PhotoArchiver
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.sourceFolder = new System.Windows.Forms.TextBox();
            this.browseSourceFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.targetFolder = new System.Windows.Forms.TextBox();
            this.browseTargetFolder = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.GroupBox();
            this.includeSubDirectories = new System.Windows.Forms.CheckBox();
            this.copyFile = new System.Windows.Forms.CheckBox();
            this.browseSpecificFolder = new System.Windows.Forms.Button();
            this.specificFolder = new System.Windows.Forms.TextBox();
            this.specificFolderLabel = new System.Windows.Forms.Label();
            this.noExifProcess = new System.Windows.Forms.ComboBox();
            this.renameRule = new System.Windows.Forms.ComboBox();
            this.archiveRule = new System.Windows.Forms.ComboBox();
            this.fileType = new System.Windows.Forms.ComboBox();
            this.archiveFolderNameFormat = new System.Windows.Forms.ComboBox();
            this.archiveFolderNamePreview = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.noExif = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.log = new System.Windows.Forms.ListBox();
            this.start = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.options.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "源文件夹:";
            // 
            // sourceFolder
            // 
            this.sourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFolder.Location = new System.Drawing.Point(96, 12);
            this.sourceFolder.Name = "sourceFolder";
            this.sourceFolder.ReadOnly = true;
            this.sourceFolder.Size = new System.Drawing.Size(376, 23);
            this.sourceFolder.TabIndex = 1;
            // 
            // browseSourceFolder
            // 
            this.browseSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSourceFolder.Location = new System.Drawing.Point(478, 10);
            this.browseSourceFolder.Name = "browseSourceFolder";
            this.browseSourceFolder.Size = new System.Drawing.Size(75, 26);
            this.browseSourceFolder.TabIndex = 2;
            this.browseSourceFolder.Text = "浏览...";
            this.browseSourceFolder.UseVisualStyleBackColor = true;
            this.browseSourceFolder.Click += new System.EventHandler(this.BrowseSourceFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "目标文件夹:";
            // 
            // targetFolder
            // 
            this.targetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFolder.Location = new System.Drawing.Point(96, 44);
            this.targetFolder.Name = "targetFolder";
            this.targetFolder.ReadOnly = true;
            this.targetFolder.Size = new System.Drawing.Size(376, 23);
            this.targetFolder.TabIndex = 4;
            // 
            // browseTargetFolder
            // 
            this.browseTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseTargetFolder.Location = new System.Drawing.Point(478, 42);
            this.browseTargetFolder.Name = "browseTargetFolder";
            this.browseTargetFolder.Size = new System.Drawing.Size(75, 26);
            this.browseTargetFolder.TabIndex = 5;
            this.browseTargetFolder.Text = "浏览...";
            this.browseTargetFolder.UseVisualStyleBackColor = true;
            this.browseTargetFolder.Click += new System.EventHandler(this.BrowseTargetFolder_Click);
            // 
            // options
            // 
            this.options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.options.Controls.Add(this.includeSubDirectories);
            this.options.Controls.Add(this.copyFile);
            this.options.Controls.Add(this.browseSpecificFolder);
            this.options.Controls.Add(this.specificFolder);
            this.options.Controls.Add(this.specificFolderLabel);
            this.options.Controls.Add(this.noExifProcess);
            this.options.Controls.Add(this.renameRule);
            this.options.Controls.Add(this.archiveRule);
            this.options.Controls.Add(this.fileType);
            this.options.Controls.Add(this.archiveFolderNameFormat);
            this.options.Controls.Add(this.archiveFolderNamePreview);
            this.options.Controls.Add(this.label7);
            this.options.Controls.Add(this.noExif);
            this.options.Controls.Add(this.label5);
            this.options.Controls.Add(this.label4);
            this.options.Controls.Add(this.label6);
            this.options.Controls.Add(this.label3);
            this.options.Location = new System.Drawing.Point(12, 73);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(541, 181);
            this.options.TabIndex = 6;
            this.options.TabStop = false;
            this.options.Text = "选项";
            // 
            // includeSubDirectories
            // 
            this.includeSubDirectories.AutoSize = true;
            this.includeSubDirectories.Checked = true;
            this.includeSubDirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeSubDirectories.Location = new System.Drawing.Point(376, 23);
            this.includeSubDirectories.Name = "includeSubDirectories";
            this.includeSubDirectories.Size = new System.Drawing.Size(99, 21);
            this.includeSubDirectories.TabIndex = 2;
            this.includeSubDirectories.Text = "包含子文件夹";
            this.includeSubDirectories.UseVisualStyleBackColor = true;
            this.includeSubDirectories.CheckedChanged += new System.EventHandler(this.IncludeSubDirectories_CheckedChanged);
            // 
            // copyFile
            // 
            this.copyFile.AutoSize = true;
            this.copyFile.Location = new System.Drawing.Point(279, 151);
            this.copyFile.Name = "copyFile";
            this.copyFile.Size = new System.Drawing.Size(135, 21);
            this.copyFile.TabIndex = 16;
            this.copyFile.Text = "复制文件 (而非移动)";
            this.copyFile.UseVisualStyleBackColor = true;
            this.copyFile.CheckedChanged += new System.EventHandler(this.CopyFile_CheckedChanged);
            // 
            // browseSpecificFolder
            // 
            this.browseSpecificFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSpecificFolder.Enabled = false;
            this.browseSpecificFolder.Location = new System.Drawing.Point(460, 113);
            this.browseSpecificFolder.Name = "browseSpecificFolder";
            this.browseSpecificFolder.Size = new System.Drawing.Size(75, 26);
            this.browseSpecificFolder.TabIndex = 13;
            this.browseSpecificFolder.Text = "浏览...";
            this.browseSpecificFolder.UseVisualStyleBackColor = true;
            this.browseSpecificFolder.Click += new System.EventHandler(this.BrowseSpecificFolder_Click);
            // 
            // specificFolder
            // 
            this.specificFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specificFolder.Enabled = false;
            this.specificFolder.Location = new System.Drawing.Point(152, 116);
            this.specificFolder.Name = "specificFolder";
            this.specificFolder.ReadOnly = true;
            this.specificFolder.Size = new System.Drawing.Size(302, 23);
            this.specificFolder.TabIndex = 12;
            // 
            // specificFolderLabel
            // 
            this.specificFolderLabel.AutoSize = true;
            this.specificFolderLabel.Enabled = false;
            this.specificFolderLabel.Location = new System.Drawing.Point(12, 119);
            this.specificFolderLabel.Name = "specificFolderLabel";
            this.specificFolderLabel.Size = new System.Drawing.Size(71, 17);
            this.specificFolderLabel.TabIndex = 11;
            this.specificFolderLabel.Text = "指定文件夹:";
            // 
            // noExifProcess
            // 
            this.noExifProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noExifProcess.Enabled = false;
            this.noExifProcess.FormattingEnabled = true;
            this.noExifProcess.Items.AddRange(new object[] {
            "不处理",
            "按文件创建日期",
            "按文件修改日期",
            "移动到指定文件夹"});
            this.noExifProcess.Location = new System.Drawing.Point(369, 83);
            this.noExifProcess.Name = "noExifProcess";
            this.noExifProcess.Size = new System.Drawing.Size(166, 25);
            this.noExifProcess.TabIndex = 10;
            this.noExifProcess.SelectedIndexChanged += new System.EventHandler(this.NoExifProcess_SelectedIndexChanged);
            // 
            // renameRule
            // 
            this.renameRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renameRule.FormattingEnabled = true;
            this.renameRule.Items.AddRange(new object[] {
            "自动重命名",
            "覆盖",
            "不处理"});
            this.renameRule.Location = new System.Drawing.Point(152, 145);
            this.renameRule.Name = "renameRule";
            this.renameRule.Size = new System.Drawing.Size(121, 25);
            this.renameRule.TabIndex = 15;
            this.renameRule.SelectedIndexChanged += new System.EventHandler(this.RenameRule_SelectedIndexChanged);
            // 
            // archiveRule
            // 
            this.archiveRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.archiveRule.FormattingEnabled = true;
            this.archiveRule.Items.AddRange(new object[] {
            "EXIF拍摄日期",
            "文件创建日期",
            "文件修改日期"});
            this.archiveRule.Location = new System.Drawing.Point(152, 83);
            this.archiveRule.Name = "archiveRule";
            this.archiveRule.Size = new System.Drawing.Size(121, 25);
            this.archiveRule.TabIndex = 8;
            this.archiveRule.SelectedIndexChanged += new System.EventHandler(this.ArchiveRule_SelectedIndexChanged);
            // 
            // fileType
            // 
            this.fileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileType.FormattingEnabled = true;
            this.fileType.Items.AddRange(new object[] {
            "照片文件 (*.jpg;*.jpe;*.jpeg;*.png;*.tif;*.tiff)",
            "所有文件 (*.*)"});
            this.fileType.Location = new System.Drawing.Point(152, 21);
            this.fileType.Name = "fileType";
            this.fileType.Size = new System.Drawing.Size(218, 25);
            this.fileType.TabIndex = 1;
            this.fileType.SelectedIndexChanged += new System.EventHandler(this.FileType_SelectedIndexChanged);
            // 
            // archiveFolderNameFormat
            // 
            this.archiveFolderNameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.archiveFolderNameFormat.FormattingEnabled = true;
            this.archiveFolderNameFormat.Items.AddRange(new object[] {
            "yyyyMM",
            "yyyy-MM",
            "yyyyMMdd",
            "yyyy-MM-dd",
            "yyyy"});
            this.archiveFolderNameFormat.Location = new System.Drawing.Point(152, 52);
            this.archiveFolderNameFormat.Name = "archiveFolderNameFormat";
            this.archiveFolderNameFormat.Size = new System.Drawing.Size(121, 25);
            this.archiveFolderNameFormat.TabIndex = 4;
            this.archiveFolderNameFormat.SelectedIndexChanged += new System.EventHandler(this.ArchiveFolderNamingRule_SelectedIndexChanged);
            // 
            // archiveFolderNamePreview
            // 
            this.archiveFolderNamePreview.AutoSize = true;
            this.archiveFolderNamePreview.Location = new System.Drawing.Point(320, 58);
            this.archiveFolderNamePreview.Name = "archiveFolderNamePreview";
            this.archiveFolderNamePreview.Size = new System.Drawing.Size(50, 17);
            this.archiveFolderNamePreview.TabIndex = 6;
            this.archiveFolderNamePreview.Text = "202206";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "重名处理:";
            // 
            // noExif
            // 
            this.noExif.AutoSize = true;
            this.noExif.Enabled = false;
            this.noExif.Location = new System.Drawing.Point(279, 86);
            this.noExif.Name = "noExif";
            this.noExif.Size = new System.Drawing.Size(84, 17);
            this.noExif.TabIndex = 9;
            this.noExif.Text = "无EXIF信息时:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "归档依据:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "预览:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "文件类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "归档文件夹命名规则:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.log);
            this.groupBox2.Location = new System.Drawing.Point(12, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 177);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.FormattingEnabled = true;
            this.log.HorizontalScrollbar = true;
            this.log.ItemHeight = 17;
            this.log.Location = new System.Drawing.Point(6, 22);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(529, 140);
            this.log.TabIndex = 0;
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Enabled = false;
            this.start.Location = new System.Drawing.Point(456, 443);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(97, 32);
            this.start.TabIndex = 8;
            this.start.Text = "开始归档";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(18, 448);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(432, 23);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 17;
            this.progress.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 487);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.options);
            this.Controls.Add(this.browseTargetFolder);
            this.Controls.Add(this.targetFolder);
            this.Controls.Add(this.browseSourceFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sourceFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "照片归档器";
            this.options.ResumeLayout(false);
            this.options.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox sourceFolder;
        private Button browseSourceFolder;
        private Label label2;
        private TextBox targetFolder;
        private Button browseTargetFolder;
        private GroupBox options;
        private ComboBox archiveRule;
        private ComboBox fileType;
        private ComboBox archiveFolderNameFormat;
        private Label archiveFolderNamePreview;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label3;
        private Button browseSpecificFolder;
        private TextBox specificFolder;
        private Label specificFolderLabel;
        private ComboBox noExifProcess;
        private Label noExif;
        private ComboBox renameRule;
        private Label label7;
        private CheckBox copyFile;
        private GroupBox groupBox2;
        private ListBox log;
        private Button start;
        private CheckBox includeSubDirectories;
        private ProgressBar progress;
    }
}