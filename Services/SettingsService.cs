using BlazorClient.Models;
using System.Text.Json;

namespace BlazorClient.Services;

public interface ISettingsService
{
    Task<ChatSettings> GetSettingsAsync();
    Task SaveSettingsAsync(ChatSettings settings);
    event Action? SettingsChanged;
}

public class SettingsService : ISettingsService
{
    private readonly ILogger<SettingsService> _logger;
    private ChatSettings _currentSettings;
    private const string SETTINGS_KEY = "chat_settings";

    public event Action? SettingsChanged;

    public SettingsService(ILogger<SettingsService> logger)
    {
        _logger = logger;
        _currentSettings = GetDefaultSettings();
    }

    public Task<ChatSettings> GetSettingsAsync()
    {
        // In a real implementation, you might load from localStorage or browser storage
        // For now, return the current settings
        return Task.FromResult(_currentSettings);
    }

    public Task SaveSettingsAsync(ChatSettings settings)
    {
        _currentSettings = settings;
        _logger.LogInformation("Settings saved: {DeploymentName} at {Endpoint}", settings.DeploymentName, settings.Endpoint);
        
        // In a real implementation, you would save to localStorage here
        // For now, just keep it in memory
        
        SettingsChanged?.Invoke();
        return Task.CompletedTask;
    }

    private ChatSettings GetDefaultSettings()
    {
        return new ChatSettings
        {
            Endpoint = "http://localhost:11434/",
            DeploymentName = "llama3.2",
            ApiKey = "",
            ClientMode = "Ollama"
        };
    }
}
