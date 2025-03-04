using Grpc.Core;

namespace GrpcGreeterService.Services;

public class Greeter(ILogger<Greeter> logger) : GrpcGreeterService.Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        logger.LogDebug("SayHello called with Name={Name}", request.Name);
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}