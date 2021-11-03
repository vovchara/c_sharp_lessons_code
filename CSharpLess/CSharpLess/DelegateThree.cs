using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess
{
    class DelegateThree
    {
        delegate void Message();
        private Message mes1;

        public DelegateThree()
        {
            mes1 = Hello;

            Subscribe();

            mes1(); // вызываются оба метода - Hello и HowAreYou
            mes1(); // вызываются оба метода - Hello и HowAreYou
            mes1(); // вызываются оба метода - Hello и HowAreYou
            mes1(); // вызываются оба метода - Hello и HowAreYou
        }

        private void Subscribe()
        {
            mes1 -= HowAreYou;
            mes1 += HowAreYou;
        }

        private void Hello()
        {
            Console.WriteLine("Hello");
            Subscribe();
        }
        private void HowAreYou()
        {
            Console.WriteLine("How are you?");
        }
    }
}
