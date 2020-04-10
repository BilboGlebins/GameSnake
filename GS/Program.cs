using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS
{
    class Program
    {
        static void Main(string[] args)
        {
            string res;
            do
            {
                Snake_Class Game_Snake = new Snake_Class();
                Console.CursorVisible = false;
                do
                {
                    Game_Snake.drawing_heros();
                    Game_Snake.respawn_fruit();
                    Game_Snake.clear_map();
                    Game_Snake.snake_control();
                    Console.WriteLine();
                    Game_Snake.Game_Over();
                }
                while (Game_Snake.end);
                {
                    Console.WriteLine("Сыграете еще раз? (1 - да / 0 - нет)");
                    res = Console.ReadLine();
                    if (res == "0")
                    {
                        Console.WriteLine("________________________________");
                        Console.WriteLine("Нажмите любую кнопку чтобы выйти");
                        Console.WriteLine("Прощайте");
                    }
                }
            }
            while (res == "1");

            Console.ReadLine();
        }
    }
}
