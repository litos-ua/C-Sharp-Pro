using System;

namespace ConsoleApp4
{
    internal class Matrix
    {
        private int[,] elements;

        public Matrix(int rows, int cols)
        {
            elements = new int[rows, cols];
        }

        public int this[int row, int col]
        {
            get { return elements[row, col]; }
            set { elements[row, col] = value; }
        }

        public int Rows => elements.GetLength(0);
        public int Cols => elements.GetLength(1);


        public static Matrix operator +(Matrix mtr1, Matrix mtr2)
        {
            if (mtr1.Rows != mtr2.Rows || mtr1.Cols != mtr2.Cols)
            {
                throw new ArgumentException("Matrix sizes must be the same for addition.");
            }
            Matrix mtr = new Matrix(mtr1.Rows, mtr1.Cols);
            for (int i = 0; i < mtr1.Rows; i++)
            {
                for (int j = 0; j < mtr1.Cols; j++)
                {
                    mtr[i, j] = mtr1[i, j] + mtr2[i, j];
                }
            }

            return mtr;
        }

        public static Matrix operator -(Matrix mtr1, Matrix mtr2)
        {
            if (mtr1.Rows != mtr2.Rows || mtr1.Cols != mtr2.Cols)
            {
                throw new ArgumentException("Matrix sizes must be the same for submition.");
            }
            Matrix mtr = new Matrix(mtr1.Rows, mtr1.Cols);
            for (int i = 0; i < mtr1.Rows; i++)
            {
                for (int j = 0; j < mtr1.Cols; j++)
                {
                    mtr[i, j] = mtr1[i, j] - mtr2[i, j];
                }
            }

            return mtr;
        }

        

        public static bool operator ==(Matrix mtr1, Matrix mtr2)
        {
            if (mtr1.Rows != mtr2.Rows || mtr1.Cols != mtr2.Cols)
            {
                return false;
            }

            for (int i = 0; i < mtr1.Rows; i++)
            {
                for (int j = 0; j < mtr1.Cols; j++)
                {
                    if (mtr1[i, j] != mtr2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix mtr1, Matrix mtr2)
        {
            if (mtr1.Rows != mtr2.Rows || mtr1.Cols != mtr2.Cols)
            {
                return true;
            }

            for (int i = 0; i < mtr1.Rows; i++)
            {
                for (int j = 0; j < mtr1.Cols; j++)
                {
                    if (mtr1[i, j] != mtr2[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = HashCode.Combine(Rows, Cols);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    hash = HashCode.Combine(hash, this[i, j]);
                }
            }

            return hash;
        }



        public void PrintMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(elements[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    internal class MatrixScMult : Matrix
    {

        public MatrixScMult(int rows, int cols):base(rows, cols)
        {
        }

        public static MatrixScMult operator *(MatrixScMult mtr, int lyambda)
        {
            MatrixScMult mtrRes = new MatrixScMult(mtr.Rows, mtr.Cols);
            for (int i = 0; i < mtr.Rows; i++)
            {
                for (int j = 0; j < mtr.Cols; j++)
                {
                    mtrRes[i, j] = lyambda * mtr[i, j];
                }
            }

            return mtrRes;
        }

    }

    internal class MatrixFullMult : Matrix
    {

        public MatrixFullMult(int rows, int cols) : base(rows, cols)
        {
        }

        public static MatrixFullMult operator *(MatrixFullMult m1, MatrixFullMult m2)
        {
            if (m1.Cols != m2.Rows)
            {
                throw new ArgumentException("Matrices cannot be multiplied. Columns of the first matrix must match rows of the second matrix.");
            }

            MatrixFullMult mtrRes = new MatrixFullMult(m1.Rows, m2.Cols);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Cols; j++)
                {
                    mtrRes[i, j] = 0;
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        mtrRes[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return mtrRes;
        }

    }


}