using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BioHimicHospitalLibrary
{
    public class CheckStringClass
    {
        /// <summary>
        ///     Проверка входных данных на соответствие условиям
        /// </summary>
        /// <param name="login">
        ///     Логин пользователя
        /// </param>
        /// <returns>   
        ///     true - в случае соответствия
        ///     исключение - в случае несоответсвия
        ///</returns>
        public bool LoginCheck(string login)
        {
            string correctSymbols = "abcdefghijklmnopqrstuvwxyz0123456789-_.";
            login = login.ToLower();
            if (!login.All(x => correctSymbols.Contains(x)))
            {
                return false;
            }
            if (login == String.Empty)
            {
                return false;
            }
            if (login.EndsWith("."))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Проверка входных данных на соответствие условиям
        /// </summary>
        /// <param name="password">
        ///     Пароль пользователя
        /// </param>
        /// <returns>   
        ///     true - в случае соответствия
        ///     исключение - в случае несоответсвия
        ///</returns>
        public bool PasswordCheck(string password)
        {
            string correctSymbols = "abcdefghijklmnopqrstuvwxyz0123456789-_.";
            password = password.ToLower();
            if (!password.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Пароль содержит недопустимые символы");
            }
            if (password == String.Empty)
            {
                throw new Exception("Вы не ввели пароль");
            }
            return true;
        }
        /// <summary>
        /// Проверка на НЕ содержание спецсимволов в поле для имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns></returns>
        public static bool CorrectName(string name)
        {
            var input = name;
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"); ///проверка на спецсимволы
            if (name.Length < 2)
            {
                return false;
            }
            else if (hasSymbols.IsMatch(input))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка на НЕ содержание спецсимволов в поле для фамилии
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <returns></returns>
        public static bool CorrectSurName(string surname)
        {
            var input = surname;
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"); ///проверка на спецсимволы
            if (surname.Length < 2)
            {
                return false;
            }
            else if (hasSymbols.IsMatch(input))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool CorrectPhone(string phone)
        {
            var input = phone;
            var correctPhone = new Regex(@"^\+?[78][-\(]?\d{3}\)?-?\d{3}-?\d{2}-?\d{2}$");
            if (!correctPhone.IsMatch(input))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка на корректный номер паспорта
        /// </summary>
        /// <param name="pasportNum"></param>
        /// <returns></returns>
        public static bool CorrectPasportNum(string pasportNum)
        {

            var input = Convert.ToString(pasportNum);
            var correctNum = new Regex(@"^([0-9]{10})?$");
            if (!correctNum.IsMatch(input))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// проверка на правильность введенного для создания логина 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool CorrectLogin(string login)
        {
            var input = login;
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"); ///проверка на спецсимволы
            if (login.Length < 5)
            {
                return false;
            }
            else if (hasSymbols.IsMatch(input))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// проверка на корректноть создания пароля
        /// </summary>
        /// <param name="pass1"></param>
        /// <returns></returns>
        public static bool CorrectPassword(string pass1)
        {
            var input = pass1;
            var hasNumber = new Regex(@"[0-9]+"); ///проверка на наличие цифр
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"); ///проверка на спецсимволы
            var hasLowerChar = new Regex(@"[a-z]+");///проверка на наличие символов нижнего регистра
            var hasUpperChar = new Regex(@"[A-Z]+");///проверка на наличие символов верхнего регистра
            if (pass1.Length < 8)
            {
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasLowerChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasSymbols.IsMatch(input))
            {
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка на корректность почты
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CorrectMail(string email)
        {
            var trueMail = new Regex(@"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)"); ///проверка на правильность почты
            if (!trueMail.IsMatch(email))
            {
                return false;
            }
            return true;
        }
    }
}
