using System;
using System.Text.RegularExpressions;

namespace Task1
{
    public class FieldException : ArgumentException
    {
        private readonly string message;

        public FieldException(string message, string field) : base(message, field)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return message; }
        }
    }

    public class Employee
    {

        public static readonly string[] Positions =
        {
            "Лаборант", "Ассистент", "Старший преподаватель", "Доцент",
            "Профессор", "Заведующий кафедрой", "Декан", "Специалист учебного отдела"
        };

        public static readonly string[] Faculties =
        {
            "Информационных технологий", "Экономический", "Юридический",
            "Машиностроительный", "Строительный", "Гуманитарный"
        };

        public static readonly string[] Genders = { "Мужской", "Женский" };

        public const string LoginRules =
            "Логин:\r\n" +
            "• 4–20 символов\r\n" +
            "• латинские буквы, цифры и _\r\n" +
            "• начинается с буквы\r\n" +
            "• без пробелов";

        public const string PasswordRules =
            "Пароль:\r\n" +
            "• не менее 8 символов\r\n" +
            "• минимум одна цифра\r\n" +
            "• минимум одна заглавная латинская буква\r\n" +
            "• минимум один спецсимвол (!@#$%^&* и т.п.)\r\n" +
            "• только латиница, без пробелов";

        private string fullName;
        private string position;
        private string faculty;
        private string gender;
        private DateTime birthDate;
        private string login;
        private string password;

        public Employee()
        {
            RegistrationDate = DateTime.Now;
        }

        public Employee(string fullName, string position, string faculty, string gender,
                        DateTime birthDate, string login, string password) : this()
        {
            FullName = fullName;
            Position = position;
            Faculty = faculty;
            Gender = gender;
            BirthDate = birthDate;
            Login = login;
            Password = password;
        }

        public string FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new FieldException("ФИО не задано.", nameof(FullName));

                value = Regex.Replace(value.Trim(), @"\s+", " ");

                if (value.Length > 100)
                    throw new FieldException("ФИО не должно быть длиннее 100 символов.", nameof(FullName));
                if (!Regex.IsMatch(value, @"^\p{L}+([ \-]\p{L}+)*$"))
                    throw new FieldException("ФИО может содержать только буквы, пробелы и дефис.", nameof(FullName));
                if (value.IndexOf(' ') < 0)
                    throw new FieldException("Укажите фамилию и имя (отчество при наличии).", nameof(FullName));

                fullName = value;
            }
        }

        public string Position
        {
            get { return position; }
            set { position = CheckFromList(value, Positions, "Должность", nameof(Position)); }
        }

        public string Faculty
        {
            get { return faculty; }
            set { faculty = CheckFromList(value, Faculties, "Факультет", nameof(Faculty)); }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = CheckFromList(value, Genders, "Пол", nameof(Gender)); }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                DateTime today = DateTime.Today;
                if (value.Date > today)
                    throw new FieldException("Дата рождения не может быть в будущем.", nameof(BirthDate));

                int age = today.Year - value.Year;
                if (value.Date > today.AddYears(-age)) age--;

                if (age < 16 || age > 100)
                    throw new FieldException("Возраст сотрудника должен быть от 16 до 100 лет.", nameof(BirthDate));

                birthDate = value.Date;
            }
        }

        public string Login
        {
            get { return login; }
            set
            {
                CheckLogin(value);
                login = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                CheckPassword(value);
                password = value;
            }
        }

        public DateTime RegistrationDate { get; set; }

        public static void CheckLogin(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new FieldException("Логин не задан.", nameof(Login));
            if (value.Length < 4 || value.Length > 20)
                throw new FieldException("Длина логина должна быть от 4 до 20 символов.", nameof(Login));
            if (!Regex.IsMatch(value, "^[A-Za-z]"))
                throw new FieldException("Логин должен начинаться с латинской буквы.", nameof(Login));
            if (!Regex.IsMatch(value, "^[A-Za-z0-9_]+$"))
                throw new FieldException("Логин может содержать только латинские буквы, цифры и _ (без пробелов).", nameof(Login));
        }

        public static void CheckPassword(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new FieldException("Пароль не задан.", nameof(Password));
            if (value.Length < 8)
                throw new FieldException("Пароль должен содержать не менее 8 символов.", nameof(Password));

            bool hasDigit = false, hasUpper = false, hasSpecial = false;

            foreach (char c in value)
            {
                if (c == ' ' || char.IsWhiteSpace(c))
                    throw new FieldException("Пароль не должен содержать пробелов.", nameof(Password));
                if (c < '!' || c > '~')
                    throw new FieldException("Пароль может содержать только латинские буквы, цифры и спецсимволы.", nameof(Password));

                if (c >= '0' && c <= '9') hasDigit = true;
                else if (c >= 'A' && c <= 'Z') hasUpper = true;
                else if (!(c >= 'a' && c <= 'z')) hasSpecial = true;
            }

            if (!hasDigit)
                throw new FieldException("Пароль должен содержать хотя бы одну цифру.", nameof(Password));
            if (!hasUpper)
                throw new FieldException("Пароль должен содержать хотя бы одну заглавную латинскую букву.", nameof(Password));
            if (!hasSpecial)
                throw new FieldException("Пароль должен содержать хотя бы один спецсимвол.", nameof(Password));
        }

        private static string CheckFromList(string value, string[] list, string title, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new FieldException("Значение поля «" + title + "» не выбрано.", paramName);
            if (Array.IndexOf(list, value) < 0)
                throw new FieldException("Поле «" + title + "»: недопустимое значение.", paramName);
            return value;
        }
    }
}
