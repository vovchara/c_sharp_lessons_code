using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var mainThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"::: Main thread id = {mainThreadId} :::");

            //FirstTaskExample();
            //SecondTaskExample();
            //ThirdTaskExample();
            //RunSynchronouslyTaskExample();
            //TaskNotWaited();
            //TaskWaited();
            //NestedTasks();
            //NestedAttachedTasks();
            //TasksArray();
            //TaskArrayWait();
            //TasksWithResult();
            //ContinuationTask();
            //ContinuationTaskWithResult();
            ContinuationSeveralTasks();
            //ParallelExample();
            //ParallelFor();
            //ParallelForeach();
            //ParallelBreak();
            //CancelExample();
            //CancelExternalFunc();
            //CancelParallel();

            Console.ReadLine();
        }

        private static void FirstTaskExample()
        {
            Task task = new Task(() => Console.WriteLine("Hello First Task!"));
            task.Start();
        }

        private static void SecondTaskExample()
        {
            Task task = Task.Factory.StartNew(() => Console.WriteLine("Hello Second Task!"));
        }

        private static void ThirdTaskExample()
        {
            Task task = Task.Run(() => Console.WriteLine("Hello Third Task!"));
        }

        private static void RunSynchronouslyTaskExample()
        {
            var syncTask = new Task(() =>
            {
                Console.WriteLine($"Task {Task.CurrentId} (syncTask) executing on Thread {Thread.CurrentThread.ManagedThreadId}");
                long sum = 0;
                for (int ctr = 1; ctr <= 1000000000; ctr++)
                {
                    sum += ctr;
                }
                Console.WriteLine("Done.");
            });
            syncTask.RunSynchronously();
            //syncTask.Start(); //uncomment to see the difference
        }

        private static void TaskNotWaited()
        {
            Task.Run(Display);

            Console.WriteLine("Завершение метода Main");
        }
        private static void Display()
        {
            Console.WriteLine("Начало работы метода Display");
            Thread.Sleep(1000);
            Console.WriteLine("Завершение работы метода Display");
            //throw new Exception("AAAAAAAAAAAAA");
        }

        private static void TaskWaited()
        {
            var myTask = Task.Run(Display);
            myTask.Wait();

            Console.WriteLine("Завершение метода Main");
        }

        private static void NestedTasks()
        {
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                Console.WriteLine("Outer task starting...");
                var inner = Task.Factory.StartNew(() =>  // вложенная задача
                {
                    Console.WriteLine("Inner task starting...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task finished.");
                });
            });
            outer.Wait(); // ожидаем выполнения внешней задачи
            Console.WriteLine("End of Main");
        }

        private static void NestedAttachedTasks()
        {
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                Console.WriteLine("Outer task starting...");
                var inner = Task.Factory.StartNew(() =>  // вложенная задача
                {
                    Console.WriteLine("Inner task starting...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task finished.");
                }, TaskCreationOptions.AttachedToParent); //attach parameter
            });
            outer.Wait(); // ожидаем выполнения внешней задачи
            Console.WriteLine("End of Main");
        }

        private static void TasksArray()
        {
            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task"))
            };
            foreach (var t in tasks1)
                t.Start();

            Task[] tasks2 = new Task[3];
            int j = 1;
            for (int i = 0; i < tasks2.Length; i++)
                tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));

            Console.WriteLine("Завершение метода Main");
        }

        private static void TaskArrayWait()
        {
            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => { Thread.Sleep(1000); Console.WriteLine("Second Task"); }),
                new Task(() => Console.WriteLine("Third Task"))
            };
            foreach (var t in tasks1)
                t.Start();
            Task.WaitAll(tasks1); // ожидаем завершения задач 
            //Task.WaitAny(tasks1); //uncomment to wait only one task

            Console.WriteLine("Завершение метода Main");
        }

        private static void TasksWithResult()
        {
            Task<int> task1 = Task.Run(() => Factorial(6));
            var factRes = task1.Result;

            Console.WriteLine($"Факториал числа 6 равен {factRes}"); // ожидаем получение результата

            Task<Book> task2 = Task.Run(() =>
            {
                var book = new Book { Title = "Война и мир", Author = "Л. Толстой" };
                return book;
            });

            Book b = task2.Result;  // ожидаем получение результата
            Console.WriteLine($"Название книги: {b.Title}, автор: {b.Author}");
        }
        private static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Thread.Sleep(1000);
            return result;
        }
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
        }

        private static void ContinuationTask()
        {
            Task zmolotyTask = new Task(() => {
                Console.WriteLine($"Molem coffe. Id первой задачи: {Task.CurrentId}");
                Thread.Sleep(2000);
            });

            //var coffeTask = zmolotyTask.ContinueWith(zvarytyTask).ContinueWith(nalytyTask).ContinueWith(podatyTask);
            //zmolotyTask.Start();
            //coffeTask.Wait();

            // задача продолжения
            Task coffeTask = zmolotyTask.ContinueWith(ZvarytyTask).ContinueWith(NalytyTask);
            zmolotyTask.Start();
            //coffeTask.Start(); // exception!!

            // ждем окончания второй задачи
            coffeTask.Wait();
            Console.WriteLine("Завершение метода Main");
        }
        private static void ZvarytyTask(Task t)
        {
            Console.WriteLine($"Varym coffe. Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Varym coffe. Id предыдущей задачи: {t.Id}");
            Thread.Sleep(2000);
        }

        private static void NalytyTask(Task t)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Nalyvaem coffe");
        }

        private static void ContinuationTaskWithResult()
        {
            var task1 = new Task<int>(() => Sum(4, 5));

            // задача продолжения
            var task2 = task1.ContinueWith(sumTsk => Display3(sumTsk.Result)).ContinueWith(sumTsk => SendSumSms(sumTsk.Result));

            task1.Start();

            // ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("End of Main");
        }
        static int Sum(int a, int b)
        {
            Console.WriteLine("Sum was calculated.");
            return a + b;
        }

        static int Display3(int sum)
        {
            Console.WriteLine($"Sum: {sum}");
            return sum;
        }

        static void SendSumSms(int sum)
        {
            Console.WriteLine($"Sending sms with sum = {sum}");
        }

        private static void ContinuationSeveralTasks()
        {
            Task task1 = new Task(() => {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            // задача продолжения
            Task task2 = task1.ContinueWith(Display4);

            Task task3 = task1.ContinueWith((Task t) =>
            {
                Thread.Sleep(1000); //якщо в цьому вложеному таску буде код який трішки довше працює, тоді task4.Wait(); дочекається лиш одну гілку розгалуження.
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            Task task4 = task2.ContinueWith((Task t) =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            task1.Start();

            //task4.Wait(); //так не вірно очікувати, бо це ігнорує task3, і не буде його чекати, бо то інша гілка вложених тасків.
            Task.WaitAll(task4, task3); //отак ми можемо дочекатись виконання обох гілок. Але такий код уже виглядає заплутаним та не позорим. Це просто приклад.
            Console.WriteLine("End of Main");
        }
        static void Display4(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
        }

        private static void ParallelExample()
        {
            Parallel.Invoke(Display5,
            () =>
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Конец задачи {Task.CurrentId}");
            },
            () => Factorial2(5));
        }
        static void Display5()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId} Display");
            Thread.Sleep(3000);
            Console.WriteLine($"Конец задачи {Task.CurrentId} Display");
        }
        static void Factorial2(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId} Факториал");
            Thread.Sleep(3000);
            Console.WriteLine($"Конец задачи { Task.CurrentId} Результат {result}");
        }

        private static void ParallelFor()
        {
            Parallel.For(1, 10, Factorial3);
        }
        static void Factorial3(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(3000);
        }

        private static void ParallelForeach()
        {
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 }, Factorial3);
        }

        private static void ParallelBreak()
        {
            ParallelLoopResult result = Parallel.For(1, 10, Factorial4);

            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
        }
        static void Factorial4(int x, ParallelLoopState pls)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                if (i == 5)
                    pls.Break();
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
        }

        private static void CancelExample()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            int number = 6;

            Task task1 = new Task(() =>
            {
                int result = 1;
                for (int i = 1; i <= number; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }

                    result *= i;
                    Console.WriteLine($"Факториал числа {i} равен {result}");
                    Thread.Sleep(3000);
                }
            });
            task1.Start();

            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s.ToUpper() == "Y")
                cancelTokenSource.Cancel();
        }

        private static void CancelExternalFunc()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task1 = new Task(() => Factorial5(5, token));
            task1.Start();

            Console.WriteLine("Введите Y для отмены операции или любой другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s.ToUpper() == "Y")
                cancelTokenSource.Cancel();
        }
        static void Factorial5(int x, CancellationToken token)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                //token.ThrowIfCancellationRequested(); //можна ще таким чином. Тоді викинеться OperationCancelledException і ми його можемо відловити через try catch з того місця де запустили цей таск
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                result *= i;
                Console.WriteLine($"Факториал числа {i} равен {result}");
                Thread.Sleep(3000);
            }
        }

        private static void CancelParallel()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task.Run(() =>
            {
                Thread.Sleep(100);
                cancelTokenSource.Cancel();
            });

            try
            {
                //Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, new ParallelOptions { CancellationToken = token }, Factorial6);
                // или так
                Parallel.For(1, 20, new ParallelOptions { CancellationToken = token }, Factorial6);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операция прервана");
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            Console.ReadLine();
        }
        static void Factorial6(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(1000);
        }
    }
}
