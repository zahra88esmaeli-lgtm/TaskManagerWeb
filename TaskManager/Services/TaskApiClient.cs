using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Http.Headers;
using TaskManagerWeb.Models.Dto;

namespace TaskManagerWeb.Services
{
    public class TaskApiClient
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _accessor;

        public TaskApiClient(HttpClient http, IHttpContextAccessor accessor)
        {
            _http = http;
            _accessor = accessor;
        }
      
        private HttpRequestMessage CreateRequest(HttpMethod method, string url, object? body = null)
        {
            var request = new HttpRequestMessage(method, url);

            var token = _accessor.HttpContext?.Session.GetString("JwtToken");
            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (body != null)
                request.Content = JsonContent.Create(body);

            return request;
        }

        #region User
        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/User/register", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/User/login", dto);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result?.Token;
        }

        public async Task<(bool ok, string message)> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var response = await _http.SendAsync(CreateRequest(HttpMethod.Put, "api/User/me", dto));
            var text = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, text);
        }

        public async Task<bool> DeleteAccountAsync()
        {
            var response = await _http.SendAsync(CreateRequest(HttpMethod.Delete, "api/User/me"));
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region TaskItem
        public async Task<List<TaskItemDto>> GetTasksAsync()
        {
            var response = await _http.SendAsync(CreateRequest(HttpMethod.Get, "api/TaskItem"));
            if (response.StatusCode == HttpStatusCode.Unauthorized) return null;
            if (!response.IsSuccessStatusCode) return new List<TaskItemDto>();

            return await response.Content.ReadFromJsonAsync<List<TaskItemDto>>()
                   ?? new List<TaskItemDto>();
        }

        public async Task<bool> CreateTaskAsync(CreateTaskDto dto)
        {
            var response = await _http.SendAsync(CreateRequest(HttpMethod.Post, "api/TaskItem", dto));
            return response.IsSuccessStatusCode;
        }

        public async Task<TaskItemDto?> GetTaskByIdAsync(int id)
        {
            var response = await _http.SendAsync(CreateRequest(HttpMethod.Get, $"api/TaskItem/{id}"));
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<TaskItemDto>();
        }

        public async Task<bool> UpdateTaskAsync(UpdateTaskDto dto)
        {
            var response = await _http.SendAsync(CreateRequest(HttpMethod.Put, $"api/TaskItem/{dto.Id}", dto));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var response = await _http.SendAsync(CreateRequest(HttpMethod.Delete, $"api/TaskItem/{id}"));
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}