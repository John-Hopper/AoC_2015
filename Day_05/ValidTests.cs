using System.Linq;

namespace Day_05
{
    public static class ValidTests
    {
        public static bool ContainsVowel(string testString)
        {
            var vowelCount = 0;
            char[] vowels = "aeiou".ToCharArray();

            foreach(char vowel in vowels)
            {
                vowelCount += testString.Count(f => (f == vowel));
            }

            if (vowelCount >= 3) return true;
            return false;
        }

        public static bool ContainsDoubleLetter(string testString)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            foreach(char letter in alphabet)
            {
                var doubleLetter = letter.ToString() + letter.ToString();
                if (testString.Contains(doubleLetter)) return true;
            }
            return false;
        }

        public static bool ContainsDisallowedLetterSet(string testString)
        {
            string[] disallowedLetterSet = new string[] { "ab", "cd", "pq", "xy" };

            foreach (string letterSet in disallowedLetterSet)
            {
                if (testString.Contains(letterSet)) return true;
            }
            return false;
        }
    }
}
