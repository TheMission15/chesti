using Chesti.Core.Model;

namespace ItemAdder.Add_Pages
{
    public partial class AddItemMenu : Form
    {
        public bool AllowSubmit = false;
        public string ItmName = "";
        public int ItmWeight = 0;
        public Group?[] groups = new Group?[2];
        public Rarity? InRarity = null;
        
        public AddItemMenu()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is RadioButton rb && rb.Checked) { InRarity = (Rarity?)rb.Tag; }
            }
                if (GroupList.CheckedItems.Count <= 2 && int.TryParse(ItemWeight.Text, out ItmWeight) && InRarity != null) { AllowSubmit = true; }
            else { AllowSubmit = false; }
            ItmName = ItemName.Text;


            if (AllowSubmit)
            {
                for (int i = 0; i < GroupList.CheckedItems.Count; i++)
                {
                    groups[i] = (Group)GroupList.CheckedIndices[i];
                }
                label1.Text = $"{ItmName}, {InRarity}, {ItmWeight}, {groups[0]} {groups[1]}";
            }
            else { label1.Text = "WRONG"; }
            
        }

        private void GroupList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
