# BlazorClient - Blazor WebAssembly Chat Application

This is a Blazor WebAssembly application that implements a chat UI and functionality as a client-side application that calls APIs instead of using server-side Blazor in the same application. This serves as a template for anyone to use and test / connect LMM's, LLM's, or MCP servers.

## Features

- **Modern Chat Interface**: Clean, responsive chat UI with purple/violet theming
- **Real-time Messaging**: Interactive chat interface with loading indicators
- **Settings Management**: Configuration page for API endpoints, deployment names, and API keys
- **Tool Integration**: Displays available MCP tools and their descriptions
- **Simulated Responses**: Currently includes simulated chat responses for demonstration purposes
- **Responsive Design**: Works well on desktop and mobile devices

## Getting Started

### Prerequisites

- .NET 9.0 SDK (could work with dotnet 8 too)
- Modern web browser

### Running the Application

1. Navigate to the BlazorClient directory:
   ```
   cd src/BlazorClient
   ```

2. Run the application:
   ```
   dotnet run
   ```

3. Open your browser and navigate to `http://localhost:5200`

## Project Structure

```
BlazorClient/
├── Models/
│   └── ChatMessage.cs          # Data models for chat messages and settings
├── Services/
│   ├── ChatService.cs          # Service for handling chat API calls
│   └── SettingsService.cs      # Service for managing application settings
├── Pages/
│   ├── Home.razor              # Main chat interface
│   └── Settings.razor          # Configuration page
├── Layout/
│   ├── MainLayout.razor        # Application layout
│   └── NavMenu.razor           # Navigation menu
├── wwwroot/
│   └── css/
│       └── Home.css            # Custom styles for chat interface
└── Program.cs                  # Application entry point
```

## Configuration

The application includes a Settings page where you can configure:

- **Endpoint**: The API endpoint for your chat service
- **Deployment Name**: The model/deployment name to use
- **API Key**: Authentication key for your service

### Preset Configurations

The Settings page includes preset buttons for:
- **Ollama**: Local AI model hosting (http://localhost:11434/)
- **GitHub Models**: GitHub's AI model API (https://models.inference.ai.azure.com)

## Integration with API

Currently, the application includes simulated responses for demonstration purposes. To integrate with your actual API:

1. Update the `ChatService.cs` file to call your real API endpoints
2. Modify the `SendMessageAsync` method to make HTTP calls to your MCP server
3. Update the `GetToolsAsync` method to fetch available tools from your API

### API Contract

The application expects the following API endpoints:

- `POST /api/chat` - Send chat messages and receive responses
- `GET /api/tools` - Get available MCP tools

Expected request/response format:

```csharp
// ChatRequest
{
    "messages": [...],
    "settings": {
        "endpoint": "...",
        "apiKey": "...",
        "deploymentName": "..."
    }
}

// ChatResponse
{
    "content": "...",
    "toolCallId": "...",
    "toolResponse": "...",
    "isError": false,
    "errorMessage": null
}
```

## Styling

The application uses custom CSS that matches the original Aspire application:
- Purple/violet color scheme (#6a1b9a primary, #4a148c secondary)
- Modern chat bubbles with proper alignment
- Loading animations
- Responsive design

## Next Steps

1. **API Integration**: Replace simulated responses with actual API calls
2. **Authentication**: Add proper authentication if required
3. **Real-time Updates**: Consider adding SignalR for real-time communication
4. **Local Storage**: Implement proper settings persistence using browser storage
5. **Error Handling**: Enhanced error handling and user feedback
6. **Testing**: Add unit tests and integration tests

## Technologies Used

- **Blazor WebAssembly** (.NET 9)
- **HTTP Client** for API communication
- **Custom CSS** for styling
- **Dependency Injection** for service management
