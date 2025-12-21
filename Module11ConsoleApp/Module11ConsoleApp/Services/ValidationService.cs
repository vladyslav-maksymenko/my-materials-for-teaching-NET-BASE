using System.Text.RegularExpressions;
using Module11ConsoleApp.Models;

namespace Module11ConsoleApp.Services
{
    public static class ValidationService
    {
        // Завдання 6: ПІБ тільки англійські літери
        public static bool ValidateEnglishName(string name)
        {
            string pattern = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(name, pattern);
        }

        // Завдання 7: Вік тільки цифри
        public static bool ValidateAge(string age)
        {
            string pattern = @"^\d+$";
            return Regex.IsMatch(age, pattern);
        }

        // Завдання 8: Адреса тільки цифри та англійські літери
        public static bool ValidateAddress(string address)
        {
            string pattern = @"^[a-zA-Z0-9\s]+$";
            return Regex.IsMatch(address, pattern);
        }

        // Завдання 9: Email валідація
        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        // Завдання 10: Валідація реєстраційної форми
        public static (bool isValid, List<string> errors) ValidateRegistrationForm(RegistrationForm form)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(form.FirstName) || !ValidateEnglishName(form.FirstName))
            {
                errors.Add("Ім'я повинно містити тільки літери англійського алфавіту");
            }

            if (string.IsNullOrWhiteSpace(form.LastName) || !ValidateEnglishName(form.LastName))
            {
                errors.Add("Прізвище повинно містити тільки літери англійського алфавіту");
            }

            if (string.IsNullOrWhiteSpace(form.Age) || !ValidateAge(form.Age))
            {
                errors.Add("Вік повинен містити тільки цифри");
            }

            if (string.IsNullOrWhiteSpace(form.Email) || !ValidateEmail(form.Email))
            {
                errors.Add("Email має невірний формат");
            }

            if (string.IsNullOrWhiteSpace(form.Address) || !ValidateAddress(form.Address))
            {
                errors.Add("Адреса повинна містити тільки цифри та літери англійського алфавіту");
            }

            if (string.IsNullOrWhiteSpace(form.PostalCode) || !Regex.IsMatch(form.PostalCode, @"^\d+$"))
            {
                errors.Add("Індекс повинен містити тільки цифри");
            }

            // Перевірка телефону (формат: +380XXXXXXXXX або 0XXXXXXXXX)
            if (string.IsNullOrWhiteSpace(form.PhoneNumber) || 
                !Regex.IsMatch(form.PhoneNumber, @"^(\+380|0)\d{9}$"))
            {
                errors.Add("Номер телефону має невірний формат (формат: +380XXXXXXXXX або 0XXXXXXXXX)");
            }

            if (string.IsNullOrWhiteSpace(form.Profession))
            {
                errors.Add("Професія не може бути порожньою");
            }

            if (string.IsNullOrWhiteSpace(form.Password) || form.Password.Length < 6)
            {
                errors.Add("Пароль повинен містити мінімум 6 символів");
            }

            return (errors.Count == 0, errors);
        }
    }
}

