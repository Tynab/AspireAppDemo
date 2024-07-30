var builder = DistributedApplication.CreateBuilder(args);

_ = builder.AddProject<Projects.AspireAppDemo_Web>("webfrontend").WithExternalHttpEndpoints().WithReference(builder.AddRedis("cache")).WithReference(builder.AddProject<Projects.AspireAppDemo_ApiService>("apiservice"));

builder.Build().Run();
