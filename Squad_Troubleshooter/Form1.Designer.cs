namespace Squad_Troubleshooter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nukeBtn = new System.Windows.Forms.Button();
            this.generateBtn = new System.Windows.Forms.Button();
            this.reinstallBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.installBtn = new System.Windows.Forms.Button();
            this.disableBtn = new System.Windows.Forms.Button();
            this.enableBtn = new System.Windows.Forms.Button();
            this.getHelpBtn = new System.Windows.Forms.Button();
            this.output_textbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // nukeBtn
            // 
            this.nukeBtn.Location = new System.Drawing.Point(181, 66);
            this.nukeBtn.Name = "nukeBtn";
            this.nukeBtn.Size = new System.Drawing.Size(267, 23);
            this.nukeBtn.TabIndex = 0;
            this.nukeBtn.Text = "Nuke AppData Config Files";
            this.nukeBtn.UseVisualStyleBackColor = true;
            this.nukeBtn.Click += new System.EventHandler(this.nukeBtn_Click);
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(181, 95);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(267, 23);
            this.generateBtn.TabIndex = 1;
            this.generateBtn.Text = "Generate Windows Event Log";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // reinstallBtn
            // 
            this.reinstallBtn.Location = new System.Drawing.Point(181, 124);
            this.reinstallBtn.Name = "reinstallBtn";
            this.reinstallBtn.Size = new System.Drawing.Size(267, 23);
            this.reinstallBtn.TabIndex = 2;
            this.reinstallBtn.Text = "Re-install Easy Anti-Cheat (EAC)";
            this.reinstallBtn.UseVisualStyleBackColor = true;
            this.reinstallBtn.Click += new System.EventHandler(this.reinstallBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(181, 153);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(267, 23);
            this.copyBtn.TabIndex = 3;
            this.copyBtn.Text = "Copy Squad Logs to Desktop";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // installBtn
            // 
            this.installBtn.Location = new System.Drawing.Point(181, 182);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(267, 23);
            this.installBtn.TabIndex = 4;
            this.installBtn.Text = "Install VC Redistributable 2013 + 2015";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // disableBtn
            // 
            this.disableBtn.Location = new System.Drawing.Point(181, 211);
            this.disableBtn.Name = "disableBtn";
            this.disableBtn.Size = new System.Drawing.Size(267, 23);
            this.disableBtn.TabIndex = 5;
            this.disableBtn.Text = "Disable Windows Firewall";
            this.disableBtn.UseVisualStyleBackColor = true;
            this.disableBtn.Click += new System.EventHandler(this.disableBtn_Click);
            // 
            // enableBtn
            // 
            this.enableBtn.Location = new System.Drawing.Point(181, 240);
            this.enableBtn.Name = "enableBtn";
            this.enableBtn.Size = new System.Drawing.Size(267, 23);
            this.enableBtn.TabIndex = 6;
            this.enableBtn.Text = "Enable Windows Firewall";
            this.enableBtn.UseVisualStyleBackColor = true;
            this.enableBtn.Click += new System.EventHandler(this.enableBtn_Click);
            // 
            // getHelpBtn
            // 
            this.getHelpBtn.Location = new System.Drawing.Point(181, 269);
            this.getHelpBtn.Name = "getHelpBtn";
            this.getHelpBtn.Size = new System.Drawing.Size(267, 23);
            this.getHelpBtn.TabIndex = 7;
            this.getHelpBtn.Text = "Get help with game crashing on server browser";
            this.getHelpBtn.UseVisualStyleBackColor = true;
            this.getHelpBtn.Click += new System.EventHandler(this.getHelpBtn_Click);
            // 
            // output_textbox
            // 
            this.output_textbox.Location = new System.Drawing.Point(12, 323);
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.ReadOnly = true;
            this.output_textbox.Size = new System.Drawing.Size(583, 310);
            this.output_textbox.TabIndex = 8;
            this.output_textbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 637);
            this.Controls.Add(this.output_textbox);
            this.Controls.Add(this.getHelpBtn);
            this.Controls.Add(this.enableBtn);
            this.Controls.Add(this.disableBtn);
            this.Controls.Add(this.installBtn);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.reinstallBtn);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.nukeBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SuicidalChair\'s Improved Squad Troubleshooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nukeBtn;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button reinstallBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.Button disableBtn;
        private System.Windows.Forms.Button enableBtn;
        private System.Windows.Forms.Button getHelpBtn;
        private System.Windows.Forms.RichTextBox output_textbox;
    }
}

