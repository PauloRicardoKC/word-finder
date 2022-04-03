using Xunit;
using static Program;

namespace WordFinderApp.Test
{
    public class ProgramTest
    {
        [Fact]
        public void SuccessWordFinder()
        {
            var result = new WordFinder(WordsDictionaryMock()).Find(WordStreamMock());

            Assert.True(result.Any());
        }

        [Fact]
        public void EmptyWordFinder()
        {
            var result = new WordFinder(ColorWords()).Find(WordStreamMock());

            Assert.False(result.Any());
        }

        private static string[] WordsDictionaryMock()
        {
            return new string[] { "cold", "wind", "snow", "chill" };
        }

        private static string[] ColorWords()
        {
            return new string[] { "blue", "red", "yellow", "green" };
        }

        private static string[] WordStreamMock()
        {
            return new string[] { "abcdce", "fgwiod", "chillm", "pqnsdo", "uvdxyp", "abdghe" };
        }
    }
}