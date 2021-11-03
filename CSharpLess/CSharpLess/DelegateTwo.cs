using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess
{
    class DelegateTwo
    {
        delegate int Operation(int x, int y);

        public DelegateTwo()
        {
            // присваивание адреса метода через контруктор
            Operation del = Add; // делегат указывает на метод Add
            int result = del(4, 5); // фактически Add(4, 5)
            Console.WriteLine(result);

            del = Multiply; // теперь делегат указывает на метод Multiply
            result = del(4, 5); // фактически Multiply(4, 5)
            Console.WriteLine(result);

            var math = new MathQ();
            del = math.Sum;
            //del = new Operation(math.Sum);
            result = del(4, 5);
            //result = del.Invoke(4, 5); //the same
            Console.WriteLine(result);

            Console.Read();
        }
        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }
    }

    class MathQ
    {
        public int Sum(int x, int y) { return x + y; }
    }
}
