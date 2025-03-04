# GrpcGreeter: With Service Reflection

## Purpose

This is a simple C#, .NET9, and AspNetCore application implementing the
ubiquitous gRPC Greeter application. This example adds service reflection,
so the service can be queried about its endpoints and messages.

## Configuration

You will need to have a gRPC client in order to experiment with this service.
I recommend grpcurl (https://github.com/fullstorydev/grpcurl), which is free
CLI utility.

## Useful Commands

After launching the service locally, use its localhost and port in your
interactions with the service using grpcurl.

### Describe All Endpoints

grpcurl -plaintext localhost:5132 describe

`grpc.reflection.v1alpha.ServerReflection is a service:
service ServerReflection {
rpc ServerReflectionInfo ( stream .grpc.reflection.v1alpha.ServerReflectionRequest ) returns ( stream .grpc.reflection.v1alpha.ServerReflectionResponse );
}
greet.Greeter is a service:
service Greeter {
rpc SayHello ( .greet.HelloRequest ) returns ( .greet.HelloReply );
}`

### Describe a Message

grpcurl -plaintext localhost:5132 describe greet.HelloRequest

greet.HelloRequest is a message:
`message HelloRequest {
string name = 1;
}`

### Send a SayHello Message

grpcurl -plaintext -d '{"name": "Mike"}' localhost:5132 greet.Greeter/SayHello

`{
"message": "Hello Mike"
}`


