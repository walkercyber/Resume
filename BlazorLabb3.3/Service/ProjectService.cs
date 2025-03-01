using BlazorLabb3._3.Models;

namespace BlazorLabb3._3.Service
{

public class ProjectService
    {
        private readonly HttpClient _httpClient;
        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Project>> GetProjects()
        {
            var projects = await _httpClient.GetFromJsonAsync<List<Project>>("https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/projects");
            return projects ?? new List<Project>();
        }
    }
}