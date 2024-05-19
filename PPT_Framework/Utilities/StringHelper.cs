namespace PPT_WebApi.Utilities
{
    public class StringHelper
    {
        public static bool HasVowel(string userIdentifier)
        {
            foreach (char c in userIdentifier)
            {
                if (IsCharacterAVowel(c))
                    return true;
            }
            return false;
        }

        public static bool IsCharacterAVowel(char c)
        {
            string vowels = "aeiou";
            return vowels.IndexOf(c.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}
