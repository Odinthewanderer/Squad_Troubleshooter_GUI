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
            this.components = new System.ComponentModel.Container();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swedishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portugeseBrazilianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nukeBtn
            // 
            resources.ApplyResources(this.nukeBtn, "nukeBtn");
            this.nukeBtn.Name = "nukeBtn";
            this.nukeBtn.UseVisualStyleBackColor = true;
            this.nukeBtn.Click += new System.EventHandler(this.nukeBtn_Click);
            // 
            // generateBtn
            // 
            resources.ApplyResources(this.generateBtn, "generateBtn");
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // reinstallBtn
            // 
            resources.ApplyResources(this.reinstallBtn, "reinstallBtn");
            this.reinstallBtn.Name = "reinstallBtn";
            this.reinstallBtn.UseVisualStyleBackColor = true;
            this.reinstallBtn.Click += new System.EventHandler(this.reinstallBtn_Click);
            // 
            // copyBtn
            // 
            resources.ApplyResources(this.copyBtn, "copyBtn");
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // installBtn
            // 
            resources.ApplyResources(this.installBtn, "installBtn");
            this.installBtn.Name = "installBtn";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // disableBtn
            // 
            resources.ApplyResources(this.disableBtn, "disableBtn");
            this.disableBtn.Name = "disableBtn";
            this.disableBtn.UseVisualStyleBackColor = true;
            this.disableBtn.Click += new System.EventHandler(this.disableBtn_Click);
            // 
            // enableBtn
            // 
            resources.ApplyResources(this.enableBtn, "enableBtn");
            this.enableBtn.Name = "enableBtn";
            this.enableBtn.UseVisualStyleBackColor = true;
            this.enableBtn.Click += new System.EventHandler(this.enableBtn_Click);
            // 
            // getHelpBtn
            // 
            resources.ApplyResources(this.getHelpBtn, "getHelpBtn");
            this.getHelpBtn.Name = "getHelpBtn";
            this.getHelpBtn.UseVisualStyleBackColor = true;
            this.getHelpBtn.Click += new System.EventHandler(this.getHelpBtn_Click);
            // 
            // output_textbox
            // 
            resources.ApplyResources(this.output_textbox, "output_textbox");
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.languagesToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.germanToolStripMenuItem,
            this.polishToolStripMenuItem,
            this.frenchToolStripMenuItem,
            this.chineseToolStripMenuItem,
            this.swedishToolStripMenuItem,
            this.russianToolStripMenuItem,
            this.dutchToolStripMenuItem,
            this.spanishToolStripMenuItem,
            this.portugeseBrazilianToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            resources.ApplyResources(this.languagesToolStripMenuItem, "languagesToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // germanToolStripMenuItem
            // 
            this.germanToolStripMenuItem.Name = "germanToolStripMenuItem";
            resources.ApplyResources(this.germanToolStripMenuItem, "germanToolStripMenuItem");
            this.germanToolStripMenuItem.Click += new System.EventHandler(this.germanToolStripMenuItem_Click);
            // 
            // polishToolStripMenuItem
            // 
            this.polishToolStripMenuItem.Name = "polishToolStripMenuItem";
            resources.ApplyResources(this.polishToolStripMenuItem, "polishToolStripMenuItem");
            this.polishToolStripMenuItem.Click += new System.EventHandler(this.polishToolStripMenuItem_Click);
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            resources.ApplyResources(this.frenchToolStripMenuItem, "frenchToolStripMenuItem");
            this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            resources.ApplyResources(this.chineseToolStripMenuItem, "chineseToolStripMenuItem");
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // swedishToolStripMenuItem
            // 
            this.swedishToolStripMenuItem.Name = "swedishToolStripMenuItem";
            resources.ApplyResources(this.swedishToolStripMenuItem, "swedishToolStripMenuItem");
            this.swedishToolStripMenuItem.Click += new System.EventHandler(this.swedishToolStripMenuItem_Click);
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            resources.ApplyResources(this.russianToolStripMenuItem, "russianToolStripMenuItem");
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.russianToolStripMenuItem_Click);
            // 
            // dutchToolStripMenuItem
            // 
            this.dutchToolStripMenuItem.Name = "dutchToolStripMenuItem";
            resources.ApplyResources(this.dutchToolStripMenuItem, "dutchToolStripMenuItem");
            this.dutchToolStripMenuItem.Click += new System.EventHandler(this.dutchToolStripMenuItem_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            resources.ApplyResources(this.spanishToolStripMenuItem, "spanishToolStripMenuItem");
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // portugeseBrazilianToolStripMenuItem
            // 
            this.portugeseBrazilianToolStripMenuItem.Name = "portugeseBrazilianToolStripMenuItem";
            resources.ApplyResources(this.portugeseBrazilianToolStripMenuItem, "portugeseBrazilianToolStripMenuItem");
            this.portugeseBrazilianToolStripMenuItem.Click += new System.EventHandler(this.portugeseBrazilianToolStripMenuItem_Click);
            // 
            // pathLbl
            // 
            resources.ApplyResources(this.pathLbl, "pathLbl");
            this.pathLbl.Name = "pathLbl";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Squad_Troubleshooter.Properties.Resources.squadlogo_black_gold_hires1;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pathLbl);
            this.Controls.Add(this.output_textbox);
            this.Controls.Add(this.getHelpBtn);
            this.Controls.Add(this.enableBtn);
            this.Controls.Add(this.disableBtn);
            this.Controls.Add(this.installBtn);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.reinstallBtn);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.nukeBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem germanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swedishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dutchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portugeseBrazilianToolStripMenuItem;
        private System.Windows.Forms.Label pathLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

