using System;

namespace CSharpLess
{
    class Delegates
    {
        public delegate void Message(); // 1. Объявляем делегат

        public Delegates()
        {
            Message mes; // 2. Создаем переменную делегата
            if (DateTime.Now.Hour < 12)
            {
                mes = GoodMorning; // 3. Присваиваем этой переменной адрес метода
            }
            else
            {
                mes = delegate
                {
                    Console.WriteLine("Good evening bro");
                };
            }

            //if (mes != null)
            //{
                //mes(); // 4. Вызываем метод
                //mes.Invoke();
            //}

            mes?.Invoke();
        }

        private void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        //private void GoodEvening()
        //{
        //    Console.WriteLine("Good Evening");
        //}
    }
}
