using Nettify.EnglishDictionary;
using System.Threading.Tasks;

namespace aptivi.github.io.Data
{
    public class WordService
    {
        public async Task<DictionaryWord[]> GetDefinition(WordSettings wordSettings) =>
            await DictionaryManager.GetWordInfoAsync(wordSettings.SelectedWord);
    }
}
