namespace BlazorClient.Models;

public class ChatMessage
{
    public string Role { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? ToolCallId { get; set; }
    public string? ToolResponse { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
}

public class ChatRequest
{
    public List<ChatMessage> Messages { get; set; } = new();
    public ChatSettings Settings { get; set; } = new();
}

public class ChatResponse
{
    public string Content { get; set; } = string.Empty;
    public string? ToolCallId { get; set; }
    public string? ToolResponse { get; set; }
    public bool IsError { get; set; }
    public string? ErrorMessage { get; set; }
}

public class ChatSettings
{
    public string Endpoint { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string DeploymentName { get; set; } = string.Empty;
    public string ClientMode { get; set; } = string.Empty;
}

public class McpTool
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
