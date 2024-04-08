using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Auto
{
    class Program
    {
        private static object _lock = new object();
        private static int posicionA = 0;
        private static int posicionB = 0;
        private static int posicionC = 0;
        private static int posicionD = 0;
        private static bool carreraTerminada = false;
        private static string ganador = "";

        static void Main(string[] args)
        {
            Thread autoAHilo = new Thread(AutoA);
            Thread autoBHilo = new Thread(AutoB);
            Thread autoCHilo = new Thread(AutoC);
            Thread autoDHilo = new Thread(AutoD);

            autoAHilo.Start();
            autoBHilo.Start();
            autoCHilo.Start();
            autoDHilo.Start();

            autoAHilo.Join(); // Espera a que el hilo del auto A termine
            autoBHilo.Join(); // Espera a que el hilo del auto B termine
            autoCHilo.Join(); // Espera a que el hilo del auto C termine
            autoDHilo.Join(); // Espera a que el hilo del auto D termine

            Console.WriteLine("¡La carrera ha terminado!");
            Console.WriteLine($"El ganador es el auto {ganador}.");
        }

        static void AutoA()
        {
            while (posicionA < Console.WindowWidth - 1)
            {
                lock (_lock)
                {
                    Console.SetCursorPosition(posicionA, 0);
                    Console.Write(' ');

                    posicionA++;
                    Console.SetCursorPosition(posicionA, 0);
                    Console.Write('A');
                }

                if (posicionA >= Console.WindowWidth - 1 && !carreraTerminada)
                {
                    ganador = "A";
                    carreraTerminada = true;
                }

                Thread.Sleep(50);
            }
        }

        static void AutoB()
        {
            while (posicionB < Console.WindowWidth - 1)
            {
                lock (_lock)
                {
                    Console.SetCursorPosition(posicionB, 1);
                    Console.Write(' ');

                    posicionB++;
                    Console.SetCursorPosition(posicionB, 1);
                    Console.Write('B');
                }

                if (posicionB >= Console.WindowWidth - 1 && !carreraTerminada)
                {
                    ganador = "B";
                    carreraTerminada = true;
                }

                Thread.Sleep(50);
            }
        }

        static void AutoC()
        {
            while (posicionC < Console.WindowWidth - 1)
            {
                lock (_lock)
                {
                    Console.SetCursorPosition(posicionC, 2);
                    Console.Write(' ');

                    posicionC++;
                    Console.SetCursorPosition(posicionC, 2);
                    Console.Write('C');
                }

                if (posicionC >= Console.WindowWidth - 1 && !carreraTerminada)
                {
                    ganador = "C";
                    carreraTerminada = true;
                }

                Thread.Sleep(50);
            }
        }

        static void AutoD()
        {
            while (posicionD < Console.WindowWidth - 1)
            {
                lock (_lock)
                {
                    Console.SetCursorPosition(posicionD, 3);
                    Console.Write(' ');

                    posicionD++;
                    Console.SetCursorPosition(posicionD, 3);
                    Console.Write('D');
                }

                if (posicionD >= Console.WindowWidth - 1 && !carreraTerminada)
                {
                    ganador = "D";
                    carreraTerminada = true;
                }
                Thread.Sleep(50);
            }
        }
    }
}
