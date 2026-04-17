using ItemAdder.Add_Pages;

namespace ItemAdder
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void StartUp_Load(object sender, EventArgs e)
        {

        }

        private void AddSkill_Click(object sender, EventArgs e)
        {
            Form form = new AddSkillMenu();
            form.Show();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            Form form = new AddItemMenu();
            form.Show();
        }

        private void WelcomeLbl_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
