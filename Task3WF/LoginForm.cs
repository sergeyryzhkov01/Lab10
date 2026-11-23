using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Task1;
using Task4;

namespace Task3WF
{
    public partial class LoginForm : Form
    {
        private static readonly Color ErrorColor = Color.MistyRose;

        public LoginForm()
        {
            InitializeComponent();

            toolTipRules.AutoPopDelay = 30000;
            toolTipRules.InitialDelay = 300;
            toolTipRules.SetToolTip(textBoxLogin, Employee.LoginRules);
            toolTipRules.SetToolTip(textBoxPassword, Employee.PasswordRules);

            textBoxLogin.TextChanged += Field_Changed;
            textBoxPassword.TextChanged += Field_Changed;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            ResetHighlight();

            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                if (string.IsNullOrEmpty(login))
                    textBoxLogin.BackColor = ErrorColor;
                if (string.IsNullOrEmpty(password))
                    textBoxPassword.BackColor = ErrorColor;

                MessageBox.Show("Введите логин и пароль.", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                FocusFirstEmpty();
                return;
            }

            Employee user;
            bool success;

            try
            {
                success = Auth.TryLogin(login, password, out user);
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Не удалось прочитать данные: " + ex.Message, "Ошибка чтения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Нет доступа к папке с данными: " + ex.Message, "Ошибка чтения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!success)
            {
                textBoxLogin.BackColor = ErrorColor;
                textBoxPassword.BackColor = ErrorColor;
                MessageBox.Show("Неверный логин или пароль.", "Ошибка авторизации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.SelectAll();
                textBoxPassword.Focus();
                return;
            }

            MessageBox.Show(
                "Добро пожаловать, " + user.FullName + "!" + Environment.NewLine +
                "Должность: " + user.Position + Environment.NewLine +
                "Факультет: " + user.Faculty,
                "Авторизация выполнена", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }

        private void Field_Changed(object sender, EventArgs e)
        {
            ((Control)sender).ResetBackColor();
        }

        private void ClearFields()
        {
            textBoxLogin.Clear();
            textBoxPassword.Clear();
            checkBoxShowPassword.Checked = false;
            ResetHighlight();
            textBoxLogin.Focus();
        }

        private void ResetHighlight()
        {
            textBoxLogin.ResetBackColor();
            textBoxPassword.ResetBackColor();
        }

        private void FocusFirstEmpty()
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
                textBoxLogin.Focus();
            else
                textBoxPassword.Focus();
        }
    }
}
