using System;
using System.Linq;

namespace Lab4
{
    public static class Kramer
    {
        public static double[] Solve(int[,] kf, int[] f)
        {
            var det = Matrix.Determinant(kf);
            var solves = new double[f.Length];
            var m = new double[f.Length];
            for (var i = 0; i < kf.GetLength(0); i++)
            {
                var newMatrix = new int[kf.GetLength(0), kf.GetLength(1)];
                for (var j = 0; j < kf.GetLength(0); j++)
                    for (var k = 0; k < kf.GetLength(1); k++)
                        newMatrix[j, k] = kf[j, k];
                for (var j = 0; j < f.Length; j++)
                    newMatrix[j, i] = f[j];
                var det2 = Matrix.Determinant(newMatrix);
                m[i] = det2;
                if (det != 0)
                    solves[i] = det2 / det;
            }
            if (det != 0)
                return solves;
            if (ArrayIsZeroElements(m))
            {
                Console.WriteLine("Система имеет бесконечное количество решений");
                return null;
            }
            Console.WriteLine("Нет решений");
            return null;
        }

        private static bool ArrayIsZeroElements(double[] arr) => arr.All(i => i == 0.0);
    }
}
