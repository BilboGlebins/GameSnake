using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS
{
    public class Snake_Class
    {
        private List<int> snakeX = new List<int>();
        private List<int> snakeY = new List<int>();
        public bool end = true;
        private bool eat = false;
        private int EX;
        private int EY;
        private int endSnakeX;
        private int endSnakeY;
        public int max_x = 10;
        public int max_y = 10;
        public int b = 0;
        private double Time = 600;
        private string[,] mass = new string[20, 20];
        ConsoleKeyInfo сontrol = new ConsoleKeyInfo();
        char hero = '#';
        int s_x, s_y;
        int f_x, f_y;
        Random rand = new Random();

        public Snake_Class()
        {
            this.Сhoice();
            this.write_map();
            this.start_point();
            this.drawingn_map();
        }

        public void Сhoice()
        {
            Console.WriteLine("Выберите уровень сложности");
            Console.WriteLine("1 - 'Легко': поле - 10х10 / скорость - 'медленно'");
            Console.WriteLine("2 - 'Нормально': поле - 15х15 / скорость - 'нормальная'");
            Console.WriteLine("3 - 'Сложно': поле - 20х20 / скорость - 'быстрая'");
            ConsoleKeyInfo pole = Console.ReadKey();
            switch (pole.Key)
            {
                case ConsoleKey.D1:
                    max_x = 10;
                    max_y = 10;
                    b = 400;
                    break;
                case ConsoleKey.NumPad1:
                    max_x = 10;
                    max_y = 10;
                    b = 400; ;
                    break;
                case ConsoleKey.D2:
                    max_x = 15;
                    max_y = 15;
                    b = 250;
                    break;
                case ConsoleKey.NumPad2:
                    max_x = 15;
                    max_y = 15;
                    b = 250;
                    break;
                case ConsoleKey.D3:
                    max_x = 20;
                    max_y = 20;
                    b = 100;
                    break;
                case ConsoleKey.NumPad3:
                    max_x = 20;
                    max_y = 20;
                    b = 100;
                    break;
                default:
                    break;
            }
            Console.Clear();
        }

        public void write_map()
        {
            for (int i = 0; i < max_x; i++)
            {
                for (int j = 0; j < max_y; j++)
                {
                    mass[i, j] = " ";
                }
            }
        }

        public void drawingn_map()
        {
            for (int i = 0; i < max_x; i++)
            {
                for (int j = 0; j < max_y; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(mass[i, j]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void clear_map()
        {
            for (int i = 0; i < max_x; i++)
            {
                for (int j = 0; j < max_y; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" ");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void start_point()
        {
            do
            {
                s_x = rand.Next(0, max_x);
                s_y = rand.Next(0, max_y);
                f_x = rand.Next(0, max_x);
                f_y = rand.Next(0, max_y);
            }
            while (s_x == f_x || s_x == f_y || s_y == f_y || s_y == f_x);
            snakeX.Add(s_x);
            snakeY.Add(s_y);

            mass[snakeX[0], snakeY[0]] = hero.ToString();
            mass[f_x, f_y] = "+";
        }

        public void drawing_heros()
        {
            Console.SetCursorPosition(f_y, f_x);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("+");

            for (int i = snakeY.Count - 1; i >= 0; --i)
            {
                Console.SetCursorPosition(snakeY[i], snakeX[i]);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("#");
            }
        }

        private void revers()
        {
            endSnakeX = snakeX[snakeX.Count - 1];
            endSnakeY = snakeY[snakeY.Count - 1];
            for (int i = snakeX.Count - 1; i > 0; --i)
            {
                snakeX[i] = snakeX[i - 1];
                snakeY[i] = snakeY[i - 1];
            }
        }

        public void snake_control()
        {
            if (сontrol.Key == ConsoleKey.Q || Console.KeyAvailable == true)
            {
                сontrol = Console.ReadKey();
            }
            switch (сontrol.Key)
            {
                case ConsoleKey.UpArrow:
                    if (snakeX[0] > 0)
                    { revers(); snakeX[0]--; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (snakeY[0] > 0)
                    { revers(); snakeY[0]--; }
                    break;
                case ConsoleKey.DownArrow:
                    if (snakeX[0] < max_x - 1)
                    { revers(); snakeX[0]++; }
                    break;
                case ConsoleKey.RightArrow:
                    if (snakeY[0] < max_y - 1)
                    { revers(); snakeY[0]++; }
                    break;
                default:
                    break;
            }
            // Console.Clear();
            Eat();
            add_cell();
            //this.write_map();
        }

        private void Eat()
        {
            if (eat)
            {
                Time = Time - 1;
                if (EY == endSnakeY && EX == endSnakeX)
                {
                    snakeY.Add(endSnakeY);
                    snakeX.Add(endSnakeX);
                    eat = false;
                }
            }
        }

        private void add_cell()
        {
            if (snakeY.Count == snakeX.Count)
            {
                write_map();
                mass[f_x, f_y] = "+";
                for (int i = 0; i < snakeX.Count; ++i)
                {
                    mass[snakeX[i], snakeY[i]] = hero.ToString();
                }
            }
        }

        public void respawn_fruit()
        {
            System.Threading.Thread.Sleep(b);
            if (snakeX[0] == f_x && snakeY[0] == f_y)
            {
                eat = true;
                EX = f_x;
                EY = f_y;
                do
                {
                    f_x = rand.Next(0, max_x);
                    f_y = rand.Next(0, max_y);
                } while (snakeX[0] == f_x || snakeX[0] == f_y || snakeY[0] == f_y || snakeY[0] == f_x);
            }
        }

        public void Game_Over()
        {
            for (int i = snakeX.Count - 1; i > 0; --i)
            {
                if (i > 0)
                {
                    if (snakeX[0] == snakeX[i] && snakeY[0] == snakeY[i])
                    {
                        Console.WriteLine();
                        Console.WriteLine("   Дорогие друзья, ВСЁ!    ");
                        Console.WriteLine("___________________________");
                        Console.WriteLine("ТУ ТУ ТУ ТУРУ ТУРУ ТУ ТУ...");
                        Console.WriteLine("        Directed by        ");
                        Console.WriteLine("      Robert B. Weide      ");
                        Console.WriteLine();
                        end = false;
                        break;
                    }
                }
            }
        }
    }
}
