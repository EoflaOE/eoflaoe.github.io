using System.Threading.Tasks;
using Textify.Online.EnglishDictionary;

namespace aptivi.github.io.Data
{
    public class WordService
    {
        public async Task<DictionaryWord[]> GetDefinition(WordSettings wordSettings) =>
            await DictionaryManager.GetWordInfoAsync(wordSettings.SelectedWord);
    }
}
