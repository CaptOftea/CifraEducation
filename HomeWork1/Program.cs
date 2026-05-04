namespace TicTacToe
{
     public class Program
    {
        static void Main()
        {
            //создание матрицы
            string[,] matrix = new string[3, 3];
            // заполнение матрицы
            for (int i = 0; i < 3; i++) // внешний цикл (строки)
            {
                for (int j = 0; j < 3; j++) // внутренний цикл (столбцы)
                {
                    matrix[i, j] = ("[ ]");
                }
            }
            
            // условия прекращения игры
            do
            {
                Print(matrix);
                TurnX(matrix);
                Print(matrix);
                TurnY(matrix);
            }
            while (VinCheck(matrix));
            
        }

        /// <summary>
        /// Вывод матрицы в консоль
        /// </summary>
        /// <param name="matrix"></param>
        static void Print(string[,] matrix)
        {
            // вывод матрицы
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + "\t"); // печать значений ячейки и табуляции
                }
                Console.WriteLine(); // перенос курсора после каждый сроки
            }
        }

        /// <summary>
        /// Просчет хода X
        /// </summary>
        /// <param name="matrix"></param>
        static void TurnX(string[,] matrix)
        {
            Console.WriteLine("X-player chose position"); // запрос хода игрока
            string inputPosition = Console.ReadLine(); // ввод позиции 
            int z = int.Parse(inputPosition);

            switch (z) // выбор позиции
            {
                case 1:
                    EmptyCheck(matrix, 2, 0, " X");
                    break;
                case 2:
                    EmptyCheck(matrix, 2, 1, " X");
                    break;
                case 3:
                    EmptyCheck(matrix, 2, 2, " X");
                    break;
                case 4:
                    EmptyCheck(matrix, 1, 0, " X");;
                    break;
                case 5:
                    EmptyCheck(matrix, 1, 1, " X");;
                    break;
                case 6:
                    EmptyCheck(matrix, 1, 2, " X");;
                    break;
                case 7:
                    EmptyCheck(matrix, 0, 0, " X");;
                    break;
                case 8:
                    EmptyCheck(matrix, 0, 1, " X");;
                    break;
                case 9:
                    EmptyCheck(matrix, 0, 2, " X");;
                    break;
            }
        }
        
        /// <summary>
        /// Просчет хода Y
        /// </summary>
        /// <param name="matrix"></param>
        static void TurnY(string[,] matrix)
        {
            Console.WriteLine("Y-player chose position"); // запрос хода игрока
            string inputPosition = Console.ReadLine(); // ввод позиции 
            int z = int.Parse(inputPosition);

            switch (z) // выбор позиции
            {
                case 1:
                    EmptyCheck(matrix, 2, 0, " Y");
                    break;
                case 2:
                    EmptyCheck(matrix, 2, 1, " Y");
                    break;
                case 3:
                    EmptyCheck(matrix, 2, 2, " Y");
                    break;
                case 4:
                    EmptyCheck(matrix, 1, 0, " Y");;
                    break;
                case 5:
                    EmptyCheck(matrix, 1, 1, " Y");;
                    break;
                case 6:
                    EmptyCheck(matrix, 1, 2, " Y");;
                    break;
                case 7:
                    EmptyCheck(matrix, 0, 0, " Y");;
                    break;
                case 8:
                    EmptyCheck(matrix, 0, 1, " Y");;
                    break;
                case 9:
                    EmptyCheck(matrix, 0, 2, " Y");;
                    break;
            }
        }

        /// <summary>
        /// Проверка пустоты ячейки матрицы
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="value"></param>
        static void EmptyCheck(string[,] matrix, int a, int b, string value)
        {
            if (matrix[a, b] == "[ ]")
            {
                matrix[a, b] = value;
            }
            else
            {
                Console.WriteLine("Клетка уже занята, выберите другую");
            }
        }

        /// <summary>
        /// Проверка условия победы
        /// </summary>
        /// <param name="matrix"></param>
        static bool VinCheck(string[,] matrix)
        {
            if (matrix[0, 0] == " X" && matrix[0, 1] == " X" && matrix[0, 2] == " X" ||
                matrix[1, 0] == " X" && matrix[1, 1] == " X" && matrix[1, 2] == " X" ||
                matrix[2, 0] == " X" && matrix[2, 1] == " X" && matrix[2, 2] == " X" ||

                matrix[0, 0] == " X" && matrix[1, 0] == " X" && matrix[2, 0] == " X" ||
                matrix[0, 1] == " X" && matrix[1, 1] == " X" && matrix[2, 1] == " X" ||
                matrix[0, 2] == " X" && matrix[1, 2] == " X" && matrix[2, 2] == " X" ||

                matrix[0, 0] == " X" && matrix[1, 1] == " X" && matrix[2, 2] == " X" ||
                matrix[2, 0] == " X" && matrix[2, 1] == " X" && matrix[0, 2] == " X")
            {
                Console.WriteLine("Игрок 1 победил!");
                Console.ReadLine();
                return false;
            }
            else if (matrix[0, 0] == " O" && matrix[0, 1] == " O" && matrix[0, 2] == " O" ||
                     matrix[1, 0] == " O" && matrix[1, 1] == " O" && matrix[1, 2] == " O" ||
                     matrix[2, 0] == " O" && matrix[2, 1] == " O" && matrix[2, 2] == " O" ||

                     matrix[0, 0] == " O" && matrix[1, 0] == " O" && matrix[2, 0] == " O" ||
                     matrix[0, 1] == " O" && matrix[1, 1] == " O" && matrix[2, 1] == " O" ||
                     matrix[0, 2] == " O" && matrix[1, 2] == " O" && matrix[2, 2] == " O" ||

                     matrix[0, 0] == " O" && matrix[1, 1] == " O" && matrix[2, 2] == " O" ||
                     matrix[2, 0] == " O" && matrix[2, 1] == " O" && matrix[0, 2] == " O")
            {
                Console.WriteLine("Игрок 2 победил!");
                Console.ReadLine();
                return false;
            }
            else if (matrix[0, 0] != "[ ]" && matrix[0, 1] != "[ ]" && matrix[0, 2] != "[ ]" &&
                     matrix[1, 0] != "[ ]" && matrix[1, 1] != "[ ]" && matrix[1, 2] != "[ ]" &&
                     matrix[2, 0] != "[ ]" && matrix[2, 1] != "[ ]" && matrix[2, 2] != "[ ]")
            {
                Console.WriteLine("Ничья!");
                Console.ReadLine();
                return false;
            }
            else 
                return true;
        }
        
    }
}
