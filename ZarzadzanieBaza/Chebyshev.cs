using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieBaza
{
    public class Chebyshev
    {
        // n = 0
        private static double T0(double x)
        {
            return 1.0;
        }

        // n = 1
        private static double T1(double x)
        {
            return x;
        }

        // n = 2
        private static double T2(double x)
        {
            return (2.0 * x * x) - 1.0;
        }

        /*
        *	Tn(x)
        */
        public static double Tn(uint n, double x)
        {
            if (n == 0)
            {
                return T0(x);
            }
            else if (n == 1)
            {
                return T1(x);
            }
            else if (n == 2)
            {
                return T2(x);
            }
            return (2.0 * x * Tn(n - 1, x)) - Tn(n - 2, x);

            //double tnm1(T2(x));
            //double tnm2(T1(x));
            //double tn(tnm1);

            //for (uint l = 3; l <= n; l++)
            //{
            //    tn = (2.0 * x * tnm1) - tnm2;
            //    tnm2 = tnm1;
            //    tnm1 = tn;
            //}

            //return tn;
        }

        public static List<double> ConvertXToU(List<double> X)
        {
            List<double> U = new List<double>();
            foreach (var x in X)
            {
                double a = X.First(), b = X.Last();
                double u = ((2 * x) - a - b)/(b - a);
                U.Add(u);
            }
            return U;
        }

        public static double[,] CalculatePolynomials(List<double> U, int n)
        {
            double[,] T = new double[U.Count, n+1];
            for (int i = 0; i < U.Count; i++)
            {
                for (uint j = 0; j < n + 1; j++)
                {
                    T[i,j] = Tn(j, U[i]);
                }
            }

            return T;
        }

        public static double[,] ComputeVectorC(double[,] T, double[,] Y)
        {
            //C = (T'*T)*(T'*Y)
            //OLS
            var TtT = MultiplyMatrix(T.Transpose(), T);
            var TtY = MultiplyMatrix(T.Transpose(), Y);
            var C = MultiplyMatrix(TtT, TtY);
            //Possibly change to WLS with weights

            return C;
        }

        public static double[,] MultiplyMatrix(double[,] A, double[,] B)
        {
            double[,] C = new double[A.GetLength(0), B.GetLength(1)];
            int m = 0;
            if (A.GetLength(1) == B.GetLength(0))
            {
                m = A.GetLength(1);
            }
            for (int i = 0; i < A.GetLength(0) ; i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    C[i, j] = sum;
                }
            }
            return C;
        }

        public static double[,] InverseMatrix(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] invA = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    invA[i, j] = A[i, j];
                }
            }

            double det = DetMatrix(A);
            if (det == 0.0)
            {
                Console.WriteLine("No inverse");
                return invA;
            }

            double[,] lum; // Combined lower & upper
            int[] perm;
            int toggle;
            toggle = MatrixDecompose(A, out lum, out perm);

            double[] b = new double[n];
            //solve equation for each column of identity matrix LUx = Pb
            for (int i = 0; i < n; ++i)
            {
                //determine the identity matrix column b
                for (int j = 0; j < n; ++j)
                    if (i == perm[j]) b[j] = 1.0;
                    else b[j] = 0.0;
                double[] x = EquationSolver(lum, b); //solve the equation
                for (int j = 0; j < n; ++j)
                    invA[j,i] = x[j]; //put column into inverse matrix A

            }
            return invA;
        }

        private static double[] EquationSolver(double[,] lum, double[] b)
        {
            int n = lum.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            //Solving Ly = b
            //note that y is temporary x
            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= lum[i,j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= lum[n - 1,n - 1]; 

            //Solving Ux = y
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= lum[i,j] * x[j];
                x[i] = sum / lum[i,i];
            }

            return x;
        }

        public static double DetMatrix(double[,] A)
        {
            double[,] lum;
            int[] perm;
            int toggle = MatrixDecompose(A, out lum, out perm);
            double result = toggle;
            for (int i = 0; i < lum.Length; ++i)
                result *= lum[i,i];
            return result;
        }

        private static int MatrixDecompose(double[,] A, out double[,] lum, out int[] perm)
        {
            // Crout's LU decomposition for matrix determinant and inverse
            // stores combined lower & upper in lum[][]
            // stores row permuations into perm[]
            // returns +1 or -1 according to even or odd number of row permutations
            // lower gets dummy 1.0s on diagonal (0.0s above)
            // upper gets lum values on diagonal (0.0s below)

            int toggle = +1; // even (+1) or odd (-1) row permutatuions
            int n = A.GetLength(0);

            // make a copy of m[,] into result lum[,]
            lum = new double[n,n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    lum[i,j] = A[i,j];


            // make perm[], to know where each row was moved
            perm = new int[n];
            for (int i = 0; i < n; ++i)
                perm[i] = i;

            for (int j = 0; j < n - 1; ++j) // process by column. note n-1 
            {
                double max = Math.Abs(lum[j,j]);
                int piv = j;

                for (int i = j + 1; i < n; ++i) // find pivot index
                {
                    double xij = Math.Abs(lum[i,j]);
                    if (xij > max)
                    {
                        max = xij;
                        piv = i;
                    }
                } // i

                if (piv != j) // swap rows j, piv
                {
                    // Size of double.
                    var doubleSize = sizeof(double);

                    // Number of elements in a row.
                    var numRowElements = lum.GetLength(1);

                    // Temporary array for an intermediate step in the swap operation.
                    var temp = new double[numRowElements];

                    // Copy piv row into a temporary array.
                    Buffer.BlockCopy(lum, 
                        piv * numRowElements * doubleSize,
                        temp, 
                        0,
                        numRowElements * doubleSize);

                    // Copy j row into the piv row.
                    Buffer.BlockCopy(lum, 
                        j * numRowElements * doubleSize,
                        lum,
                        piv * numRowElements * doubleSize, 
                        numRowElements * doubleSize);

                    // Copy temporary array into the j row.
                    Buffer.BlockCopy(temp,
                        0, 
                        lum, 
                        j * numRowElements * doubleSize, 
                        numRowElements * doubleSize);
                    
                    int t = perm[piv]; // swap perm elements
                    perm[piv] = perm[j];
                    perm[j] = t;

                    toggle = -toggle;
                }

                double xjj = lum[j,j];
                if (xjj != 0.0)
                {
                    for (int i = j + 1; i < n; ++i)
                    {
                        //calculate L with 1.0s on diagonal
                        //by dividing column by diagonal
                        double xij = lum[i,j] / xjj;
                        lum[i,j] = xij; 
                        //from every element on right of that column in that row
                        //i substract the multiplication of xij and corresponding element on j row
                        for (int k = j + 1; k < n; ++k)
                            lum[i,k] -= xij * lum[j,k];
                    }
                }

            } // j

            return toggle;
        }

        //public static List<double> WeightMatrixW(List<double> X)
        //{
        //    double m = X.Average();
        //    double sum = 0;
        //    foreach (var x in X)
        //    {
        //        sum += Math.Pow(x - m, 2);
        //    }
        //    double variance = sum / X.Count();
        //}
    }
}
