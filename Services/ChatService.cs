using BlazorClient.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorClient.Services;

public interface IChatService
{
    Task<ChatResponse> SendMessageAsync(ChatRequest request);
    Task<List<McpTool>> GetToolsAsync();
}

public class ChatService : IChatService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ChatService> _logger;

    public ChatService(HttpClient httpClient, ILogger<ChatService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<ChatResponse> SendMessageAsync(ChatRequest request)
    {
        try
        {
            _logger.LogInformation("Sending chat request to API");
            
            // For now, simulate an API call. In the future, this would call your API
            await Task.Delay(1000); // Simulate network delay
            
            var response = new ChatResponse
            {
                Content = GenerateSimulatedResponse(request.Messages.LastOrDefault()?.Content ?? ""),
                IsError = false
            };

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending chat message");
            return new ChatResponse
            {
                IsError = true,
                ErrorMessage = ex.Message
            };
        }
    }

    public async Task<List<McpTool>> GetToolsAsync()
    {
        try
        {
            _logger.LogInformation("Getting available tools from API");
            
            // For now, return sample tools. In the future, this would call your API
            await Task.Delay(500); // Simulate network delay
            
            return new List<McpTool>
            {
                new McpTool { Name = "get_weather", Description = "Get current weather information for a location" },
                new McpTool { Name = "tell_joke", Description = "Tell a random joke to brighten your day" }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting tools");
            return new List<McpTool>();
        }
    }

    private string GenerateSimulatedResponse(string userMessage)
    {
        // Simple simulation logic - in reality this would come from your API
        if (string.IsNullOrEmpty(userMessage))
            return "Hello! How can I help you today? 😊";

        if (userMessage.ToLower().Contains("weather"))
            return "I can help you get weather information! 🌤️ Where would you like to check the weather?";

        if (userMessage.ToLower().Contains("joke"))
            return "Why don't scientists trust atoms? Because they make up everything! 😄";

        if (userMessage.Contains("+") || userMessage.Contains("math"))
        {
            // Simple math simulation
            if (userMessage.Contains("2+2"))
                return "The sum of 2 + 2 is **4**. 😊";
            if (userMessage.Contains("3+3"))
                return "The sum of 3 + 3 is **6**. 😊";
        }

        return $"Thanks for your message: \"{userMessage}\". This is a simulated response! 🤖 In the real implementation, this would come from your API that handles the MCP server communication.";
    }
}
