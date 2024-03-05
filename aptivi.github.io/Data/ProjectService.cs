using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace aptivi.github.io.Data
{
    public class ProjectService
    {
        public static async Task<Project[]> GetProjects()
        {
            HttpClient client = new();
            string projectsJsonContent = await client.GetStringAsync("https://cdn.jsdelivr.net/gh/Aptivi-Analytics/project-list@latest/Projects.json").ConfigureAwait(false);
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(projectsJsonContent));
            Project[] projectsObject = (Project[])await JsonSerializer.DeserializeAsync(stream, typeof(Project[]));
            for (int i = 0; i < projectsObject.Length; i++)
            {
                try
                {
                    Project project = projectsObject[i];
                    string org = string.IsNullOrEmpty(project.ProjectOrg) ? "Aptivi" : $"Aptivi-{project.ProjectOrg}";
                    string apiLink = $"https://api.github.com/repos/{org}/{project.ProjectSlug}/tags";
                    string apiJsonContent = await client.GetStringAsync(apiLink).ConfigureAwait(false);
                    var apiJsonDocument = JsonNode.Parse(apiJsonContent);
                    string version = apiJsonDocument[0]["name"].GetValue<string>();
                    string commitSha = apiJsonDocument[0]["commit"]["sha"].GetValue<string>()[..7];
                    project.ProjectVersion = version;
                    project.ProjectCommitSha = commitSha;
                    projectsObject[i] = project;
                }
                catch
                {
                }
            }
            return projectsObject;
        }
    }
}
