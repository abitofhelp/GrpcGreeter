using GrpcGreeterService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

var env = app.Environment;
if (env.IsDevelopment()) app.MapGrpcReflectionService();

// Configure the HTTP request pipeline.
app.MapGrpcService<Greeter>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client, such as grpcurl.");

app.Run();