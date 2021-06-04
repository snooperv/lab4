using NUnit.Framework;
using Lab4;

namespace Test
{
    public class Tests
    {
        [Test]
        public void CorrectDetTest()
        {
            int[,] matrix =
            {
                {14, 16, 20},
                {-5, 100, -29},
                {46, 52, 123}
            };
            Assert.AreEqual(84608.0, Matrix.Determinant(matrix));
        }

        [Test]
        public void ZeroDeterminantTest()
        {
            int[,] matrix =
            {
                {1, 1},
                {1, 1}
            };
            Assert.AreEqual(0, Matrix.Determinant(matrix));
        }

        [Test]
        public void SmallMatrixTest()
        {
            int[,] matrix =
            {
                {5},
            };
            Assert.AreEqual(5, Matrix.Determinant(matrix));
        }

        [Test]
        [TestCase(3, -1)]
        [TestCase(4, -1)]
        [TestCase(5, -2)]
        [TestCase(6, -1)]
        [TestCase(7, -2)]
        [TestCase(8, -2)]
        [TestCase(9, -2)]
        [TestCase(10, -1)]
        public void RedhefferTest(int size, int expect)
        {
            var matrix = new int[size, size];
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                {
                    var ii = i + 1;
                    var jj = j + 1;
                    if (j == 0 || jj % ii == 0)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
                }
            Assert.AreEqual(expect, Matrix.Determinant(matrix));
        }
    }
}