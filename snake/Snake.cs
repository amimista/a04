using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace snake
{
    public class Snake
    {
      //  public List<Entity> body;
        public RingBuffer<Entity> body;
        private Entity head;
        private Entity body1;
        private Entity body2;
        private Entity body3;
        private Entity rear;

        private ConsoleColor color;
        private ConsoleColor Bodycolor = ConsoleColor.Green;

     

        public Snake(int length, int startingLeft, int startingTop, ConsoleColor color)
        {
            RingBuffer<Entity> body = new RingBuffer<Entity>(5);
            head = new Entity(startingLeft, startingTop);
            body1 = new Entity(startingLeft-1, startingTop);
            body2 = new Entity(startingLeft-2, startingTop);
            body3 = new Entity(startingLeft-3, startingTop);
            rear = new Entity(startingLeft-4, startingTop);
            body.Add(head);
            body.Add(body1);
            body.Add(body2);
            body.Add(body3);
            body.Add(rear);
           


        }

        public void Display()
        {

            Boolean firstTime = false;
            
                    

                        Console.SetCursorPosition(head.Left, head.Top);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                        Console.ResetColor();




                    Console.SetCursorPosition(body1.Left, body1.Top);
                    Console.BackgroundColor = Bodycolor;
                        Console.Write("  ");
                        Console.ResetColor();

            Console.SetCursorPosition(body2.Left, body2.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();

            Console.SetCursorPosition(body3.Left, body3.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();

            Console.SetCursorPosition(rear.Left, rear.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();


        }
       
        public void Move(String direction)
        {
            if (direction == "right")
            {
                Console.SetCursorPosition(rear.Left, rear.Top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Green;
                rear.Left = body3.Left;
                rear.Top = body3.Top;
                body3.Left = body2.Left;
                body3.Top = body2.Top;



                body2.Left = head.Left;
                body2.Top = head.Top;


                body1.Left = head.Left;
                body1.Top = head.Top;

                Console.BackgroundColor = ConsoleColor.Red;
                head.Left = head.Left + 2;
                Console.SetCursorPosition(head.Left, head.Top);
                Console.Write("   ");



            }
            else if (direction == "up") {
                Console.SetCursorPosition(rear.Left, rear.Top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Green;
                rear.Left = body3.Left;
                rear.Top = body3.Top;
                body3.Left = body2.Left;
                body3.Top = body2.Top;



                body2.Left = head.Left;
                body2.Top = head.Top;


                body1.Left = head.Left;
                body1.Top = head.Top;

               




                Console.BackgroundColor = ConsoleColor.Red;
                head.Top = head.Top -2;
                Console.SetCursorPosition(head.Left, head.Top);
                Console.Write("   ");


            }







        }

        




        
        public bool CheckIsDead(List<Entity> obstacleList)
        {
            bool result = false;
            if ((head.Top < 0 || head.Top >= Console.WindowHeight - 1) || (head.Left < 0 || head.Left >= Console.WindowWidth - 3))
            {
                result = true;
            }
            else
            {
                foreach (Entity e in obstacleList)
                {
                    if (head.Top == e.Top  && head.Left==e.Top)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }


        public static void generateAreana()
        {
            //Creates areana
            int j = 0;
            for (int i = 0; i < 150; i++)
            {
                Console.SetCursorPosition(20 + j, 10);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                j++;
            }
            int l = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(20 + j, 10 + l);
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("  ");
                l++;
            }
            j = 0;
            for (int i = 0; i < 29; i++)
            {
                Console.SetCursorPosition(20, 10 + j);
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("  ");
                j++;
            }
            l = 0;
            for (int i = 0; i < 150; i++)
            {
                Console.SetCursorPosition(20 + l, 10 + j);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  ");
                l++;
            }





        }

    }
}
