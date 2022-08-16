using System.Text;
using TextProcessor.Presenter;

namespace TextProcessor
{
    public static class MainFormHelpers
    {
        public static readonly char[] EndSymb = { '.', ',' };

        public static string GetLastWord(string text)
        {
            string[] inputWords = text.Split(' ');
            string lastWord = inputWords.Last();
            return lastWord;
        }     

        public static bool IsSingleSpace(string text)
        {
            bool isSingleSpace = true;
            if (text.Split(' ')[^2] == "")
                isSingleSpace = false;
            return isSingleSpace;
        }

        public static void SetWords(string text)
        {
            string inputText = StringToUTF8(text);
            RequestedWords.RequestWords(inputText);
        }

        public static string StringToUTF8(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);
            string inputTextUTF8 = Encoding.UTF8.GetString(bytes);
            return inputTextUTF8;
        }
    }
}