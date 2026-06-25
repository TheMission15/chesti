using Chesti.Core.Model;

namespace ItemAdder.Add_Pages
{
    partial class AddItemMenu
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
            ItemName = new TextBox();
            label1 = new Label();
            ItemWeight = new TextBox();
            GroupList = new CheckedListBox();
            SubmitBtn = new Button();
            label2 = new Label();
            ModernBtn = new RadioButton();
            MagicBtn = new RadioButton();
            CloseBtn = new RadioButton();
            FreestyleBtn = new RadioButton();
            PowerBtn = new RadioButton();
            SpeedBtn = new RadioButton();
            RangeBtn = new RadioButton();
            SuspendLayout();
            // 
            // ItemName
            // 
            ItemName.Location = new Point(52, 115);
            ItemName.Multiline = true;
            ItemName.Name = "ItemName";
            ItemName.PlaceholderText = "Enter Name";
            ItemName.Size = new Size(125, 27);
            ItemName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(222, 41);
            label1.TabIndex = 1;
            label1.Text = "Enter New Item";
            // 
            // ItemWeight
            // 
            ItemWeight.Location = new Point(52, 167);
            ItemWeight.Name = "ItemWeight";
            ItemWeight.PlaceholderText = "Enter Weight";
            ItemWeight.Size = new Size(125, 27);
            ItemWeight.TabIndex = 3;
            // 
            // GroupList
            // 
            GroupList.FormattingEnabled = true;
            GroupList.Items.AddRange(new object[] { "Power", "Speed", "Range", "Close", "Magic", "Modern" });
            GroupList.Location = new Point(578, 115);
            GroupList.Name = "GroupList";
            GroupList.Size = new Size(150, 136);
            GroupList.TabIndex = 5;
            // 
            // SubmitBtn
            // 
            SubmitBtn.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubmitBtn.ForeColor = Color.SpringGreen;
            SubmitBtn.Location = new Point(578, 336);
            SubmitBtn.Name = "SubmitBtn";
            SubmitBtn.Size = new Size(177, 70);
            SubmitBtn.TabIndex = 5;
            SubmitBtn.Text = "Submit";
            SubmitBtn.UseVisualStyleBackColor = true;
            SubmitBtn.Click += SubmitBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(52, 69);
            label2.Name = "label2";
            label2.Size = new Size(368, 30);
            label2.TabIndex = 6;
            label2.Text = "Enter Name, Rarity, Weight, Group(s)\r\n";
            // 
            // ModernBtn
            // 
            ModernBtn.AutoSize = true;
            ModernBtn.BackColor = SystemColors.Control;
            ModernBtn.Location = new Point(280, 297);
            ModernBtn.Name = "ModernBtn";
            ModernBtn.Size = new Size(82, 24);
            ModernBtn.TabIndex = 25;
            ModernBtn.TabStop = true;
            ModernBtn.Tag = Group.Modern;
            ModernBtn.Text = "Modern";
            ModernBtn.UseVisualStyleBackColor = false;
            // 
            // MagicBtn
            // 
            MagicBtn.AutoSize = true;
            MagicBtn.BackColor = SystemColors.Control;
            MagicBtn.Location = new Point(280, 267);
            MagicBtn.Name = "MagicBtn";
            MagicBtn.Size = new Size(71, 24);
            MagicBtn.TabIndex = 24;
            MagicBtn.TabStop = true;
            MagicBtn.Tag = Group.Magic;
            MagicBtn.Text = "Magic";
            MagicBtn.UseVisualStyleBackColor = false;
            // 
            // CloseBtn
            // 
            CloseBtn.AutoSize = true;
            CloseBtn.BackColor = SystemColors.Control;
            CloseBtn.Location = new Point(280, 237);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(66, 24);
            CloseBtn.TabIndex = 23;
            CloseBtn.TabStop = true;
            CloseBtn.Tag = Group.Close;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = false;
            // 
            // FreestyleBtn
            // 
            FreestyleBtn.AutoSize = true;
            FreestyleBtn.BackColor = SystemColors.Control;
            FreestyleBtn.Location = new Point(280, 115);
            FreestyleBtn.Name = "FreestyleBtn";
            FreestyleBtn.Size = new Size(88, 24);
            FreestyleBtn.TabIndex = 22;
            FreestyleBtn.TabStop = true;
            FreestyleBtn.Tag = Group.Freestyle;
            FreestyleBtn.Text = "Freestyle";
            FreestyleBtn.UseVisualStyleBackColor = false;
            // 
            // PowerBtn
            // 
            PowerBtn.AutoSize = true;
            PowerBtn.BackColor = SystemColors.Control;
            PowerBtn.Location = new Point(280, 145);
            PowerBtn.Name = "PowerBtn";
            PowerBtn.Size = new Size(70, 24);
            PowerBtn.TabIndex = 21;
            PowerBtn.TabStop = true;
            PowerBtn.Tag = Group.Power;
            PowerBtn.Text = "Power";
            PowerBtn.UseVisualStyleBackColor = false;
            // 
            // SpeedBtn
            // 
            SpeedBtn.AutoSize = true;
            SpeedBtn.BackColor = SystemColors.Control;
            SpeedBtn.Location = new Point(280, 177);
            SpeedBtn.Name = "SpeedBtn";
            SpeedBtn.Size = new Size(72, 24);
            SpeedBtn.TabIndex = 20;
            SpeedBtn.TabStop = true;
            SpeedBtn.Tag = Group.Speed;
            SpeedBtn.Text = "Speed";
            SpeedBtn.UseVisualStyleBackColor = false;
            // 
            // RangeBtn
            // 
            RangeBtn.AutoSize = true;
            RangeBtn.BackColor = SystemColors.Control;
            RangeBtn.Location = new Point(280, 207);
            RangeBtn.Name = "RangeBtn";
            RangeBtn.Size = new Size(72, 24);
            RangeBtn.TabIndex = 19;
            RangeBtn.TabStop = true;
            RangeBtn.Tag = Group.Range;
            RangeBtn.Text = "Range";
            RangeBtn.UseVisualStyleBackColor = false;
            // 
            // AddItemMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(ModernBtn);
            Controls.Add(MagicBtn);
            Controls.Add(CloseBtn);
            Controls.Add(FreestyleBtn);
            Controls.Add(PowerBtn);
            Controls.Add(SpeedBtn);
            Controls.Add(RangeBtn);
            Controls.Add(label2);
            Controls.Add(SubmitBtn);
            Controls.Add(GroupList);
            Controls.Add(ItemWeight);
            Controls.Add(label1);
            Controls.Add(ItemName);
            Name = "AddItemMenu";
            Text = "New Item";
            Load += AddItemMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ItemName;
        private Label label1;
        private TextBox ItemWeight;
        private CheckedListBox GroupList;
        private Button SubmitBtn;
        private Label label2;
        private RadioButton ModernBtn;
        private RadioButton MagicBtn;
        private RadioButton CloseBtn;
        private RadioButton FreestyleBtn;
        private RadioButton PowerBtn;
        private RadioButton SpeedBtn;
        private RadioButton RangeBtn;
    }
}