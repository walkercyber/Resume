using BlazorLabb3._3.Models;
using System.Net.Http.Json;

namespace BlazorLabb3._3.Service
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;
        private readonly AdminUser _adminUser;

        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _adminUser = new AdminUser
            {
                Username = "admin",
                Password = "admin"
            };
        }

        // PROJECTS CRUD
        public async Task<List<Project>> GetProjects()
        {
            try
            {
                var projects = await _httpClient.GetFromJsonAsync<List<Project>>("https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/projects");
                return projects ?? new List<Project>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching projects", ex);
            }
        }

        public async Task AddProject(Project project)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/project", project);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding project", ex);
            }
        }

        public async Task UpdateProject(Project project)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/project/{project.Id}", project);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating project", ex);
            }
        }

        public async Task DeleteProject(int projectId)
        {
            try
            {
                await _httpClient.DeleteAsync($"https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/project/{projectId}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error deleting project", ex);
            }
        }

        // SKILLS CRUD
        public async Task<List<Skill>> GetSkills()
        {
            try
            {
                var skills = await _httpClient.GetFromJsonAsync<List<Skill>>("https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/skills");
                return skills ?? new List<Skill>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching skills", ex);
            }
        }

        public async Task AddSkill(Skill skill)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/skill", skill);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding skill", ex);
            }
        }

        public async Task UpdateSkill(Skill skill)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/skill/{skill.Id}", skill);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating skill", ex);
            }
        }

        public async Task DeleteSkill(int skillId)
        {
            try
            {
                await _httpClient.DeleteAsync($"https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/skill/{skillId}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error deleting skill", ex);
            }
        }

        // Admin User Authentication
        public bool IsAuthenticated(string userName, string password)
        {
            return _adminUser != null && _adminUser.Username == userName && _adminUser.Password == password;
        }
    }
}
