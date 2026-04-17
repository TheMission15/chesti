namespace ItemAdder
{
    partial class StartUp
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
            WelcomeLbl = new Label();
            AddSkill = new Button();
            AddItem = new Button();
            SuspendLayout();
            // 
            // WelcomeLbl
            // 
            WelcomeLbl.AutoSize = true;
            WelcomeLbl.Location = new Point(12, 9);
            WelcomeLbl.Name = "WelcomeLbl";
            WelcomeLbl.Size = new Size(193, 20);
            WelcomeLbl.TabIndex = 0;
            WelcomeLbl.Text = "Welcome to the Item Adder";
            WelcomeLbl.Click += WelcomeLbl_Click;
            // 
            // AddSkill
            // 
            AddSkill.Location = new Point(119, 211);
            AddSkill.Name = "AddSkill";
            AddSkill.Size = new Size(94, 29);
            AddSkill.TabIndex = 1;
            AddSkill.Text = "AddSkill";
            AddSkill.UseVisualStyleBackColor = true;
            AddSkill.Click += AddSkill_Click;
            // 
            // AddItem
            // 
            AddItem.Location = new Point(476, 209);
            AddItem.Name = "AddItem";
            AddItem.Size = new Size(94, 29);
            AddItem.TabIndex = 2;
            AddItem.Text = "AddItem";
            AddItem.UseVisualStyleBackColor = true;
            AddItem.Click += AddItem_Click;
            // 
            // StartUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddItem);
            Controls.Add(AddSkill);
            Controls.Add(WelcomeLbl);
            Name = "StartUp";
            Text = "Item Adder";
            Load += StartUp_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WelcomeLbl;
        private Button AddSkill;
        private Button AddItem;
    }
}