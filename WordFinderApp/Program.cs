using System.Text;
public class Program
{
	public static void Main()
	{
		var wordsDictionary = new string[] { "cold", "wind", "snow", "chill" };
		var wordStream = new string[] { "abcdce", "fgwiod", "chillm", "pqnsdo", "uvdxyp", "abdghe" };
		var result = new WordFinder(wordsDictionary).Find(wordStream);
		
		Console.WriteLine(string.Join(",", result));
	}

	public class WordFinder
	{
		private readonly HashSet<string> matrix;

		public WordFinder(IEnumerable<string> matrix)
		{
			this.matrix = new HashSet<string>(matrix);
		}

		public IEnumerable<string> Find(IEnumerable<string> wordStream)
		{
			var searchWordsLeftRight = string.Join(string.Empty, wordStream);

			var characterMatrix = wordStream
				.Select(x => x.ToCharArray())
				.ToArray();

			var searchWordsTopDownStringBuilder = new StringBuilder();

			for (var i = 0; i < characterMatrix.Length; i++)
			{
				for (var j = 0; j < characterMatrix[i].Length; j++)
				{
					searchWordsTopDownStringBuilder.Append(characterMatrix[j][i]);
				}
			}

			var searchWordsTopDown = searchWordsTopDownStringBuilder.ToString();

			var result = new HashSet<string>();
			result.UnionWith(matrix.Where(searchTerm => searchWordsLeftRight.Contains(searchTerm)));
			result.UnionWith(matrix.Where(searchTerm => searchWordsTopDown.Contains(searchTerm)));

			return result.ToList();
		}
	}
}