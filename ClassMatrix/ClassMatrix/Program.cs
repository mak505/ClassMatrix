using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrix
{
    class Matrix
    {
        private int row;
        private int col;

        double[,] M;
        
        public Matrix()
        {
            row = 1;
            col = 1;

            M = new double[row, col];
        }

        public Matrix(int row,int col)
        {
            this.row = row;
            this.col = col;

            M = new double[row, col];
        }

        public void SetData()
        {
            Console.WriteLine("\nEnter data matrix: \n");

            for(int i = 0;i < row;i++)
            {
                for(int j = 0;j < col;j++)
                {
                    Console.Write("M[{0},{1}]: ", i, j);
                    M[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

        public void GetData()
        {
            Console.WriteLine("\nMatrix\n");

            for(int i = 0;i < row;i++)
            {
                Console.Write("\t\t");

                for(int j = 0;j < col;j++)
                {
                    Console.Write(M[i, j] + "\t\t");
                }

                Console.WriteLine("\n\n");
            }
        }

        public static Matrix operator + (Matrix a,Matrix b)
        {
            if (a.row == b.row && a.col == b.col)
            {
                Matrix c = new Matrix(a.row, a.col);

                for (int i = 0; i < c.row; i++)
                {
                    for (int j = 0; j < c.col; j++)
                    {
                        c.M[i, j] = a.M[i, j] + b.M[i, j];
                    }
                }

                return c;
            }

            else
            {
                Console.WriteLine("\n\nErrorException\n\n");
                Console.WriteLine("При сложение двух матриц строки и колонки обоих должны быть равны");
                Console.WriteLine("Из-за ошибки будет возвращена единичная матрица со значением 1");

                Matrix c = new Matrix();
                c.M[0, 0] = 1;

                return c;
            }
           
        }

        public static Matrix operator - (Matrix a,Matrix b)
        {
            if (a.row == b.row && a.col == b.col)
            {
                Matrix c = new Matrix(a.row, a.col);

                for (int i = 0; i < c.row; i++)
                {
                    for (int j = 0; j < c.col; j++)
                    {
                        c.M[i, j] = a.M[i, j] - b.M[i, j];
                    }
                }

                return c;
            }

            else
            {
                Console.WriteLine("\n\nErrorException\n\n");
                Console.WriteLine("При вычитании двух матриц строки и колонки обоих должны быть равны");
                Console.WriteLine("Из-за ошибки будет возвращена единичная матрица со значением 1");

                Matrix c = new Matrix();
                c.M[0, 0] = 1;

                return c;
            }
        }

        public static Matrix operator * (int value,Matrix a)
        {
            Matrix c = new Matrix(a.row, a.col);

            for (int i = 0; i < c.row; i++)
            {
                for (int j = 0; j < c.col; j++)
                {
                    c.M[i, j] = value * a.M[i, j];
                }
            }

            return c;
        }

        public static Matrix operator *(Matrix a,int value)
        {
            Matrix c = new Matrix(a.row, a.col);

            for (int i = 0; i < c.row; i++)
            {
                for (int j = 0; j < c.col; j++)
                {
                    c.M[i, j] = value * a.M[i, j];
                }
            }

            return c;
        }

        public static Matrix operator*(Matrix a,Matrix b)
        {
            if (a.col == b.row)
            {

                Matrix c = new Matrix(a.row, b.col);

                double sum = 0;

                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < b.col; j++)
                    {
                        sum = 0;

                        for (int k = 0; k < a.col; k++)
                        {
                            sum += a.M[i, k] * b.M[k, j];
                        }

                        c.M[i, j] = sum;
                    }
                }

                return c;
            }

            else

            {
                Console.WriteLine("\n\nErrorException\n\n");
                Console.WriteLine("Две матрицы можно перемножить если количество столбцов первой матрицы равно количеству строк второй матрицы");
                Console.WriteLine("Из-за ошибки будет возвращена единичная матрица со значением 1");

                Matrix c = new Matrix();
                c.M[0, 0] = 1;

                return c;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            for(; ; )
            {

                try
                {

                    int rowA, colA;
                    int rowB, colB;

                    Console.Write("Enter number rows first matrix: ");
                    rowA = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter number cols first matrix: ");
                    colA = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    Console.Write("Enter number rows second matrix: ");
                    rowB = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter number cols second matrix: ");
                    colB = Convert.ToInt32(Console.ReadLine());

                    Matrix A = new Matrix(rowA, colA);
                    Matrix B = new Matrix(rowB, colB);
                    Matrix C = new Matrix();

                    A.SetData();
                    A.GetData();

                    Console.WriteLine("\n\n");

                    B.SetData();
                    B.GetData();

                    C = A * B;

                    C.GetData();

                    break;
                }

                catch(FormatException)
                {
                    Console.WriteLine("\n\n!!! FormatException !!!\n\n");
                }

                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("\n\n!!! IndexOutOfRangeException !!!\n\n");
                }
            }
           
            Console.ReadLine();
        }
    }
}
