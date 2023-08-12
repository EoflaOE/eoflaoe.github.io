using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using aptivi.github.io.Utilities;
using Namer;

namespace aptivi.github.io.Data
{
    public class NamerService
    {
		public static async Task<string[]> GetNames(NamerSettings namerSettings)
		{
            return await NameGenerator.GenerateNamesAsync(
                    namerSettings.NameCount,
                    namerSettings.NameStartsWith,
                    namerSettings.NameEndsWith,
                    namerSettings.SurnameStartsWith,
                    namerSettings.SurnameEndsWith
                );
		}

		public static async Task<string[]> GetFirstNames(NamerSettings namerSettings)
		{
            return await NameGenerator.GenerateFirstNamesAsync(
                    namerSettings.NameCount,
                    namerSettings.NameStartsWith,
                    namerSettings.NameEndsWith
                );
		}

		public static async Task<string[]> GetLastNames(NamerSettings namerSettings)
		{
            return await NameGenerator.GenerateLastNamesAsync(
                    namerSettings.NameCount,
                    namerSettings.SurnameStartsWith,
                    namerSettings.SurnameEndsWith
                );
		}
    }
}