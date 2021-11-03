using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess
{
    class DelegatesExample
    {
        public DelegatesExample()
        {
            // создаем банковский счет
            Account account = new Account(200);
            // Добавляем в делегат ссылку на метод Show_Message
            // а сам делегат передается в качестве параметра метода RegisterHandler
            account.RegisterHandler(Show_Message);
            account.RegisterHandler(Color_Message);
            // Два раза подряд пытаемся снять деньги
            account.Withdraw(100);
            account.Withdraw(150);

            // Удаляем делегат
            account.UnregisterHandler(Color_Message);
            account.Withdraw(50);

            Console.WriteLine("================");

            Account account2 = new Account(300);
            account2.Withdraw(50);
        }

        private void Show_Message(String message)
        {
            Console.WriteLine(message);
            //Kyivstar.SendSms(message); //for example
        }

        private void Color_Message(string message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }
    }
}
