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
            FreestyleBtn = new RadioButton();
            PowerBtn = new RadioButton();
            SpeedBtn = new RadioButton();
            RangeBtn = new RadioButton();
            SkillPower = new TextBox();
            ElementList = new CheckedListBox();
            ModernBtn = new RadioButton();
            MagicBtn = new RadioButton();
            CloseBtn = new RadioButton();
            SubmitBtn = new Button();
            SkillSpeed = new TextBox();
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
            // FreestyleBtn
            // 
            FreestyleBtn.AutoSize = true;
            FreestyleBtn.BackColor = SystemColors.Control;
            FreestyleBtn.Location = new Point(397, 143);
            FreestyleBtn.Name = "FreestyleBtn";
            FreestyleBtn.Size = new Size(88, 24);
            FreestyleBtn.TabIndex = 13;
            FreestyleBtn.TabStop = true;
            FreestyleBtn.Tag = Chesti.Core.Model.Group.Freestyle;
            FreestyleBtn.Text = "Freestyle";
            FreestyleBtn.UseVisualStyleBackColor = false;
            // 
            // PowerBtn
            // 
            PowerBtn.AutoSize = true;
            PowerBtn.BackColor = SystemColors.Control;
            PowerBtn.Location = new Point(397, 173);
            PowerBtn.Name = "PowerBtn";
            PowerBtn.Size = new Size(70, 24);
            PowerBtn.TabIndex = 12;
            PowerBtn.TabStop = true;
            PowerBtn.Tag = Chesti.Core.Model.Group.Power;
            PowerBtn.Text = "Power";
            PowerBtn.UseVisualStyleBackColor = false;
            // 
            // SpeedBtn
            // 
            SpeedBtn.AutoSize = true;
            SpeedBtn.BackColor = SystemColors.Control;
            SpeedBtn.Location = new Point(397, 205);
            SpeedBtn.Name = "SpeedBtn";
            SpeedBtn.Size = new Size(72, 24);
            SpeedBtn.TabIndex = 11;
            SpeedBtn.TabStop = true;
            SpeedBtn.Tag = Chesti.Core.Model.Group.Speed;
            SpeedBtn.Text = "Speed";
            SpeedBtn.UseVisualStyleBackColor = false;
            // 
            // RangeBtn
            // 
            RangeBtn.AutoSize = true;
            RangeBtn.BackColor = SystemColors.Control;
            RangeBtn.Location = new Point(397, 235);
            RangeBtn.Name = "RangeBtn";
            RangeBtn.Size = new Size(72, 24);
            RangeBtn.TabIndex = 10;
            RangeBtn.TabStop = true;
            RangeBtn.Tag = Chesti.Core.Model.Group.Range;
            RangeBtn.Text = "Range";
            RangeBtn.UseVisualStyleBackColor = false;
            // 
            // SkillPower
            // 
            SkillPower.Location = new Point(196, 136);
            SkillPower.Name = "SkillPower";
            SkillPower.PlaceholderText = "Enter Power";
            SkillPower.Size = new Size(125, 27);
            SkillPower.TabIndex = 14;
            // 
            // checkedListBox1
            // 
            ElementList.FormattingEnabled = true;
            ElementList.Items.AddRange(new object[] { "Neutral", "Fire", "Water", "Lightning", "Nature", "Ice", "Anti" });
            ElementList.Location = new Point(640, 143);
            ElementList.Name = "checkedListBox1";
            ElementList.Size = new Size(111, 158);
            ElementList.TabIndex = 15;
            // 
            // ModernBtn
            // 
            ModernBtn.AutoSize = true;
            ModernBtn.BackColor = SystemColors.Control;
            ModernBtn.Location = new Point(397, 325);
            ModernBtn.Name = "ModernBtn";
            ModernBtn.Size = new Size(82, 24);
            ModernBtn.TabIndex = 18;
            ModernBtn.TabStop = true;
            ModernBtn.Tag = Chesti.Core.Model.Group.Modern;
            ModernBtn.Text = "Modern";
            ModernBtn.UseVisualStyleBackColor = false;
            // 
            // MagicBtn
            // 
            MagicBtn.AutoSize = true;
            MagicBtn.BackColor = SystemColors.Control;
            MagicBtn.Location = new Point(397, 295);
            MagicBtn.Name = "MagicBtn";
            MagicBtn.Size = new Size(71, 24);
            MagicBtn.TabIndex = 17;
            MagicBtn.TabStop = true;
            MagicBtn.Tag = Chesti.Core.Model.Group.Magic;
            MagicBtn.Text = "Magic";
            MagicBtn.UseVisualStyleBackColor = false;
            // 
            // CloseBtn
            // 
            CloseBtn.AutoSize = true;
            CloseBtn.BackColor = SystemColors.Control;
            CloseBtn.Location = new Point(397, 265);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(66, 24);
            CloseBtn.TabIndex = 16;
            CloseBtn.TabStop = true;
            CloseBtn.Tag = Chesti.Core.Model.Group.Close;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = false;
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
            SkillSpeed.Location = new Point(196, 172);
            SkillSpeed.Name = "SkillSpeed";
            SkillSpeed.PlaceholderText = "Enter Speed";
            SkillSpeed.Size = new Size(125, 27);
            SkillSpeed.TabIndex = 20;
            // 
            // AddSkillMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            ClientSize = new Size(800, 450);
            Controls.Add(SkillSpeed);
            Controls.Add(SubmitBtn);
            Controls.Add(ModernBtn);
            Controls.Add(MagicBtn);
            Controls.Add(CloseBtn);
            Controls.Add(ElementList);
            Controls.Add(SkillPower);
            Controls.Add(FreestyleBtn);
            Controls.Add(PowerBtn);
            Controls.Add(SpeedBtn);
            Controls.Add(RangeBtn);
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
        private RadioButton FreestyleBtn;
        private RadioButton PowerBtn;
        private RadioButton SpeedBtn;
        private RadioButton RangeBtn;
        private TextBox SkillPower;
        private CheckedListBox ElementList;
        private RadioButton ModernBtn;
        private RadioButton MagicBtn;
        private RadioButton CloseBtn;
        private Button SubmitBtn;
        private TextBox SkillSpeed;
    }
}