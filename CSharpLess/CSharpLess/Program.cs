using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLess
{
    class Program
    {
        static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("=== Hello World! ===");

            //FactorialAsyncExample();
            //FactorialAsyncFile();
            //FactorialAsyncRun();
            //FactorialAsyncLambda();
            //AsyncWithParams();
            //AsyncWithParamsAndResult();
            await ReturnTaskExample();

            //DoAsyncWorkWithArgAndReturn();

            Console.WriteLine("=== Bye World! ===");
            Console.ReadLine();
        }

        static void FactorialAsyncExample()
        {
            FactorialAsync();   // вызов асинхронного метода

            Console.WriteLine("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Квадрат числа равен {n * n}");
        }
        // определение асинхронного метода
        static async void FactorialAsync()
        {
            Console.WriteLine($"Начало метода FactorialAsync {Thread.CurrentThread.ManagedThreadId}"); // выполняется синхронно
            await Task.Run(() => Factorial()); // выполняется асинхронно
            Console.WriteLine($"Конец метода FactorialAsync {Thread.CurrentThread.ManagedThreadId}");
        }
        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал 6 равен {result}");
        }

        static void FactorialAsyncFile()
        {
            ReadWriteAsync();

            Console.WriteLine("Некоторая работа");
        }
        static async void ReadWriteAsync()
        {
            string s = "One step at a time";

            // hello.txt - файл, который будет записываться и считываться
            using (StreamWriter writer = new StreamWriter("hello.txt", true))
            {
                await writer.WriteLineAsync(s);  // асинхронная запись в файл
                //writer.Write(s);
            }
            using (StreamReader reader = new StreamReader("hello.txt"))
            {
                string result = await reader.ReadToEndAsync();  // асинхронное чтение из файла
                //int result = reader.Read();
                Console.WriteLine(result);
            }
        }

        // определение асинхронного метода
        static async void FactorialAsyncRun()
        {
            await Task.Run(() => Factorial()); // вызов асинхронной операции
        }

        static async void FactorialAsyncLambda()
        {
            await Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(8000);
                Console.WriteLine($"Факториал равен {result}");
            });
        }

        static void AsyncWithParams()
        {
            FactorialAsync(5);
            FactorialAsync(6);
            Console.WriteLine("Некоторая работа");
        }
        // определение асинхронного метода
        static async void FactorialAsync(int n)
        {
            await Task.Run(() => Factorial(n));
        }
        static void Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Thread.Sleep(5000);
            Console.WriteLine($"Факториал {n} равен {result}");
        }
                
        static void AsyncWithParamsAndResult()
        {
            FactorialAsync2(5);
            FactorialAsync2(6);
        }
        // определение асинхронного метода
        static async void FactorialAsync2(int n)
        {
            var x = await Task.Run(() => Factorial3(n));
            Console.WriteLine($"Факториал равен {x}");
        }
        static int Factorial3(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        static async Task ReturnTaskExample()
        {
            var sum = await CalculateSum(2, 2);
            var task1 = FactorialAsync3(sum);
            var task2 = FactorialAsync3(6);
            var task3 = FactorialAsync3(7);
            var sum2 = CalculateSum(1000, 3000);
            var arrr = new[] { task1, task2, task3, sum2 };
            await Task.WhenAll(arrr);
            Console.WriteLine($"Некоторая работа. {sum2.Result}");
        }
        static Random _rand = new Random();
        static async Task<int> CalculateSum(int a, int b)
        {
            Console.WriteLine("CALCULATING SUM!");
            return await Task.Run(() => a + b);
        }
        // определение асинхронного метода
        static async Task FactorialAsync3(int n)
        {
            await Task.Delay(_rand.Next(10,100));
            await Task.Run(() => Factorial4(n));
        }
        static void Factorial4(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал {n} равен {result}. Thread={Thread.CurrentThread.ManagedThreadId}");
        }

        private static void DoAsyncWorkWithArgAndReturn()
        {
            var tsk = OperationAsyncArgAndReturn(3);
            tsk.ContinueWith(t => Console.WriteLine($"Result : {t.Result}"));
        }
        private static async Task<double> OperationAsyncArgAndReturn(double argument)
        {
            return await Task.Run(() => Operation(argument));

            //return await Task<double>.Factory.StartNew(Operation, argument); //те саме що попередня стрічка, лиш доведеться Operation аргумент робити типом object

            //можемо також записати таким чином. В чому різниця - ми повертаємо ось цей перший таск,
            //замість того щоб дочекатись його тут, завернути результат в новий Task<double> і повернути його.
            //Результат роботи буде однаковий, просто на один завернутий таск менше.
            //return Task<double>.Factory.StartNew(Operation, argument);

            //без ретурн не можемо записати, бо в такому випадку буде повертатись просто Task, а не Task<double>
            //await Task<double>.Factory.StartNew(Operation, argument);
        }
        private static double Operation(double argument)
        {
            Thread.Sleep(2000);
            return argument * argument;
        }
    }
}
