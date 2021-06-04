using System;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Что вы хотите сделать? (ввести соответствующую цифру)");
            Console.WriteLine("1. Вычислить определитель матрицы");
            Console.WriteLine("2. Решить систему линейных уравнений методом Крамера");
            var userKey = Console.ReadLine();
            switch (userKey)
            {
                case "1":
                    var matrix = ReadMatrix();
                    Console.WriteLine("Определитель равен " + Matrix.Determinant(matrix));
                    break;
                case "2":
                    var (kf, fl) = ReadSystem();
                    var solve = Kramer.Solve(kf, fl);
                    if (solve != null)
                        for (var i = 0; i < solve.Length; i++)
                            Console.WriteLine($"X{i} = {solve[i]}");
                    break;
            }
        }

        private static int[,] ReadMatrix()
        {
            Console.WriteLine("Введите размер матрицы");
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];
            Console.WriteLine("Введите матрицу размером " + matrixSize + "x" + matrixSize);
            for (var i = 0; i < matrixSize; i++)
            {
                var line = Console.ReadLine();
                var j = 0;
                foreach (var v in line.Split(' ').Select(int.Parse))
                    matrix[i, j++] = v;
            }

            return matrix;
        }

        private static (int[,] kf, int[] fl) ReadSystem()
        {
            Console.WriteLine("Введите размер системы");
            var size = int.Parse(Console.ReadLine());
            var kf = new int[size, size];
            var fl = new int[size];
            Console.WriteLine("Введите коэффициенты при неизвесных и свободные члены системы");
            for (var i = 0; i < size; i++)
            {
                var line = Console.ReadLine();
                var j = 0;
                foreach (var v in line.Split().Select(int.Parse))
                {
                    if (j == size)
                        fl[i] = v;
                    else
                        kf[i, j++] = v;
                }
            }

            return (kf, fl);
        }
    }
}
