using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace intHndl
{
    class Program
    {
        static double[] bq = { 0 };
        static double[] tsk1 = { 1.1, 1.2, 1.3, 1.4 };
        static double[] tsk2 = { 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7 };
        static double[] tsk3 = { 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.8, 3.9 };
        static double[] tsk4 = { 4.1, 4.2, 4.3, 4.4, 4.5 };
        static int cbq = 0;
        public static void Main(string[] args)
        {
            int ln = tsk1.Length + tsk2.Length + tsk3.Length + tsk4.Length;

            Random rand = new Random();
            int quantum = rand.Next(1, 3);
            int si = rand.Next(1, 50);
            int hi = rand.Next(1, 50);
            int rb = rand.Next(si, 50);

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Quantum = " + quantum);
            Console.ResetColor();

            int count = 0;
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0;
            int ct1 = 1, ct2 = 2, ct3 = 3, ct4 = 4;

            while (count < ln)
            {
                if (cbq==1 && (t4 == tsk4.Length && t2 == tsk2.Length && t3 == tsk3.Length)||
                    cbq==2 && (t1 == tsk1.Length && t3 == tsk3.Length && t4 == tsk4.Length)||
                    cbq==3 && (t1 == tsk1.Length && t2 == tsk2.Length && t4 == tsk4.Length)||
                    cbq==4 && (t1 == tsk1.Length && t2 == tsk2.Length && t3 == tsk3.Length))
                {
                    break;
                }
                if (bq[0]!=0 && count == rb)
                {
                    runBQ();
                    count++;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\tBlocked que is as follows");
                Console.WriteLine("\t" + bq[0]);
                for (int i = 0; i < quantum; i++)
                    {
                    if (t1 < tsk1.Length && ct1 != cbq)
                    {

                        if (count == si)
                        {
                            softInterupt(tsk1[t1]);
                            t1++;
                            count++;
                            break;
                        }
                        if (count == hi)
                        {
                            hardInterupt();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("" + tsk1[t1]);
                        t1++;
                        count++;
                        Thread.Sleep(1000);
                    }
                    }

                    for (int i = 0; i < quantum; i++)
                    {
                    if (t2 < tsk2.Length && ct2 != cbq)
                    {

                        if (count == si)
                        {
                            softInterupt(tsk2[t2]);
                            t2++;
                            count++;
                            break;
                        }
                        if (count == hi)
                        {
                            hardInterupt();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("" + tsk2[t2]);
                        t2++;
                        count++;
                        Thread.Sleep(1000);
                    }
                    }

                    for (int i = 0; i < quantum; i++)
                    {
                    if (t3 < tsk3.Length && ct3 != cbq)
                    {
                        if (count == si)
                        {
                            softInterupt(tsk3[t3]);
                            t3++;
                            count++;
                            break;
                        }
                        if (count == hi)
                        {
                            hardInterupt();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("" + tsk3[t3]);
                        t3++;
                        count++;
                        Thread.Sleep(1000);

                    }
                    }

                for (int i = 0; i < quantum; i++)
                {

                    if (t4 < tsk4.Length && ct4 != cbq)
                    {
                        if (count == si)
                        {
                            softInterupt(tsk4[t4]);
                            t4++;
                            count++;
                            break;
                        }
                        if (count == hi)
                        {
                            hardInterupt();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("" + tsk4[t4]);
                        t4++;
                        count++;
                        Thread.Sleep(1000);
                    }
                }
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Cycle completed..");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nTasks completed..");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void softInterupt(double i)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Software interrupt occured..\nProcess " + i + " moved to blocked que");
            bq[0] = i;
            cbq = Convert.ToInt16(i);
            Thread.Sleep(500);
            return;
        }
        public static void hardInterupt()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hardware interrupt occured..\nPlease wait a while.");
            Thread.Sleep(5000);
            return;
        }

        public static void runBQ()
        {
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Executiong blocked que\n" + bq[0]);
            Console.ResetColor();
            bq[0] = 0;
            cbq = 0;
            Thread.Sleep(1000);
            return;
        }
    }
}
