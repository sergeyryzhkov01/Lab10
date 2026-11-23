using System;
using System.Windows.Forms;
using Task2WF;
using Task3WF;

namespace WF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            using (RegistrationForm form = new RegistrationForm())
            {
                form.ShowDialog(this);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using (LoginForm form = new LoginForm())
            {
                form.ShowDialog(this);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
