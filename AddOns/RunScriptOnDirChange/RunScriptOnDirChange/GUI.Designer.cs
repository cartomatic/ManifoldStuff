namespace RunScriptOnDirChange
{
    partial class GUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDir = new System.Windows.Forms.TextBox();
            this.btnStartWatcher = new System.Windows.Forms.Button();
            this.btnStopWatcher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.cmbScripts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chckBoxCreate = new System.Windows.Forms.CheckBox();
            this.chckBoxChange = new System.Windows.Forms.CheckBox();
            this.chckBoxDelete = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDumpName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDir
            // 
            this.txtDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir.Location = new System.Drawing.Point(3, 21);
            this.txtDir.Name = "txtDir";
            this.txtDir.ReadOnly = true;
            this.txtDir.Size = new System.Drawing.Size(155, 20);
            this.txtDir.TabIndex = 0;
            // 
            // btnStartWatcher
            // 
            this.btnStartWatcher.Location = new System.Drawing.Point(3, 181);
            this.btnStartWatcher.Name = "btnStartWatcher";
            this.btnStartWatcher.Size = new System.Drawing.Size(93, 23);
            this.btnStartWatcher.TabIndex = 1;
            this.btnStartWatcher.Text = "Start";
            this.btnStartWatcher.UseVisualStyleBackColor = true;
            this.btnStartWatcher.Click += new System.EventHandler(this.btnStartWatcher_Click);
            // 
            // btnStopWatcher
            // 
            this.btnStopWatcher.Enabled = false;
            this.btnStopWatcher.Location = new System.Drawing.Point(102, 181);
            this.btnStopWatcher.Name = "btnStopWatcher";
            this.btnStopWatcher.Size = new System.Drawing.Size(89, 23);
            this.btnStopWatcher.TabIndex = 2;
            this.btnStopWatcher.Text = "Stop";
            this.btnStopWatcher.UseVisualStyleBackColor = true;
            this.btnStopWatcher.Click += new System.EventHandler(this.btnStopWatcher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory to watch for changes:";
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDir.Location = new System.Drawing.Point(164, 21);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(27, 20);
            this.btnBrowseDir.TabIndex = 4;
            this.btnBrowseDir.Text = "...";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // cmbScripts
            // 
            this.cmbScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScripts.FormattingEnabled = true;
            this.cmbScripts.Location = new System.Drawing.Point(3, 110);
            this.cmbScripts.Name = "cmbScripts";
            this.cmbScripts.Size = new System.Drawing.Size(188, 21);
            this.cmbScripts.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Callback script:";
            // 
            // chckBoxCreate
            // 
            this.chckBoxCreate.AutoSize = true;
            this.chckBoxCreate.Checked = true;
            this.chckBoxCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckBoxCreate.Location = new System.Drawing.Point(5, 68);
            this.chckBoxCreate.Name = "chckBoxCreate";
            this.chckBoxCreate.Size = new System.Drawing.Size(56, 17);
            this.chckBoxCreate.TabIndex = 7;
            this.chckBoxCreate.Text = "create";
            this.chckBoxCreate.UseVisualStyleBackColor = true;
            // 
            // chckBoxChange
            // 
            this.chckBoxChange.AutoSize = true;
            this.chckBoxChange.Checked = true;
            this.chckBoxChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckBoxChange.Location = new System.Drawing.Point(67, 68);
            this.chckBoxChange.Name = "chckBoxChange";
            this.chckBoxChange.Size = new System.Drawing.Size(62, 17);
            this.chckBoxChange.TabIndex = 8;
            this.chckBoxChange.Text = "change";
            this.chckBoxChange.UseVisualStyleBackColor = true;
            // 
            // chckBoxDelete
            // 
            this.chckBoxDelete.AutoSize = true;
            this.chckBoxDelete.Location = new System.Drawing.Point(136, 68);
            this.chckBoxDelete.Name = "chckBoxDelete";
            this.chckBoxDelete.Size = new System.Drawing.Size(55, 17);
            this.chckBoxDelete.TabIndex = 9;
            this.chckBoxDelete.Text = "delete";
            this.chckBoxDelete.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Changes to watch for:";
            // 
            // txtDumpName
            // 
            this.txtDumpName.Location = new System.Drawing.Point(3, 155);
            this.txtDumpName.Name = "txtDumpName";
            this.txtDumpName.Size = new System.Drawing.Size(188, 20);
            this.txtDumpName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name of the watcher notification comp:";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDumpName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chckBoxDelete);
            this.Controls.Add(this.chckBoxChange);
            this.Controls.Add(this.chckBoxCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbScripts);
            this.Controls.Add(this.btnBrowseDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStopWatcher);
            this.Controls.Add(this.btnStartWatcher);
            this.Controls.Add(this.txtDir);
            this.Name = "GUI";
            this.Size = new System.Drawing.Size(194, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnStartWatcher;
        private System.Windows.Forms.Button btnStopWatcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.ComboBox cmbScripts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chckBoxCreate;
        private System.Windows.Forms.CheckBox chckBoxChange;
        private System.Windows.Forms.CheckBox chckBoxDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDumpName;
        private System.Windows.Forms.Label label4;
    }
}
