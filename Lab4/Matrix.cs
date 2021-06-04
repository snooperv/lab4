namespace Lab4
{
    public static class Matrix
    {
        public static double Determinant(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            if (n == 1)
                return matrix[0, 0];
            else if (n == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            var solve = 0.0;
            var minor = new int[n - 1, n - 1];
            var l = 1;
            for (var i = 0; i < n; i++)
            {
                int x = 0, y = 0;
                for (var j = 1; j < n; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        if (i == k) continue;
                        minor[x, y] = matrix[j, k];
                        y++;
                        if (y != n - 1) continue;
                        y = 0;
                        x++;
                    }
                }
                solve += l * matrix[0, i] * Determinant(minor);
                l *= -1;
            }
            return solve;
        }
    }
}
