var builder = WebApplication.CreateBuilder(args);

//Load Yarp Reverse Proxy
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapGet("/", () => "Hello From API Gateway");
app.UseRouting();

app.MapReverseProxy();

app.Run();
