// using YamlDotNet.Core.Tokens;

// public class StringApiClient<TEntity> : IApiClient<TEntity, string>
// {
//     private readonly HttpClient _httpClient;
//     private readonly string _resourcePath;

//     public StringApiClient(HttpClient httpClient, string resourcePath)
//     {
//         _httpClient = httpClient;
//         _resourcePath = resourcePath;
//     }
//     public async Task<TEntity> GetByIdAsync(string id)
//     {
//         var response = await _httpClient.GetAsync($"/api/{_resourcePath}/{Uri.EscapeDataString(id)}");
//         response.EnsureSuccessStatusCode();
//         if (response != null)
//         {
//             return await response.Content.ReadFromJsonAsync<TEntity>();
//         }
//         throw new Exception("Failed to fetch by id");
//     }
// }