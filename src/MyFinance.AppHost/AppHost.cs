using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<MyFinance_Api>("myfinance-api");

var frontend = builder.AddExecutable(
        "frontend",
        "ng",
        "../../../MyFinance.ui/MyFinance.UI")
    .WithArgs("serve", "--port", "4200")
    .WithHttpEndpoint(port: 4200, targetPort: 4200, name: "http", isProxied: false)
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();
