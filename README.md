# StoreWebAPI İs Project by ASP.NET Web API, Using Clean Architecture Principle,It Built to be scalable maintainable.
## protobuf-net.Grpc adds code-first support for services over gRPC using either the native Grpc.Core API, fully-managed Grpc.Net.Client / Grpc.AspNetCore.Server API.

## Features
#### ASP.NET Web API
#### CQRS PATTERNS
#### Mediator Pattern
#### SOLID Principle
#### CQRS and MediatR
#### Mediator Pattern
#### SOLID PRİNCİPLE
#### gRPC Communication
#### AutoMapper
#### Entity Management
#### PostgreSQL Integration
#### Domain-Driven Design (DDD)

## Project Structure 
Protos : Contains .proto files that define the request and response messages for gRPC services.
Domain : Contain core business logic and entities.

DataAccess : Handles data access and integration with external services.

Application : Implement application services and use cases.

Services : Include various application services. 

## Technologies Used
PostgreSQL: Used as the database for storing application data.

Entity Framework Core: Used for interacting with the PostgreSQL database, providing ORM capabilities.

Microsoft.EntityFrameworkCore , Version : 7.0.0

Microsoft.EntityFrameworkCore.Tools

MediatR: Used to implement the Mediator pattern, enabling clean separation between different components of the application.

AutoMapper: Used for mapping between domain models and data transfer objects (DTOs).

gRPC: Used for communication between services, with support for Protocol Buffers.

Google.Protobuf

Grpc.Core.Api
