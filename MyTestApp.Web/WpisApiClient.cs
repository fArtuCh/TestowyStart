namespace MyTestApp.Web;

public class WpisApiClient(HttpClient httpClient)
{
    public async Task<WpisItem[]> GetWpisyAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<WpisItem[]>("/wpisy", cancellationToken) ?? [];
    }

    public async Task SaveWpisAsync(string tresc, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/wpisy", new { Tresc = tresc }, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}

public record WpisItem(int Id, string Tresc, DateTime DataDodania);
