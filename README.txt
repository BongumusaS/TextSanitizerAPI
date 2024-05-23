# Sensitive Words Sanitizer API

This project implements a RESTful API to manage and sanitize sensitive words using ASP.NET Core and SQL Server.

## Features

- CRUD operations for sensitive words.
- Business logic to sanitize input strings by replacing sensitive words with asterisks.
- Integrated Swagger documentation.

## Requirements

- .NET SDK
- SQL Server

## Getting Started

### Configuration

Update `appsettings.json` with your database connection string.

### Migrations

Run the following commands to apply migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update


Running Application
dotnet run



Navigate to http://localhost:5000/swagger to access the Swagger UI. (Depending on your available local port)



Endpoints 
GET /api/SensitiveWords
POST /api/SensitiveWords
PUT /api/SensitiveWords/{id}
DELETE /api/SensitiveWords/{id}
POST /api/Sanitize







## Sanitize Controller

The `SanitizeController` provides an endpoint to sanitize input strings by replacing sensitive words with asterisks. It is used to process incoming messages and ensure that sensitive information is protected.

### Endpoint

- **POST /api/Sanitize/sanitize**: Sanitizes a string by replacing sensitive words with asterisks.

### Request

- **Method**: POST
- **URL**: `/api/Sanitize/sanitize`
- **Description**: Sanitizes a string by replacing sensitive words with asterisks.
- **Body**: A JSON string containing the input text to be sanitized.

### Response

- **Status Codes**:
  - 200 OK: The string was successfully sanitized.
  - 400 Bad Request: The request body is invalid or missing.

### Example

**Request:**

```json
POST /api/Sanitize/sanitize
Content-Type: application/json

{
  "input": "You need to create a string"
}





## Sensitive Words Controller

The `SensitiveWordsController` manages CRUD operations for sensitive words. It provides endpoints to retrieve, add, update, and delete sensitive words.

### Endpoints

- **GET /api/SensitiveWords**: Get all sensitive words.
- **POST /api/SensitiveWords**: Create a new sensitive word.
- **PUT /api/SensitiveWords/{id}**: Update an existing sensitive word.
- **DELETE /api/SensitiveWords/{id}**: Delete a sensitive word.

### Request and Response

Each endpoint accepts and returns JSON data. The request and response formats are as follows:

#### Get all sensitive words

- **Method**: GET
- **URL**: `/api/SensitiveWords`
- **Request Body**: None
- **Response**: A list of all sensitive words.

#### Create a new sensitive word

- **Method**: POST
- **URL**: `/api/SensitiveWords`
- **Request Body**: JSON object representing the new sensitive word.
- **Response**: The created sensitive word.

#### Update an existing sensitive word

- **Method**: PUT
- **URL**: `/api/SensitiveWords/{id}`
- **Request Body**: JSON object representing the updated sensitive word.
- **Response**: No content if successful.

#### Delete a sensitive word

- **Method**: DELETE
- **URL**: `/api/SensitiveWords/{id}`
- **Request Body**: None
- **Response**: No content if successful.

### Dependencies

- Microsoft.AspNetCore.Mvc
- Microsoft.EntityFrameworkCore
- Microsoft.Extensions.Logging
- System.Collections.Generic
- System.Linq
- System.Threading.Tasks
- TextSanitizerAPI.DataContext
- TextSanitizerAPI.Models
- Swashbuckle.AspNetCore.Annotations




### SQL Database Setup

To set up the SQL database, you can use the provided SQL script to create the necessary schema and tables.

1. Create a new database in SQL Server.
2. Run the following SQL script to create the `SensitiveWords` table:

```sql
CREATE DATABASE SensitiveWordsSanitizer;

USE SensitiveWordsSanitizer;

CREATE TABLE SensitiveWords (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Word NVARCHAR(100) NOT NULL
);



Deployment
To deploy this application in a production environment, follow these steps:

Prepare the Environment:

Ensure you have .NET SDK installed on your server.
Set up a SQL Server instance.
Publish the Application:

Run the following command to publish the application:
bash
Copy code
dotnet publish --configuration Release
This command will generate the necessary files in the bin/Release/net/publish directory.
Configure the Web Server:

Use a web server like IIS, Nginx, or Apache to host the application.
Configure the web server to point to the published files.
Set Up the Database:

Update the appsettings.json file or cloud service with the production database connection string.
Run the application to apply the migrations and create the necessary database schema.
Configure Environment Variables:

Set the environment variables for production, including the JWT settings if authentication is required.
Monitor and Maintain:

Set up monitoring to ensure the application is running smoothly.
Regularly back up the database and update the application with security patches and updates.
Enhancements for Production
Authentication and Authorization:

Implement JWT authentication to secure the endpoints.
Logging and Monitoring:

Integrate a logging framework (e.g., Serilog) to capture and store logs.
Use monitoring tools like Prometheus and Grafana to monitor the application's performance.
Scalability:

Containerize the application using Docker.
Deploy the application using Kubernetes for orchestration and scalability.
Error Handling:

Implement global error handling to catch and handle exceptions gracefully.
Caching:

Use caching mechanisms like Redis to improve performance.
This README provides a comprehensive overview of your project, including setup instructions, endpoint documentation, and deployment guidelines. It ensures that anyone reviewing your project can understand its functionality and deploy it in a production environment.

Double-check that all dependencies are correctly listed in your project files (e.g., csproj for .NET Core projects).
Verify that your database connection strings are configured appropriately for the production environment.
Make any necessary adjustments for production deployment, such as changing debug settings, error handling, and logging configurations.
Set Up Your Production Environment:

Choose a hosting provider for your production environment. Options include cloud providers like AWS, Azure, or Google Cloud, or using a dedicated server from a hosting provider.
Set up your production server or cloud instance with the necessary infrastructure components, including a web server (e.g., IIS, Nginx), database server (e.g., SQL Server), and any other required services.
Configure security settings, including firewalls, SSL certificates, and access controls, to protect your application and data.
Deploy Your Application:

Build your application for production using the appropriate build tools for your chosen technology stack (e.g., dotnet publish for .NET Core).
Upload your application files to your production server or cloud instance.
Configure your web server to serve your application. For example, set up a reverse proxy to forward incoming requests to your .NET Core application running on a specified port.
Ensure that your database is accessible from your production environment and that your application can connect to it using the correct connection string.
Test Your Deployment:

Perform thorough testing of your deployed application to ensure that it functions correctly in the production environment.
Test various scenarios, including normal usage, edge cases, and error conditions, to identify any potential issues.
Monitor the performance and stability of your application to identify and address any performance bottlenecks or stability issues.
Monitor and Maintain Your Production Environment:

Set up monitoring tools to track the health, performance, and usage of your application and infrastructure components.
Implement automated backups and disaster recovery procedures to protect your data and ensure business continuity.
Regularly update and patch your software and infrastructure components to address security vulnerabilities and ensure compatibility with the latest technologies.
Document Your Deployment Process:

Document the steps you followed to deploy your application to the production environment, including configuration settings, dependencies, and any customizations or adjustments made for production deployment.
This documentation will be useful for future reference and for onboarding new team members or administrators.



















