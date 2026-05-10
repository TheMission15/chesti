using Chesti.Core.Model;
using static Chesti.Core.DataManager;

namespace ItemAdder.Add_Pages
{
    public partial class AddItemMenu : Form
    {
        public bool AllowSubmit = false;
        public string ItmName = "";
        public int ItmWeight = 0;
        public List<Group> groups = [];
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
                groups = [];
                string grouping = "";
                int randomInt = 0;
                if (GroupList.CheckedItems.Count == 0)
                {
                    label1.Text = "it works";
                    groups.Add(Group.Freestyle);
                    grouping += $"{groups[0]}, ";
                }
                else
                {
                    foreach (var cItem in GroupList.CheckedItems)
                    {
                        if (Enum.TryParse<Group>(cItem.ToString(), out Group group))
                        {
                            groups.Add(group);
                        }
                        grouping += $"{groups[randomInt]}, ";
                        randomInt++;
                    }
                }

                label1.Text = $"{ItmName}, {InRarity}, {ItmWeight}, {grouping}";
                Item item = new(ItmName, ItmWeight, (Rarity)InRarity!, groups);
                AddItem(item);
            }
            else { label1.Text = "WRONG"; }
        }
    }
}
