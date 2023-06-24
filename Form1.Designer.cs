namespace U3_2_Automobiliu_parkas
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGasTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findLargestCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formattingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.results = new System.Windows.Forms.RichTextBox();
            this.gasTypeLabel = new System.Windows.Forms.Label();
            this.gasType = new System.Windows.Forms.TextBox();
            this.notificationLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setGasTypeToolStripMenuItem,
            this.readDataToolStripMenuItem,
            this.printToolStripMenuItem,
            this.endToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.programToolStripMenuItem.Text = "Failas";
            // 
            // setGasTypeToolStripMenuItem
            // 
            this.setGasTypeToolStripMenuItem.Name = "setGasTypeToolStripMenuItem";
            this.setGasTypeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.setGasTypeToolStripMenuItem.Text = "Įvesti kuro tipą";
            this.setGasTypeToolStripMenuItem.Click += new System.EventHandler(this.setGasTypeToolStripMenuItem_Click);
            // 
            // readDataToolStripMenuItem
            // 
            this.readDataToolStripMenuItem.Name = "readDataToolStripMenuItem";
            this.readDataToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.readDataToolStripMenuItem.Text = "Įvesti pradinius duomenis";
            this.readDataToolStripMenuItem.Click += new System.EventHandler(this.readDataToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.printToolStripMenuItem.Text = "Spausdinti";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.endToolStripMenuItem.Text = "Baigti";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findBranchToolStripMenuItem,
            this.findLargestCountToolStripMenuItem,
            this.formattingToolStripMenuItem,
            this.sortToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // findBranchToolStripMenuItem
            // 
            this.findBranchToolStripMenuItem.Name = "findBranchToolStripMenuItem";
            this.findBranchToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.findBranchToolStripMenuItem.Text = "Seniausių priemonių filialo radimas";
            this.findBranchToolStripMenuItem.Click += new System.EventHandler(this.findBranchToolStripMenuItem_Click);
            // 
            // findLargestCountToolStripMenuItem
            // 
            this.findLargestCountToolStripMenuItem.Name = "findLargestCountToolStripMenuItem";
            this.findLargestCountToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.findLargestCountToolStripMenuItem.Text = "Didžiausio kiekio radimas";
            this.findLargestCountToolStripMenuItem.Click += new System.EventHandler(this.findLargestCountToolStripMenuItem_Click);
            // 
            // formattingToolStripMenuItem
            // 
            this.formattingToolStripMenuItem.Name = "formattingToolStripMenuItem";
            this.formattingToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.formattingToolStripMenuItem.Text = "Naujo sąrašo formavimas";
            this.formattingToolStripMenuItem.Click += new System.EventHandler(this.formattingToolStripMenuItem_Click);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.sortToolStripMenuItem.Text = "Rikiavimas";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.sortToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.informationToolStripMenuItem.Text = "Informacija";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // results
            // 
            this.results.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.results.Location = new System.Drawing.Point(12, 27);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(989, 427);
            this.results.TabIndex = 1;
            this.results.Text = "";
            // 
            // gasTypeLabel
            // 
            this.gasTypeLabel.AutoSize = true;
            this.gasTypeLabel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.gasTypeLabel.Location = new System.Drawing.Point(11, 457);
            this.gasTypeLabel.Name = "gasTypeLabel";
            this.gasTypeLabel.Size = new System.Drawing.Size(113, 25);
            this.gasTypeLabel.TabIndex = 2;
            this.gasTypeLabel.Text = "Kuro tipas";
            // 
            // gasType
            // 
            this.gasType.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.gasType.ForeColor = System.Drawing.Color.Blue;
            this.gasType.Location = new System.Drawing.Point(12, 485);
            this.gasType.Name = "gasType";
            this.gasType.Size = new System.Drawing.Size(308, 28);
            this.gasType.TabIndex = 3;
            this.gasType.Text = "Čia įveskite kuro tipą.";
            // 
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.notificationLabel.ForeColor = System.Drawing.Color.Red;
            this.notificationLabel.Location = new System.Drawing.Point(12, 532);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(156, 22);
            this.notificationLabel.TabIndex = 4;
            this.notificationLabel.Text = "Pranešimų laukas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 641);
            this.Controls.Add(this.notificationLabel);
            this.Controls.Add(this.gasType);
            this.Controls.Add(this.gasTypeLabel);
            this.Controls.Add(this.results);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Transportas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.RichTextBox results;
        private System.Windows.Forms.Label gasTypeLabel;
        private System.Windows.Forms.TextBox gasType;
        private System.Windows.Forms.Label notificationLabel;
        private System.Windows.Forms.ToolStripMenuItem setGasTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findBranchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findLargestCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formattingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
    }
}

