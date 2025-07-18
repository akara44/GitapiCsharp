using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gitapi.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Username { get; set; } = string.Empty;

    public GitHubUser? GitUser { get; set; }
    public List<GitHubRepo>? Repos { get; set; }
    public string? ErrorMessage { get; set; }

    private const string GitHubToken = "Buraya Githubdan aldığınız token gelecek"; // Tokenını güvenli sakla

    public async Task OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Username))
        {
            ErrorMessage = "⚠️ Lütfen bir kullanıcı adı girin.";
            return;
        }

        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("GitapiApp");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GitHubToken);

        try
        {
            var userResponse = await client.GetAsync($"https://api.github.com/users/{Username}");
            if (!userResponse.IsSuccessStatusCode)
            {
                ErrorMessage = "❌ Kullanıcı bulunamadı!";
                return;
            }

            var reposResponse = await client.GetAsync($"https://api.github.com/users/{Username}/repos");
            if (!reposResponse.IsSuccessStatusCode)
            {
                ErrorMessage = "❌ Repo bilgileri alınamadı!";
                return;
            }

            var userJson = await userResponse.Content.ReadAsStringAsync();
            var reposJson = await reposResponse.Content.ReadAsStringAsync();

            GitUser = JsonSerializer.Deserialize<GitHubUser>(userJson);
            Repos = JsonSerializer.Deserialize<List<GitHubRepo>>(reposJson);
        }
        catch (Exception ex)
        {
            ErrorMessage = "🚨 Beklenmeyen bir hata oluştu: " + ex.Message;
        }
    }

    public class GitHubUser
    {
        public string? login { get; set; }
        public string? avatar_url { get; set; }
        public string? bio { get; set; }
        public string? company { get; set; }
        public string? location { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
        public int public_repos { get; set; }
    }

    public class GitHubRepo
    {
        public string? name { get; set; }
        public string? html_url { get; set; }
        public string? description { get; set; }
        public int stargazers_count { get; set; }
        public int forks_count { get; set; }
    }
}
