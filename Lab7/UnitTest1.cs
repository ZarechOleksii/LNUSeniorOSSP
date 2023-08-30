using NUnit.Framework;
using System.Runtime.InteropServices;

namespace UnitTests
{
    public class Tests
    {
        [DllImport("OS&SP5DLL.dll")]
        private static extern int Minimum(int[] intArr, int arraySizeInBytes);

        [DllImport("OS&SP5DLL.dll")]
        private static extern bool Contains(string text, int textSize, string toFind, int searchedStringSize, bool caseSensitive);

        [DllImport("OS&SP5DLL.dll")]
        private static extern double Average(int[] intArr, int arraySizeInBytes);

        [DllImport("OS&SP5DLL.dll")]
        private static extern int Count(string text, int textSize, char searched, bool caseSensitive);

        [TestCase(new[] { 1, 2, 3}, 1)]
        [TestCase(new[] { 1, -5, 0 }, -5)]
        [TestCase(new[] { 1, 100, int.MinValue }, int.MinValue)]
        [TestCase(new[] { -50, 4, 100 }, -50)]
        public void MinimumTest(int[] intArr, int shouldBeResult)
        {
            int min = Minimum(intArr, intArr.Length * sizeof(int));

            Assert.That(min, Is.EqualTo(shouldBeResult));
        }

        [TestCase("SoMe text","ome", true, false)]
        [TestCase("SoMe text", "ome", false, true)]
        [TestCase("SoMe text", "not present text", false, false)]
        [TestCase("SoMe text", "xt", true, true)]
        public void ContainsTest(string text, string textToFind, bool caseSensitivity, bool containResult)
        {
            bool isContained = Contains(text, text.Length + 1, textToFind, textToFind.Length + 1, caseSensitivity);

            Assert.That(isContained, Is.EqualTo(containResult));
        }

        [TestCase(new[] { 1, 2, 3 }, 2.0)]
        [TestCase(new[] { 0, 10 }, 5.0)]
        [TestCase(new[] { int.MinValue, int.MaxValue }, -0.5)]
        [TestCase(new[] { 1, 2 }, 1.5)]
        public void AverageTest(int[] intArr, double shouldBeResult)
        {
            double avg = Average(intArr, intArr.Length * sizeof(int));

            Assert.That(avg, Is.EqualTo(shouldBeResult));
        }

        [TestCase("Occurrences of letter O will be counted here", 'o', true, 2)]
        [TestCase("Occurrences of letter O will be counted here", 'o', false, 4)]
        [TestCase("OooOooO", 'o', true, 4)]
        [TestCase("OooOooO", 'o', false, 7)]
        public void CountTest(string text, char searched, bool caseSensitive, int counted)
        {
            int occurences = Count(text, text.Length + 1, searched, caseSensitive);

            Assert.That(occurences, Is.EqualTo(counted));
        }
    }
}