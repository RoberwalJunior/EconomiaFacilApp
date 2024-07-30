using System.Text;
using System.Text.Json;
using EconomiaFacilApp.App.Models;
using Microsoft.Extensions.Logging;

namespace EconomiaFacilApp.App.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://lf3jvkgb-7066.brs.devtunnels.ms/";
    private readonly ILogger<ApiService> _logger;
    JsonSerializerOptions _serializerOptions;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _serializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<ApiResponse<bool>> RegistrarUsuario(string userName, string email, string password, string rePassword)
    {
        try
        {
            var register = new Register()
            {
                UserName = userName,
                Email = email,
                Password = password,
                RePassword = rePassword
            };

            var json = JsonSerializer.Serialize(register, _serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await PostRequest("api/Usuario/Registrar", content);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogError($"Erro ao enviar requisição HTTP: {response.StatusCode}");
                return new ApiResponse<bool>
                {
                    ErrorMessage = $"Erro ao enviar requisição HTTP: {response.StatusCode}"
                };
            }

            return new ApiResponse<bool> { Data = true };
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao registrar usuário: {ex.Message}");
            return new ApiResponse<bool> { ErrorMessage = ex.Message };
        }
    }

    public async Task<ApiResponse<bool>> Login(string email, string password)
    {
        try
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };

            var json = JsonSerializer.Serialize(login, _serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await PostRequest("api/Usuario/Registrar", content);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Erro ao enviar requisição HTTP: {response.StatusCode}");
                return new ApiResponse<bool>
                {
                    ErrorMessage = $"Erro ao enviar requisição HTTP: {response.StatusCode}"
                };
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Token>(jsonResult, _serializerOptions);

            Preferences.Set("accesstoken", result!.ChaveToken);
            Preferences.Set("typetoken", result!.TipoToken);
            Preferences.Set("usuarioid", result!.UsuarioId);
            Preferences.Set("usuarionome", result!.UsuarioUserName);
            Preferences.Set("usuarioemail", result!.UsuarioEmail);

            return new ApiResponse<bool> { Data = true };
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro no login: {ex.Message}");
            return new ApiResponse<bool> { ErrorMessage = ex.Message };
        }
    }

    private async Task<HttpResponseMessage> PostRequest(string url, HttpContent content)
    {
        var enderecoUrl = _baseUrl + url;
        try
        {
            return await _httpClient.PostAsync(enderecoUrl, content);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao enviar requisição POST para {url}: {ex.Message}");
            return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
