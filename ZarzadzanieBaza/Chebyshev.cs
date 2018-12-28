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
                double u = (2 * x - a - b)/(b - a);
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
