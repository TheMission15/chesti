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
            StandardBtn = new RadioButton();
            ItemWeight = new TextBox();
            GroupList = new CheckedListBox();
            SubmitBtn = new Button();
            label2 = new Label();
            NewBtn = new RadioButton();
            ImprovedBtn = new RadioButton();
            EliteBtn = new RadioButton();
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
            ItemName.TextChanged += ItemName_TextChanged;
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
            // StandardBtn
            // 
            StandardBtn.AutoSize = true;
            StandardBtn.BackColor = SystemColors.Control;
            StandardBtn.Location = new Point(234, 118);
            StandardBtn.Name = "StandardBtn";
            StandardBtn.Size = new Size(90, 24);
            StandardBtn.TabIndex = 2;
            StandardBtn.TabStop = true;
            StandardBtn.Tag = Rarity.Standard;
            StandardBtn.Text = "Standard";
            StandardBtn.UseVisualStyleBackColor = false;
            // 
            // ItemWeight
            // 
            ItemWeight.Location = new Point(401, 115);
            ItemWeight.Name = "ItemWeight";
            ItemWeight.PlaceholderText = "Enter Weight";
            ItemWeight.Size = new Size(125, 27);
            ItemWeight.TabIndex = 3;
            // 
            // GroupList
            // 
            GroupList.FormattingEnabled = true;
            GroupList.Items.AddRange(new object[] { "Power", "Speed", "Range", "Close", "Magic", "Anti" });
            GroupList.Location = new Point(578, 115);
            GroupList.Name = "GroupList";
            GroupList.Size = new Size(150, 136);
            GroupList.TabIndex = 4;
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
            // NewBtn
            // 
            NewBtn.AutoSize = true;
            NewBtn.BackColor = SystemColors.Control;
            NewBtn.Location = new Point(234, 163);
            NewBtn.Name = "NewBtn";
            NewBtn.Size = new Size(60, 24);
            NewBtn.TabIndex = 7;
            NewBtn.TabStop = true;
            NewBtn.Tag = Rarity.New;
            NewBtn.Text = "New";
            NewBtn.UseVisualStyleBackColor = false;
            // 
            // ImprovedBtn
            // 
            ImprovedBtn.AutoSize = true;
            ImprovedBtn.BackColor = SystemColors.Control;
            ImprovedBtn.Location = new Point(234, 206);
            ImprovedBtn.Name = "ImprovedBtn";
            ImprovedBtn.Size = new Size(94, 24);
            ImprovedBtn.TabIndex = 8;
            ImprovedBtn.TabStop = true;
            ImprovedBtn.Tag = Rarity.Improved;
            ImprovedBtn.Text = "Improved";
            ImprovedBtn.UseVisualStyleBackColor = false;
            // 
            // EliteBtn
            // 
            EliteBtn.AutoSize = true;
            EliteBtn.BackColor = SystemColors.Control;
            EliteBtn.Location = new Point(234, 256);
            EliteBtn.Name = "EliteBtn";
            EliteBtn.Size = new Size(59, 24);
            EliteBtn.TabIndex = 9;
            EliteBtn.TabStop = true;
            EliteBtn.Tag = Rarity.Elite;
            EliteBtn.Text = "Elite";
            EliteBtn.UseVisualStyleBackColor = false;
            // 
            // AddItemMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(EliteBtn);
            Controls.Add(ImprovedBtn);
            Controls.Add(NewBtn);
            Controls.Add(label2);
            Controls.Add(SubmitBtn);
            Controls.Add(GroupList);
            Controls.Add(ItemWeight);
            Controls.Add(StandardBtn);
            Controls.Add(label1);
            Controls.Add(ItemName);
            Name = "AddItemMenu";
            Text = "New Item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ItemName;
        private Label label1;
        private RadioButton StandardBtn;
        private TextBox ItemWeight;
        private CheckedListBox GroupList;
        private Button SubmitBtn;
        private Label label2;
        private RadioButton NewBtn;
        private RadioButton ImprovedBtn;
        private RadioButton EliteBtn;

    }
}