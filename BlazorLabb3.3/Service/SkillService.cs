using BlazorLabb3._3.Models;


namespace BlazorLabb3._3.Service
{

    public class SkillService
    {
        private readonly HttpClient _httpClient;
        public SkillService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Skill>> GetSkills()
        {
            var skills = await _httpClient.GetFromJsonAsync<List<Skill>>("https://isabellaswebapplabb3-evfjf4a4a3e4aufk.westeurope-01.azurewebsites.net/skills");
            return skills ?? new List<Skill>();
        }
    }
}