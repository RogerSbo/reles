public class SonoffService
{
    private readonly HttpClient _httpClient;

    public SonoffService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> SendCommandAsync(string deviceIp, string command)
    {
        var url = $"http://{deviceIp}/cm?cmnd={Uri.EscapeDataString(command)}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
