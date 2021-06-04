using System;
using NUnit.Framework;
using Lab4;
using System.IO;

namespace Test
{
    public class KramerTest
    {
        [Test]
        public void CorrectSolutionTest()
        {
            int[,] kf =
            {
                {2, -3, 1},
                {2, 1, -4},
                {6, -5, 2},
            };
            int[] f = { 2, 9, 17 };
            CollectionAssert.AreEqual(new[] { 5, 3, 1 }, Kramer.Solve(kf, f));
        }

        [Test]
        public void NoSolutionsTest()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            int[,] kf =
            {
                {2, -3},
                {6, -9},
            };
            int[] f = { 7, 12 };
            Kramer.Solve(kf, f);

            Assert.AreEqual("Нет решений\r\n", sw.ToString());
        }

        [Test]
        public void InfSolutionsTest()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            int[,] kf =
            {
                {3, 2},
                {6, 4},
            };
            int[] f = { 5, 10 };
            Kramer.Solve(kf, f);

            Assert.AreEqual("Система имеет бесконечное количество решений\r\n", sw.ToString());
        }
    }
}
