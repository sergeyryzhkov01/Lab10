namespace Task2WF
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelFullName = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.labelFaculty = new System.Windows.Forms.Label();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.labelBirth = new System.Windows.Forms.Label();
            this.panelBirth = new System.Windows.Forms.Panel();
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.labelLoginRules = new System.Windows.Forms.Label();
            this.labelPasswordRules = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelBirth.SuspendLayout();
            this.SuspendLayout();
            //
            // labelFullName
            //
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(20, 23);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(34, 13);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "ФИО";
            //
            // textBoxFullName
            //
            this.textBoxFullName.Location = new System.Drawing.Point(170, 20);
            this.textBoxFullName.MaxLength = 100;
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(220, 20);
            this.textBoxFullName.TabIndex = 1;
            //
            // labelPosition
            //
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(20, 58);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(66, 13);
            this.labelPosition.TabIndex = 2;
            this.labelPosition.Text = "Должность";
            //
            // comboBoxPosition
            //
            this.comboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Location = new System.Drawing.Point(170, 55);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(220, 21);
            this.comboBoxPosition.TabIndex = 3;
            //
            // labelFaculty
            //
            this.labelFaculty.AutoSize = true;
            this.labelFaculty.Location = new System.Drawing.Point(20, 93);
            this.labelFaculty.Name = "labelFaculty";
            this.labelFaculty.Size = new System.Drawing.Size(57, 13);
            this.labelFaculty.TabIndex = 4;
            this.labelFaculty.Text = "Факультет";
            //
            // comboBoxFaculty
            //
            this.comboBoxFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(170, 90);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(220, 21);
            this.comboBoxFaculty.TabIndex = 5;
            //
            // labelGender
            //
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(20, 128);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(27, 13);
            this.labelGender.TabIndex = 6;
            this.labelGender.Text = "Пол";
            //
            // comboBoxGender
            //
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(170, 125);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(220, 21);
            this.comboBoxGender.TabIndex = 7;
            //
            // labelBirth
            //
            this.labelBirth.AutoSize = true;
            this.labelBirth.Location = new System.Drawing.Point(20, 166);
            this.labelBirth.Name = "labelBirth";
            this.labelBirth.Size = new System.Drawing.Size(86, 13);
            this.labelBirth.TabIndex = 8;
            this.labelBirth.Text = "Дата рождения";
            //
            // panelBirth
            //
            this.panelBirth.Controls.Add(this.dateTimePickerBirth);
            this.panelBirth.Location = new System.Drawing.Point(170, 160);
            this.panelBirth.Name = "panelBirth";
            this.panelBirth.Padding = new System.Windows.Forms.Padding(2);
            this.panelBirth.Size = new System.Drawing.Size(220, 26);
            this.panelBirth.TabIndex = 9;
            //
            // dateTimePickerBirth
            //
            this.dateTimePickerBirth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBirth.Location = new System.Drawing.Point(2, 2);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(216, 20);
            this.dateTimePickerBirth.TabIndex = 0;
            //
            // labelLogin
            //
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(20, 208);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(38, 13);
            this.labelLogin.TabIndex = 10;
            this.labelLogin.Text = "Логин";
            //
            // textBoxLogin
            //
            this.textBoxLogin.Location = new System.Drawing.Point(170, 205);
            this.textBoxLogin.MaxLength = 20;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(220, 20);
            this.textBoxLogin.TabIndex = 11;
            //
            // labelPassword
            //
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(20, 243);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(45, 13);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Пароль";
            //
            // textBoxPassword
            //
            this.textBoxPassword.Location = new System.Drawing.Point(170, 240);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(220, 20);
            this.textBoxPassword.TabIndex = 13;
            this.textBoxPassword.UseSystemPasswordChar = true;
            //
            // checkBoxShowPassword
            //
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(170, 267);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(105, 17);
            this.checkBoxShowPassword.TabIndex = 14;
            this.checkBoxShowPassword.Text = "Показать пароль";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            //
            // labelLoginRules
            //
            this.labelLoginRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLoginRules.Location = new System.Drawing.Point(420, 20);
            this.labelLoginRules.Name = "labelLoginRules";
            this.labelLoginRules.Padding = new System.Windows.Forms.Padding(6);
            this.labelLoginRules.Size = new System.Drawing.Size(280, 90);
            this.labelLoginRules.TabIndex = 15;
            //
            // labelPasswordRules
            //
            this.labelPasswordRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPasswordRules.Location = new System.Drawing.Point(420, 125);
            this.labelPasswordRules.Name = "labelPasswordRules";
            this.labelPasswordRules.Padding = new System.Windows.Forms.Padding(6);
            this.labelPasswordRules.Size = new System.Drawing.Size(280, 125);
            this.labelPasswordRules.TabIndex = 16;
            //
            // buttonRegister
            //
            this.buttonRegister.Location = new System.Drawing.Point(20, 315);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(150, 30);
            this.buttonRegister.TabIndex = 17;
            this.buttonRegister.Text = "Зарегистрировать";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            //
            // buttonClear
            //
            this.buttonClear.Location = new System.Drawing.Point(185, 315);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 30);
            this.buttonClear.TabIndex = 18;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            //
            // buttonClose
            //
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(320, 315);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 30);
            this.buttonClose.TabIndex = 19;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            //
            // RegistrationForm
            //
            this.AcceptButton = this.buttonRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(724, 366);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.comboBoxPosition);
            this.Controls.Add(this.labelFaculty);
            this.Controls.Add(this.comboBoxFaculty);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.labelBirth);
            this.Controls.Add(this.panelBirth);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.checkBoxShowPassword);
            this.Controls.Add(this.labelLoginRules);
            this.Controls.Add(this.labelPasswordRules);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация сотрудника";
            this.panelBirth.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Label labelFaculty;
        private System.Windows.Forms.ComboBox comboBoxFaculty;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.Panel panelBirth;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.Label labelLoginRules;
        private System.Windows.Forms.Label labelPasswordRules;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonClose;
    }
}