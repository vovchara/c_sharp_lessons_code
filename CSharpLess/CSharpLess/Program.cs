using System;

namespace CSharpLess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Predicate<int> isPositive = delegate (int x) { return x > 0; }; // the same
            Predicate<int> isPositive = x => x > 0;

            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));


            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var acc = new Account(100);
            acc.Notify += NotificationHandler;
            acc.Notify += DisplayRedMessage; //краще один хендлер а там можна писати кілька методів і т д
            acc.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Notify -= DisplayRedMessage;     // удаляем обработчик DisplayRedMessage
            //acc.Notify -= mess => Console.WriteLine("Привіт!: " + mess); //в такому випадку не можемо відписатись
            acc.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            Console.Read();
        }

        private static void NotificationHandler(AccountEventArgs message)
        {
            Console.WriteLine("Привіт!: " + message.Message + " Сумма:" + message.Sum);
        }

        private static void DisplayRedMessage(AccountEventArgs message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message.Message + " Сумма:" + message.Sum);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }
    }
}
