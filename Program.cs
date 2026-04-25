using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valasz = "";

            do
            {
                Game();

                Console.Clear();

                Console.Write("Szeretné újrafuttatni?(Igen/Nem):");
                valasz = Console.ReadLine();
            }
            while (valasz.ToLower() == "igen");
        }
        static (int x,int y) Ujetel((int x, int y) etelpozicio, List<(int x, int y)> testpozicio, List<(int x, int y)> akadalypozicio)
        {
           
            Random rnd = new Random();

            int x;
            int y;

            do
            {
                x = rnd.Next(0, Console.WindowWidth);
                y = rnd.Next(0, Console.WindowHeight - 2);
            }
            while (x == etelpozicio.x && y == etelpozicio.y || testpozicio.Any(p => p.x == x && p.y == y)
            || akadalypozicio.Any(a => a.x == x && a.y == y));

            return (x,y);
        }
        static (int x, int y) Ujakadaly((int x,int y) etelpozicio,List<(int x,int y)> testpozicio, List<(int x, int y)> akadalypozicio)
        {
            
            Random rnd = new Random();

            int x;
            int y;

            do
            {
                x = rnd.Next(0, Console.WindowWidth);
                y = rnd.Next(0, Console.WindowHeight - 2);
            }
            while(x == etelpozicio.x && y == etelpozicio.y || testpozicio.Any(p => p.x == x && p.y == y)
            || akadalypozicio.Any(a => a.x == x && a.y == y));




            return (x, y);
        }
        static void Game()
        {
            int point = 0;


            List<char> test = new List<char>()
            {
                '#','#','#'
            };

            List<(int x, int y)> pontok = new List<(int x, int y)>
            {
                (7,3),
                (6,3),
                (5,3)
            };

            List<char> akadaly = new List<char>();
           
            List<(int x, int y)> akadalypozicio = new List<(int x, int y)>();

            char etel = 'O';

            (int x, int y) etelpozicio = (20, 10);

           
            

            Console.CursorVisible = false;
            ConsoleKey irany = ConsoleKey.RightArrow;
            

            while (true)
            {
                Console.Clear();

                Console.SetCursorPosition(0, 0); 

                Console.Write($"Pont: {point}");

                Console.SetCursorPosition(0, 1); 

                Console.Write(new string('-', Console.WindowWidth));

                foreach (var p in pontok)
                {
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write('#');
                }

                Console.SetCursorPosition(etelpozicio.x, etelpozicio.y);
                Console.Write(etel);

                foreach(var a in akadalypozicio)
                {
                    Console.SetCursorPosition(a.x, a.y);
                    Console.Write('H');
                }


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow: if (irany != ConsoleKey.LeftArrow) irany = ConsoleKey.RightArrow; break;
                        case ConsoleKey.LeftArrow: if (irany != ConsoleKey.RightArrow) irany = ConsoleKey.LeftArrow; break;
                        case ConsoleKey.UpArrow: if (irany != ConsoleKey.DownArrow) irany = ConsoleKey.UpArrow; break;
                        case ConsoleKey.DownArrow: if (irany != ConsoleKey.UpArrow) irany = ConsoleKey.DownArrow; break;
                    }
                }

                (int x, int y) head = pontok[0];

                switch (irany)
                {
                    case ConsoleKey.RightArrow:
                        head.x++;
                        break;

                    case ConsoleKey.LeftArrow:
                        head.x--;
                        break;

                    case ConsoleKey.UpArrow:
                        head.y--;
                        break;

                    case ConsoleKey.DownArrow:
                        head.y++;
                        break;
                }

                pontok.Insert(0, head);

                if (head.x == etelpozicio.x && head.y == etelpozicio.y)
                {
                    etelpozicio = Ujetel(etelpozicio,pontok,akadalypozicio);
                    point++;

                    if(point >= 5)
                    {
                        akadalypozicio.Add(Ujakadaly(etelpozicio,pontok,akadalypozicio));
                    }
                }
                else
                {
                    pontok.RemoveAt(pontok.Count - 1);
                }

                if(head.x < 0 || head.x >= Console.WindowWidth || head.y < 0 || head.y >= Console.WindowHeight - 2)
                {

                    GameOver(point);
                    return;
                }

                for (int i = 1; i < pontok.Count - 1; i++)
                {
                    if (head == pontok[i])
                    {
                        GameOver(point);
                        return;
                    }
                }

                foreach(var a in akadalypozicio)
                {
                    if(head == a)
                    {
                        GameOver(point);
                        return;
                    }
                }

                Thread.Sleep(120);
            }
            
        }
        static void GameOver(int point)
        {
            Console.Clear(); int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;
            Console.SetCursorPosition(centerX - 6, centerY);
            Console.Write("Vesztettél!");
            Console.SetCursorPosition(centerX - 8, centerY + 1);
            Console.Write($"Pontszám: {point}");
            Thread.Sleep(2000);
        }

        
    }
}
