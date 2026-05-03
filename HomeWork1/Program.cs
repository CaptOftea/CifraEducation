namespace TicTacToe
{
     public class Program
    {
        static void Main()
        {
            string[,] Matrix = new string[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Matrix[i, j] = ("[ ]");
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Your turn to chose position");


            string inputPosition = Console.ReadLine();
            int z = int.Parse(inputPosition);

            switch (z)
            {
                case 1:
                    Matrix[0, 0] = " X";
                    break;
                case 2:
                    Matrix[0, 1] = " X";
                    break;
                case 3:
                    Matrix[0, 2] = " X";
                    break;
                case 4:
                    Matrix[1, 0] = " X";
                    break;
                case 5:
                    Matrix[1, 1] = " X";
                    break;
                case 6:
                    Matrix[1, 2] = " X";
                    break;
                case 7:
                    Matrix[2, 0] = " X";
                    break;
                case 8:
                    Matrix[2, 1] = " X";
                    break;
                case 9:
                    Matrix[2, 2] = " X";
                    break;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }


            Console.WriteLine("Your turn to chose position");


            string inputPosition1 = Console.ReadLine();
            int z1 = int.Parse(inputPosition1);

            switch (z1)
            {
                case 1:
                    if (Matrix[0, 0] == "[ ]")
                    {
                        Matrix[0, 0] = " O";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Позиция занята");
                        break;
                    }
                case 2:
                    Matrix[0, 1] = " O";
                    break;
                case 3:
                    Matrix[0, 2] = " O";
                    break;
                case 4:
                    Matrix[1, 0] = " O";
                    break;
                case 5:
                    Matrix[1, 1] = " O";
                    break;
                case 6:
                    Matrix[1, 2] = " O";
                    break;
                case 7:
                    Matrix[2, 0] = " O";
                    break;
                case 8:
                    Matrix[2, 1] = " O";
                    break;
                case 9:
                    Matrix[2, 2] = " O";
                    break;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
