using System.Threading.Tasks;
using Dictify.Manager;
using Dictify.Models;

namespace aptivi.github.io.Data
{
    public class WordService
    {
        public async Task<DictionaryWord[]> GetDefinition(WordSettings wordSettings) =>
            await DictionaryManager.GetWordInfoAsync(wordSettings.SelectedWord);
    }
}