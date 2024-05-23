# Sensitive Words Sanitizer API

This project implements a RESTful API to manage and sanitize sensitive words using ASP.NET Core and SQL Server.

## Features

- CRUD operations for sensitive words.
- Business logic to sanitize input strings by replacing sensitive words with asterisks.
- Integrated Swagger documentation.

## Requirements

- .NET 5.0 SDK
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



Navigate to http://localhost:5000/swagger to access the Swagger UI.



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











