namespace CadeOErro.Server.Util.Extensions
{
    public static class StringExtensions
    {
        public static string ToFirstLetterUpper(this string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            if (text.Length == 1) return text.ToUpper();

            var result = "";
            string[] words = text.Split(" ");

            foreach (var word in words)
            {
                result += word.Substring(0, 1).ToUpper() + word.Substring(1);
            }

            return result;
        }
    }
}
