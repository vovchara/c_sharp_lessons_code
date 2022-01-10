using System;
using System.Threading;

namespace CSharpLess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //FirstExample();
            //CreateThreadExample();
            //CreateThreadWithParamsExample();
            //SharedResExample();
            //SyncLockExample();
            //SyncMonitorExample();
            //AutoResetEventExample();
            //MutexExample();
            //SemaphoreExample();
            //TimerExample();
            //ThreadPoolExample();

            Console.ReadLine();
        }

        private static void FirstExample()
        {
            // получаем текущий поток
            Thread t = Thread.CurrentThread;

            //получаем имя потока
            Console.WriteLine($"Имя потока: {t.Name}");
            t.Name = "Метод Main";
            Console.WriteLine($"Имя потока: {t.Name}");

            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");

            // получаем домен приложения
            Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");
        }

        private static void CreateThreadExample()
        {
            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
        }

        private static void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
        }

        private static void CreateThreadWithParamsExample()
        {
            int number = 4;
            // создаем новый поток
            Thread myThread = new Thread(new ParameterizedThreadStart(Count2));
            myThread.Start(number);

            //Thread myThread = new Thread(() => Count2(number)); //will do the same
            //myThread.Start(); //will do the same

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
        }

        private static void Count2(object x)
        {
            for (int i = 1; i < 9; i++)
            {
                int n = (int)x;

                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * n);
                Thread.Sleep(400);
            }
        }

        static int x = 0;
        private static void SharedResExample()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count3);
                myThread.Name = "Поток " + i.ToString();
                myThread.Start();
            }
        }
        private static void Count3()
        {
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
        }

        static object locker = new object();
        private static void SyncLockExample()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count4);
                myThread.Name = "Поток " + i.ToString();
                myThread.Start();
            }
        }
        private static void Count4()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);
                }
            }
        }

        private static void SyncMonitorExample()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count5);
                myThread.Name = $"Поток {i.ToString()}";
                myThread.Start();
            }
        }
        private static void Count5()
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }
            finally
            {
                if (acquiredLock) Monitor.Exit(locker);
            }
        }

        static AutoResetEvent waitHandler = new AutoResetEvent(true); //true вказує що по дефолту він в сигнальному стані (розлочений)
        private static void AutoResetEventExample()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count6);
                myThread.Name = $"Поток {i.ToString()}";
                myThread.Start();
            }
        }
        private static void Count6()
        {
            waitHandler.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            waitHandler.Set();
        }

        static Mutex mutexObj = new Mutex();
        private static void MutexExample()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count7);
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }
        }
        private static void Count7()
        {
            mutexObj.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }

        private static void SemaphoreExample()
        {
            for (int i = 1; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }
        }
        class Reader
        {
            // создаем семафор
            static Semaphore sem = new Semaphore(3, 3);
            Thread myThread;
            int count = 3;// счетчик чтения

            public Reader(int i)
            {
                myThread = new Thread(Read);
                myThread.Name = $"Читатель {i.ToString()}";
                myThread.Start();
            }

            public void Read()
            {
                while (count > 0)
                {
                    sem.WaitOne();

                    Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                    Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                    Thread.Sleep(1000);

                    Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                    sem.Release();

                    count--;
                    Thread.Sleep(1000);
                }
            }
        }

        private static void TimerExample()
        {
            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count8);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 2000);
        }
        private static void Count8(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }

        private static void ThreadPoolExample()
        {
            int nWorkerThreads;
            int nCompletionThreads;
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionThreads);
            Console.WriteLine("Максимальное количество потоков: " + nWorkerThreads + "\nПотоков ввода-вывода доступно: " + nCompletionThreads);
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(JobForAThread);
            }
                
            Thread.Sleep(3000);
        }
        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"цикл {i}, выполнение внутри потока из пула {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(50);
            }
        }
    }
}
