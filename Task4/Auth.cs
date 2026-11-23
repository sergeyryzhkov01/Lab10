using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Task1;

namespace Task4
{
    public static class Auth
    {
        private const string DateFormat = "yyyy-MM-dd";
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public static string Folder
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees"); }
        }

        public static void Register(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException("employee", "Сотрудник не задан.");

            Require(employee.FullName, "ФИО не задано.", "FullName");
            Require(employee.Position, "Значение поля «Должность» не выбрано.", "Position");
            Require(employee.Faculty, "Значение поля «Факультет» не выбрано.", "Faculty");
            Require(employee.Gender, "Значение поля «Пол» не выбрано.", "Gender");
            if (employee.BirthDate == default(DateTime))
                throw new FieldException("Дата рождения не задана.", "BirthDate");
            Employee.CheckLogin(employee.Login);
            Employee.CheckPassword(employee.Password);

            string path = GetPath(employee.Login);
            if (File.Exists(path))
                throw new FieldException("Пользователь с таким логином уже существует.", "Login");

            Directory.CreateDirectory(Folder);

            string[] lines =
            {
                "FullName=" + employee.FullName,
                "Position=" + employee.Position,
                "Faculty=" + employee.Faculty,
                "Gender=" + employee.Gender,
                "BirthDate=" + employee.BirthDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                "Login=" + employee.Login,
                "Password=" + employee.Password,
                "RegistrationDate=" + employee.RegistrationDate.ToString(DateTimeFormat, CultureInfo.InvariantCulture)
            };

            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        public static bool TryLogin(string login, string password, out Employee user)
        {
            user = null;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return false;

            try
            {
                Employee.CheckLogin(login);
            }
            catch (ArgumentException)
            {
                return false;
            }

            string path = GetPath(login);
            if (!File.Exists(path))
                return false;

            Employee loaded = Load(path);
            if (!string.Equals(loaded.Password, password, StringComparison.Ordinal))
                return false;

            user = loaded;
            return true;
        }

        private static Employee Load(string path)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            foreach (string line in File.ReadAllLines(path, Encoding.UTF8))
            {
                int index = line.IndexOf('=');
                if (index <= 0)
                    continue;
                data[line.Substring(0, index)] = line.Substring(index + 1);
            }

            try
            {
                Employee employee = new Employee();
                employee.FullName = data["FullName"];
                employee.Position = data["Position"];
                employee.Faculty = data["Faculty"];
                employee.Gender = data["Gender"];
                employee.BirthDate = DateTime.ParseExact(data["BirthDate"], DateFormat, CultureInfo.InvariantCulture);
                employee.Login = data["Login"];
                employee.Password = data["Password"];
                employee.RegistrationDate = DateTime.ParseExact(data["RegistrationDate"], DateTimeFormat, CultureInfo.InvariantCulture);
                return employee;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is FormatException || ex is KeyNotFoundException)
                    throw new InvalidDataException("Файл данных пользователя повреждён.", ex);
                throw;
            }
        }

        private static string GetPath(string login)
        {
            return Path.Combine(Folder, login + ".txt");
        }

        private static void Require(string value, string message, string field)
        {
            if (string.IsNullOrEmpty(value))
                throw new FieldException(message, field);
        }
    }
}
