namespace ItemAdder.Add_Pages
{
    partial class AddSkillMenu
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
            GroupList = new CheckedListBox();
            label2 = new Label();
            label1 = new Label();
            ItemName = new TextBox();
            SkillPower = new TextBox();
            ElementList = new CheckedListBox();
            SubmitBtn = new Button();
            SkillSpeed = new TextBox();
            EliteBtn = new RadioButton();
            ImprovedBtn = new RadioButton();
            NewBtn = new RadioButton();
            StandardBtn = new RadioButton();
            SuspendLayout();
            // 
            // GroupList
            // 
            GroupList.FormattingEnabled = true;
            GroupList.Items.AddRange(new object[] { "Freestyle", "Power", "Speed", "Range", "Close", "Magic", "Modern" });
            GroupList.Location = new Point(501, 143);
            GroupList.Name = "GroupList";
            GroupList.Size = new Size(124, 158);
            GroupList.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(25, 75);
            label2.Name = "label2";
            label2.Size = new Size(476, 30);
            label2.TabIndex = 7;
            label2.Text = "Enter Name, Power/Speed, Group(s), Element(s)\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(238, 41);
            label1.TabIndex = 8;
            label1.Text = "Enter Speed Skill";
            // 
            // ItemName
            // 
            ItemName.Location = new Point(25, 136);
            ItemName.Multiline = true;
            ItemName.Name = "ItemName";
            ItemName.PlaceholderText = "Enter Name";
            ItemName.Size = new Size(125, 27);
            ItemName.TabIndex = 9;
            // 
            // SkillPower
            // 
            SkillPower.Location = new Point(25, 173);
            SkillPower.Name = "SkillPower";
            SkillPower.PlaceholderText = "Enter Power";
            SkillPower.Size = new Size(125, 27);
            SkillPower.TabIndex = 14;
            // 
            // ElementList
            // 
            ElementList.FormattingEnabled = true;
            ElementList.Items.AddRange(new object[] { "Neutral", "Fire", "Water", "Lightning", "Nature", "Ice", "Anti" });
            ElementList.Location = new Point(640, 143);
            ElementList.Name = "ElementList";
            ElementList.Size = new Size(111, 158);
            ElementList.TabIndex = 15;
            // 
            // SubmitBtn
            // 
            SubmitBtn.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubmitBtn.ForeColor = Color.SpringGreen;
            SubmitBtn.Location = new Point(590, 352);
            SubmitBtn.Name = "SubmitBtn";
            SubmitBtn.Size = new Size(177, 70);
            SubmitBtn.TabIndex = 19;
            SubmitBtn.Text = "Submit";
            SubmitBtn.UseVisualStyleBackColor = true;
            // 
            // SkillSpeed
            // 
            SkillSpeed.Location = new Point(25, 209);
            SkillSpeed.Name = "SkillSpeed";
            SkillSpeed.PlaceholderText = "Enter Speed";
            SkillSpeed.Size = new Size(125, 27);
            SkillSpeed.TabIndex = 20;
            // 
            // EliteBtn
            // 
            EliteBtn.AutoSize = true;
            EliteBtn.BackColor = SystemColors.Control;
            EliteBtn.Location = new Point(207, 277);
            EliteBtn.Name = "EliteBtn";
            EliteBtn.Size = new Size(59, 24);
            EliteBtn.TabIndex = 24;
            EliteBtn.TabStop = true;
            EliteBtn.Tag = Chesti.Core.Model.Rarity.Elite;
            EliteBtn.Text = "Elite";
            EliteBtn.UseVisualStyleBackColor = false;
            // 
            // ImprovedBtn
            // 
            ImprovedBtn.AutoSize = true;
            ImprovedBtn.BackColor = SystemColors.Control;
            ImprovedBtn.Location = new Point(207, 224);
            ImprovedBtn.Name = "ImprovedBtn";
            ImprovedBtn.Size = new Size(94, 24);
            ImprovedBtn.TabIndex = 23;
            ImprovedBtn.TabStop = true;
            ImprovedBtn.Tag = Chesti.Core.Model.Rarity.Improved;
            ImprovedBtn.Text = "Improved";
            ImprovedBtn.UseVisualStyleBackColor = false;
            // 
            // NewBtn
            // 
            NewBtn.AutoSize = true;
            NewBtn.BackColor = SystemColors.Control;
            NewBtn.Location = new Point(207, 181);
            NewBtn.Name = "NewBtn";
            NewBtn.Size = new Size(60, 24);
            NewBtn.TabIndex = 22;
            NewBtn.TabStop = true;
            NewBtn.Tag = Chesti.Core.Model.Rarity.New;
            NewBtn.Text = "New";
            NewBtn.UseVisualStyleBackColor = false;
            // 
            // StandardBtn
            // 
            StandardBtn.AutoSize = true;
            StandardBtn.BackColor = SystemColors.Control;
            StandardBtn.Location = new Point(207, 136);
            StandardBtn.Name = "StandardBtn";
            StandardBtn.Size = new Size(90, 24);
            StandardBtn.TabIndex = 21;
            StandardBtn.TabStop = true;
            StandardBtn.Tag = Chesti.Core.Model.Rarity.Standard;
            StandardBtn.Text = "Standard";
            StandardBtn.UseVisualStyleBackColor = false;
            // 
            // AddSkillMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            ClientSize = new Size(800, 450);
            Controls.Add(EliteBtn);
            Controls.Add(ImprovedBtn);
            Controls.Add(NewBtn);
            Controls.Add(StandardBtn);
            Controls.Add(SkillSpeed);
            Controls.Add(SubmitBtn);
            Controls.Add(ElementList);
            Controls.Add(SkillPower);
            Controls.Add(ItemName);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(GroupList);
            Name = "AddSkillMenu";
            Text = "New Skill";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckedListBox GroupList;
        private Label label2;
        private Label label1;
        private TextBox ItemName;
        private TextBox SkillPower;
        private CheckedListBox ElementList;
        private Button SubmitBtn;
        private TextBox SkillSpeed;
        private RadioButton EliteBtn;
        private RadioButton ImprovedBtn;
        private RadioButton NewBtn;
        private RadioButton StandardBtn;
    }
}