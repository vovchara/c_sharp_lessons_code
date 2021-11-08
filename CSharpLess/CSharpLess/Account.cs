using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess
{
    class Account
    {
        public event Action<AccountEventArgs> Notify = delegate { };

        //public delegate void AccountHandler(AccountEventArgs info);
        //public event AccountHandler Notify;

        //public delegate void AccountHandler(string message);
        //private event AccountHandler _notify;
        //public event AccountHandler Notify
        //{
        //    add
        //    {
        //        _notify += value;
        //        Console.WriteLine($"{value.Method.Name} добавлен");
        //    }
        //    remove
        //    {
        //        _notify -= value;
        //        Console.WriteLine($"{value.Method.Name} удален");
        //    }
        //}

        public Account(int sum)
        {
            Sum = sum;
        }
        // сумма на счете
        public int Sum { get; private set; }
        // добавление средств на счет
        public void Put(int sum)
        {
            Sum += sum;
            //if (Notify != null)
            //{
                //Notify($"На счет поступило: {sum}");
                var info = new AccountEventArgs("Пополнение", sum);
                Notify(info);
            //}
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                //if (Notify != null)
                //{
                    //Notify($"Со счета снято: {sum}");
                    var info = new AccountEventArgs("Снятие", sum);
                    Notify(info);
                //}
            }
            else
            {
                //if (Notify != null)
                //{
                    var info = new AccountEventArgs("Недостаточно денег. Возьми кредит под 0.0003%*!", sum);
                    Notify(info);
                    //Notify("Недостаточно денег. Возьми кредит под 0.0003%*!");
                //}
            }
        }
    }
}
