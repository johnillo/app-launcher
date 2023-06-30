namespace AppLauncher
{
    partial class MainForm
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.searchbox = new System.Windows.Forms.TextBox();
            this.launchAction = new System.Windows.Forms.Button();
            this.appsList = new System.Windows.Forms.ListBox();
            this.ExcludeUninstallersCheckbox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(9, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 13);
            label1.TabIndex = 3;
            label1.Text = "Find Program:";
            // 
            // searchbox
            // 
            this.searchbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchbox.Location = new System.Drawing.Point(12, 28);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(460, 21);
            this.searchbox.TabIndex = 0;
            this.searchbox.TextChanged += new System.EventHandler(this.OnSearchBoxTextChanged);
            this.searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSearchBoxKeyDown);
            // 
            // launchAction
            // 
            this.launchAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.launchAction.Location = new System.Drawing.Point(389, 303);
            this.launchAction.Name = "launchAction";
            this.launchAction.Size = new System.Drawing.Size(83, 24);
            this.launchAction.TabIndex = 1;
            this.launchAction.Text = "&Launch";
            this.launchAction.UseVisualStyleBackColor = true;
            this.launchAction.Click += new System.EventHandler(this.OnLaunchActionClick);
            // 
            // appsList
            // 
            this.appsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.appsList.FormattingEnabled = true;
            this.appsList.HorizontalScrollbar = true;
            this.appsList.IntegralHeight = false;
            this.appsList.Location = new System.Drawing.Point(12, 55);
            this.appsList.Name = "appsList";
            this.appsList.Size = new System.Drawing.Size(460, 242);
            this.appsList.TabIndex = 2;
            // 
            // ExcludeUninstallersCheckbox
            // 
            this.ExcludeUninstallersCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExcludeUninstallersCheckbox.AutoSize = true;
            this.ExcludeUninstallersCheckbox.Checked = true;
            this.ExcludeUninstallersCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExcludeUninstallersCheckbox.Location = new System.Drawing.Point(12, 308);
            this.ExcludeUninstallersCheckbox.Name = "ExcludeUninstallersCheckbox";
            this.ExcludeUninstallersCheckbox.Size = new System.Drawing.Size(121, 17);
            this.ExcludeUninstallersCheckbox.TabIndex = 4;
            this.ExcludeUninstallersCheckbox.Text = "E&xclude Uninstallers";
            this.ExcludeUninstallersCheckbox.UseVisualStyleBackColor = true;
            this.ExcludeUninstallersCheckbox.CheckedChanged += new System.EventHandler(this.OnExcludeUninstallersCheckboxCheckChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 337);
            this.Controls.Add(this.ExcludeUninstallersCheckbox);
            this.Controls.Add(label1);
            this.Controls.Add(this.appsList);
            this.Controls.Add(this.launchAction);
            this.Controls.Add(this.searchbox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(264, 235);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "App Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnMainFormKeyDown);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Button launchAction;
        private System.Windows.Forms.ListBox appsList;
        private System.Windows.Forms.CheckBox ExcludeUninstallersCheckbox;
    }
}

