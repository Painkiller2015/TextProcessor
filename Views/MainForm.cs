using System.ComponentModel;
using TextProcessor.DataBase;
using TextProcessor.Models;
using TextProcessor.Presenter;

namespace TextProcessor
{
    public partial class MainForm : Form
    {
        private bool _IgnoreSelectedIndexChanged;
        public MainForm()
        {
            InitializeComponent();
            SuggestedWordsList.DataSource = new List<Word>();

            RequestedWords.RequestWord += ((obj, words) =>
            {
                List<Word> sugWord = words.OrderByDescending(el => el.CountUses).ThenBy(el => el.Name).ToList();
                BindingList<Word> listBinding = new(sugWord);

                SetSourseWithoutAutoSelect(listBinding);

                SuggestedWordsList.DisplayMember = "Популярные слова:";
                SuggestedWordsList.ValueMember = "Name";

                if (words.Count > 0)
                    SuggestedWordsList.Visible = true;

            });
        }

        private void SetSourseWithoutAutoSelect(BindingList<Word> sugWord)
        {
            SuggestedWordsList.SelectedIndexChanged -= SuggestedWordsList_SelectedIndexChanged;
           // ((BindingList<Word>)SuggestedWordsList.DataSource).Clear();
            SuggestedWordsList.DataSource = sugWord;
            SuggestedWordsList.SelectedIndexChanged += SuggestedWordsList_SelectedIndexChanged;
        }

        private void SuggestedWordsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IgnoreSelectedIndexChanged)
                return;
            _IgnoreSelectedIndexChanged = true;
            _IgnoreSelectedIndexChanged = false;
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            string word = MainFormHelpers.GetLastWord(text);

            if (text.Contains(' '))
            {
                bool isSingleSpace = MainFormHelpers.IsSingleSpace(text);
                bool isEndSymb = IsEndSymb(word);


                if (isEndSymb && isSingleSpace)
                {
                    InputTextBox.Text = InputTextBox.Text.Remove(InputTextBox.Text.Length - 2, 1);
                    InputTextBox.SelectionStart = InputTextBox.Text.Length;
                }
            }

            if (word.Length >= 3)
                MainFormHelpers.SetWords(word);
        }

        #region ButtonEvent


        public bool IsEndSymb(string word)
        {
            bool isEndSymb = false;

            foreach (var symb in MainFormHelpers.EndSymb)
            {
                if (word.Contains(symb))
                {
                    isEndSymb = true;
                    InputTextBox.SelectionStart = InputTextBox.Text.Length;
                    break;
                }
            }

            return isEndSymb;
        }
        private void SetDictionaryButton_Click(object sender, EventArgs e)
        {
            string textDictionary = GetDictionaryText();

            if (string.IsNullOrEmpty(textDictionary))
                return;

            DatatBase_Commands.SetDictionaty(textDictionary);
            MessageBox.Show("Словарь задан!");
        }

        private void UpdateDictionaryButton_Click(object sender, EventArgs e)
        {
            string textDictionary = GetDictionaryText();

            if (string.IsNullOrEmpty(textDictionary))
                return;

            DatatBase_Commands.UpdateDictionaty(textDictionary);
            MessageBox.Show("Словарь обновлён!");
        }

        private void DeleteDictionaryButton_Click(object sender, EventArgs e)
        {
            DatatBase_Commands.ClearDictionaty();
            MessageBox.Show("Словарь удалён!");
        }

        #endregion

        private static string? GetDictionaryText()
        {
            using (var explorer = new OpenFileDialog())
            {
                explorer.ShowDialog();

                if (string.IsNullOrEmpty(explorer.FileName))
                    return explorer.FileName;

                string textDictionary = File.ReadAllText(explorer.FileName);
                return textDictionary;
            }
        }

        private void SuggestedWordsList_SelectedWord(object sender, EventArgs e)
        {
            string PasteWord = ((Word)((ListBox)sender)?.SelectedItem)?.Name;

            if (PasteWord == null)
            {
                return;
            }

            string inputText = InputTextBox.Text;
            string tempText;
            if (inputText.Split(' ').ToArray().Length > 1)
            {
                string result = inputText.Remove(inputText.LastIndexOf(' '));
                tempText = string.Concat(result, " ", PasteWord, " ");
            }
            else
            {
                tempText = string.Concat(PasteWord, " ");
            }

            DatatBase_Commands.UpdateWordUse(new Word { Name = PasteWord });
            InputTextBox.Text = tempText;
            SuggestedWordsList.Visible = false;
        }
    }
}