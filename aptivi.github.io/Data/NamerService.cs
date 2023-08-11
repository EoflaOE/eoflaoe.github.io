using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using aptivi.github.io.Utilities;

namespace aptivi.github.io.Data
{
    public class NamerService
    {
		public static async Task<string[]> GetNames(NamerSettings namerSettings)
		{
            return await GenerateNamesAsync(
                    namerSettings.NameCount,
                    namerSettings.NameStartsWith,
                    namerSettings.NameEndsWith,
                    namerSettings.SurnameStartsWith,
                    namerSettings.SurnameEndsWith
                );
		}
        
        // TODO: Namer, ManagedWeatherMap, and others should be fixed to include the Async versions below
        // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

        internal static string[] Names = Array.Empty<string>();
        internal static string[] Surnames = Array.Empty<string>();
        private static readonly HttpClient NameClient = new();

        /// <summary>
        /// Populates the names and the surnames for the purpose of initialization
        /// </summary>
        public static async Task PopulateNamesAsync()
        {
            try
            {
                if (Names.Length == 0)
                {
                    HttpResponseMessage Response = await NameClient.GetAsync("https://cdn.jsdelivr.net/gh/Aptivi/NamesList@master/Processed/FirstNames.txt");
                    Response.EnsureSuccessStatusCode();
                    Stream NamesStream = await Response.Content.ReadAsStreamAsync();
                    string NamesString = new StreamReader(NamesStream).ReadToEnd();
                    Names = NamesString.SplitNewLines();
                }
                if (Surnames.Length == 0)
                {
                    HttpResponseMessage Response = await NameClient.GetAsync("https://cdn.jsdelivr.net/gh/Aptivi/NamesList@master/Processed/Surnames.txt");
                    Response.EnsureSuccessStatusCode();
                    Stream SurnamesStream = await Response.Content.ReadAsStreamAsync();
                    string SurnamesString = new StreamReader(SurnamesStream).ReadToEnd();
                    Surnames = SurnamesString.SplitNewLines();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can't get names and surnames:" + $" {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Generates the names
        /// </summary>
        /// <returns>List of generated names</returns>
        public static async Task<string[]> GenerateNamesAsync()
        {
            return await GenerateNamesAsync(10, "", "", "", "");
        }

        /// <summary>
        /// Generates the names
        /// </summary>
        /// <param name="Count">How many names to generate?</param>
        /// <returns>List of generated names</returns>
        public static async Task<string[]> GenerateNamesAsync(int Count)
        {
            return await GenerateNamesAsync(Count, "", "", "", "");
        }

        /// <summary>
        /// Generates the names
        /// </summary>
        /// <param name="Count">How many names to generate?</param>
        /// <param name="NamePrefix">What should the name start with?</param>
        /// <param name="NameSuffix">What should the name end with?</param>
        /// <param name="SurnamePrefix">What should the surname start with?</param>
        /// <param name="SurnameSuffix">What should the surname end with?</param>
        /// <returns>List of generated names</returns>
        public static async Task<string[]> GenerateNamesAsync(int Count, string NamePrefix, string NameSuffix, string SurnamePrefix, string SurnameSuffix)
        {
            Random RandomDriver = new();
            List<string> NamesList = new();

            // Initialize names
            await PopulateNamesAsync();

            // Check if the prefix and suffix check is required
            bool NamePrefixCheckRequired = !string.IsNullOrEmpty(NamePrefix);
            bool NameSuffixCheckRequired = !string.IsNullOrEmpty(NameSuffix);
            bool SuramePrefixCheckRequired = !string.IsNullOrEmpty(SurnamePrefix);
            bool SurameSuffixCheckRequired = !string.IsNullOrEmpty(SurnameSuffix);

            // Process the names according to suffix and/or prefix check requirement
            string[] ProcessedNames = Names;
            if (NamePrefixCheckRequired && NameSuffixCheckRequired)
                ProcessedNames = Names.Where((str) => str.StartsWith(NamePrefix) && str.EndsWith(NameSuffix)).ToArray();
            else if (NamePrefixCheckRequired)
                ProcessedNames = Names.Where((str) => str.StartsWith(NamePrefix)).ToArray();
            else if (NameSuffixCheckRequired)
                ProcessedNames = Names.Where((str) => str.EndsWith(NameSuffix)).ToArray();

            // Do the same for the surnames
            string[] ProcessedSurnames = Surnames;
            if (NamePrefixCheckRequired && NameSuffixCheckRequired)
                ProcessedSurnames = Surnames.Where((str) => str.StartsWith(SurnamePrefix) && str.EndsWith(SurnameSuffix)).ToArray();
            else if (NamePrefixCheckRequired)
                ProcessedSurnames = Surnames.Where((str) => str.StartsWith(SurnamePrefix)).ToArray();
            else if (NameSuffixCheckRequired)
                ProcessedSurnames = Surnames.Where((str) => str.EndsWith(SurnameSuffix)).ToArray();

            // Check the names and the surnames
            if (ProcessedNames.Length == 0)
                throw new Exception("The names are not found! Please ensure that the name conditions are correct.");
            if (ProcessedSurnames.Length == 0)
                throw new Exception("The surnames are not found! Please ensure that the surname conditions are correct.");

            // Select random names
            for (int NameNum = 1; NameNum <= Count; NameNum++)
            {
                // Get the names
                string GeneratedName = ProcessedNames[RandomDriver.Next(ProcessedNames.Length)];
                string GeneratedSurname = ProcessedSurnames[RandomDriver.Next(ProcessedSurnames.Length)];
                NamesList.Add(GeneratedName + " " + GeneratedSurname);
            }
            return NamesList.ToArray();
        }
    }
}