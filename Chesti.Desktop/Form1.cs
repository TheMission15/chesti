namespace Chesti.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "RUNNNNNN";
            pictureBox1.Image = Image.FromFile("HeavyHammer.jpeg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Bye Bye")
            {
                Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

            if (BackColor == Color.Blue)
            {
                BackColor = Color.Red;
                label1.Text = "Blue";
                label1.ForeColor = Color.Black;
            }
            else
            {
                BackColor = Color.Blue;
                label1.Text = "Red";
                label1.ForeColor = Color.White;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\raulc\\source\\repos\\Chesti\\Chesti.Console\\bin\\Debug\\net9.0\\Chesti.Console.exe");
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
