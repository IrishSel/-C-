using System;

namespace task3
{
    class Program
    {

        public static void DelRowAndCol(int[,] matrix, int size, int row, int col, int[,] newMatrix)
        {
            int offsetRow = 0;
            int offsetCol = 0;
            for (int i = 0; i < size - 1; i++)
            {
                if (i == row)
                {
                    offsetRow = 1;
                }

                offsetCol = 0;
                for (int j = 0; j < size - 1; j++)
                {
                    if (j == col)
                    {
                        offsetCol = 1;
                    }

                    newMatrix[i, j] = matrix[i + offsetRow, j + offsetCol];
                }
            }
        }

        public static int Det(int[,] matrix, int size)
        {
            int det = 0;
            int degree = 1;
            if (size == 1)
            {
                return matrix[0, 0];
            }
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int[,] newMatrix = new int[size - 1, size - 1];
                for (int j = 0; j < size; j++)
                {
                    DelRowAndCol(matrix, size, 0, j, newMatrix);
                    det = det + (degree * matrix[0, j] * Det(newMatrix, size - 1));
                    degree = -degree;
                }
            }

            return det;
        }

        static void Main(string[] args)
        {
            string input;

            input = System.Console.ReadLine();
            int n = Int32.Parse(input);

            int[,] sq = new int[n, n];
            int[,] test_sq = new int[n, n];
            int[] b = new int[n];

            for (int i = 0; i < n; i++)
            {
                input = System.Console.ReadLine();
                input = System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ");
                string[] arr = input.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    sq[i, j] = Int32.Parse(arr[j]);
                }
                b[i] = Int32.Parse(arr[n]);
            }

            int base_det = Det(sq, n);
            Array.Copy(sq, test_sq, n * n);

            System.Console.Write("Answer: ");

            for (int i = 0; i < n; i++)
            {
                Array.Copy(sq, test_sq, n * n);
                for (int j = 0; j < n; j++)
                {
                    test_sq[j, i] = b[j];
                }

                int cur_det = Det(test_sq, n);
                System.Console.Write(cur_det / base_det);
                System.Console.Write(' ');
            }

            System.Console.Write('\n');

        }
    }
}