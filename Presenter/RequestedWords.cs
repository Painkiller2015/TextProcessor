using TextProcessor.DataBase;
using TextProcessor.Models;

namespace TextProcessor.Presenter
{
    public static class RequestedWords
    {
        public static event EventHandler<List<Word>> RequestWord;
        public static void RequestWords(string wordSymb)
        {
            List<Word> words = DatatBase_Commands.GetWords(wordSymb);
            RequestWord.Invoke(null, words);
        }
    }
}
