# Grpc-basis
A short overview about Grpc in C#

* how to setup
* use
* common features

## Create a Server Project

1. open Visual Studio (or other IDE)
2. Create a new Project
   * 2.1. take _"Grpc Service"_ (Project)

## Create a Shared Library

This ensures a _"single source of truth"_ (if both, client and server, are in C#)

1. Create/Add a new Project in the current solution
   * take _"Class Library"_truen
2. Now we can delete the proto files from the Server Project, we will include the shared library
   * Move proto-file from Grpc Service to Class Lib (.csproj should now have an entry ItemGroup>Protobuf)
4. Add dependencies to Grpc.Shared (Lib)
   * **Google.Protobuf** (Protobuf Runtime)
      * Protobuf is for de-/serialization of C# in efficient binary (Message encoding)
   * **Grpc.Tools** (Compiler)
      * Code generator (not used on runtime, only for compiling)
   * **Grpc** (Grpc Runtime)
5. Add Shared Lib to Server Project
   * right-click on _Grpc Service (Project) > Dependencies_ _"Add Project Reference"_ (select Grpc.Shared Project)
6. Change Settings for Grpc
   * right-click on proto-file (in Grpc.Shared Project)
   * or change .csproj ItemGroup > Protobuf > GrpcServices from "Server" to "Both"
7. Now we can build our solution
   * ensure correct using of shared GrpcService in Grpc.Service
  
> Both, Client and Server, get the Grpc Services and their Messages from the shared Lib

## Using in Client

Example as Console App in C#

1. Create a new Project (Console App)
2. Add dependencies to Grpc.Client
   * **Grpc.Net.Client**
3. Add Shared Lib to Server Project
   * right-click on _Grpc CLient (Project) > Dependencies_ _"Add Project Reference"_ (select Grpc.Shared Project)
4. Add Client Logic
   * open channel (_GrpcChannel.ForAddress(<url>); => url can be found in launchSettings.json of Grpc.Service)
   * create client (Client(channel);)
  
## Streaming

for streaming use **stream**-keyword as type of the returnvalue of a message
