using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TextProcessor.Models;

namespace TextProcessor.DataBase
{
    public static class DatatBase_Commands
    {
        static readonly int _WordCount = 5;
        static readonly int _NeededUseToGet = 3;


        public static void AddWord(Word word)
        {
            using var context = new DB_Context();
            context.Words.Add(word);
            context.SaveChanges();
        }
        public static void UpdateWordUse(Word UpdateWord)
        {
            using var context = new DB_Context();

            if (context.Words.Any(el => el.Name == UpdateWord.Name))
            {
                Word word = context.Words.First(el => el.Name == UpdateWord.Name);

                context.Words.Update(word);

                word.CountUses+=1;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("В базе отсутствует обновляемое слово");
            }
        }

        public static List<Word> GetWords(string wordChars)
        {
            using var context = new DB_Context();

            List<Word> words = context.Words.Where(el => (el.CountUses >= _NeededUseToGet && EF.Functions.Like(el.Name, $"{wordChars}%")))
                .OrderByDescending(el => el.CountUses)
                .Take(_WordCount)
                .ToList();

            return words;
        }
        public static void SetDictionaty(string dictionaryText)
        {
            ClearDictionaty();

            using var context = new DB_Context();
            List<Word> dictionaryWord = JsonConvert.DeserializeObject<List<Word>>(dictionaryText);

            context.AddRange(dictionaryWord);
            context.SaveChanges();
        }
        public static void UpdateDictionaty(string dictionaryText)
        {
            using var context = new DB_Context();
            try
            {
                List<Word> newWords = JsonConvert.DeserializeObject<List<Word>>(dictionaryText);
                List<Word> words = context.Words.ToList();

                foreach (var word in newWords)
                {
                    if (context.Words.Any(el => el.Name == word.Name))
                        continue;

                    AddWord(word);
                    context.SaveChanges();
                }
            }
            catch (JsonReaderException) { MessageBox.Show("Не верный словарь!"); }
            catch (NullReferenceException) { MessageBox.Show("Словарь пуст!"); }
        }
        public static void ClearDictionaty()
        {
            using var context = new DB_Context();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE [Words]");
            context.SaveChanges();
        }
    }
}
