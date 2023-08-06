using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

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
            return projectsObject;
        }
    }
}