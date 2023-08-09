using System.Text.Json.Serialization;

namespace aptivi.github.io.Data
{
    public class Project
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ProjectSlug { get; set; }
        public string ProjectGBSlug { get; set; }
        public string[] NuGetPackages { get; set; }
        public string ProjectImageLink { get; set; }

        [JsonIgnore]
        public string ProjectVersion { get; set; }
        [JsonIgnore]
        public string ProjectCommitSha { get; set; }
    }
}