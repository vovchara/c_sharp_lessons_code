using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess
{
    public class Account
    {
        // Объявляем делегат
        public delegate void AccountStateHandler(string message);
        // Создаем переменную делегата
        AccountStateHandler _del;

        // Регистрируем делегат
        public void RegisterHandler(AccountStateHandler del)
        {
            _del += del;
        }
        // Отмена регистрации делегата
        public void UnregisterHandler(AccountStateHandler del)
        {
            _del -= del; // удаляем делегат
        }

        // Далее остальные строки класса Account
        private int _sum; // Переменная для хранения суммы

        public Account(int sum)
        {
            _sum = sum;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                if (_del != null)
                {
                    _del($"З вашого рахунку знято {sum} грн");
                }
            }
            else
            {
                if (_del != null)
                {
                    _del($"Недостатньо коштів для проведення операції. Баланс {_sum}");
                }
            }
        }
    }
}
