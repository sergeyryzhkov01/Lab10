using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Task1;
using Task4;

namespace Task2WF
{
    public partial class RegistrationForm : Form
    {
        private static readonly Color ErrorColor = Color.MistyRose;

        private Control firstError;

        public RegistrationForm()
        {
            InitializeComponent();

            comboBoxPosition.Items.AddRange(Employee.Positions);
            comboBoxFaculty.Items.AddRange(Employee.Faculties);
            comboBoxGender.Items.AddRange(Employee.Genders);

            labelLoginRules.Text = Employee.LoginRules;
            labelPasswordRules.Text = Employee.PasswordRules;

            dateTimePickerBirth.MaxDate = DateTime.Today;
            dateTimePickerBirth.Value = DateTime.Today.AddYears(-25);

            textBoxFullName.TextChanged += Field_Changed;
            textBoxLogin.TextChanged += Field_Changed;
            textBoxPassword.TextChanged += Field_Changed;
            comboBoxPosition.SelectedIndexChanged += Field_Changed;
            comboBoxFaculty.SelectedIndexChanged += Field_Changed;
            comboBoxGender.SelectedIndexChanged += Field_Changed;
            dateTimePickerBirth.ValueChanged += Field_Changed;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            ResetHighlight();

            Employee employee = new Employee();
            List<string> errors = new List<string>();

            Assign(() => employee.FullName = textBoxFullName.Text, errors);
            Assign(() => employee.Position = comboBoxPosition.SelectedItem as string, errors);
            Assign(() => employee.Faculty = comboBoxFaculty.SelectedItem as string, errors);
            Assign(() => employee.Gender = comboBoxGender.SelectedItem as string, errors);
            Assign(() => employee.BirthDate = dateTimePickerBirth.Value, errors);
            Assign(() => employee.Login = textBoxLogin.Text, errors);
            Assign(() => employee.Password = textBoxPassword.Text, errors);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (firstError != null)
                    firstError.Focus();
                return;
            }

            try
            {
                Auth.Register(employee);
            }
            catch (ArgumentException ex)
            {
                Highlight(ex.ParamName);
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (firstError != null)
                    firstError.Focus();
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Не удалось сохранить данные: " + ex.Message, "Ошибка записи",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Нет доступа к папке с данными: " + ex.Message, "Ошибка записи",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Пользователь «" + employee.Login + "» успешно зарегистрирован.", "Регистрация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFullName.Clear();
            textBoxLogin.Clear();
            textBoxPassword.Clear();
            comboBoxPosition.SelectedIndex = -1;
            comboBoxFaculty.SelectedIndex = -1;
            comboBoxGender.SelectedIndex = -1;
            dateTimePickerBirth.Value = DateTime.Today.AddYears(-25);
            checkBoxShowPassword.Checked = false;

            ResetHighlight();
            textBoxFullName.Focus();
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
            Control control = (Control)sender;
            if (control == dateTimePickerBirth)
                control = panelBirth;
            control.ResetBackColor();
        }

        private void Assign(Action action, List<string> errors)
        {
            try
            {
                action();
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
                Highlight(ex.ParamName);
            }
        }

        private void Highlight(string field)
        {
            Control control = GetControl(field);
            if (control == null)
                return;

            control.BackColor = ErrorColor;
            if (firstError == null)
                firstError = control;
        }

        private void ResetHighlight()
        {
            firstError = null;
            textBoxFullName.ResetBackColor();
            comboBoxPosition.ResetBackColor();
            comboBoxFaculty.ResetBackColor();
            comboBoxGender.ResetBackColor();
            panelBirth.ResetBackColor();
            textBoxLogin.ResetBackColor();
            textBoxPassword.ResetBackColor();
        }

        private Control GetControl(string field)
        {
            switch (field)
            {
                case "FullName": return textBoxFullName;
                case "Position": return comboBoxPosition;
                case "Faculty": return comboBoxFaculty;
                case "Gender": return comboBoxGender;
                case "BirthDate": return panelBirth;
                case "Login": return textBoxLogin;
                case "Password": return textBoxPassword;
                default: return null;
            }
        }
    }
}
