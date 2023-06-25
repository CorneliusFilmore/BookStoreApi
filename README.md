# Web API with PostgreSQL Database in Docker Container

This is a sample Web API implemented in .NET 6 using a PostgreSQL database running in a Docker container. The API provides endpoints for managing authors in a book store.
Prerequisites

Before running the Web API, make sure you have the following installed on your machine:

    .NET 6 SDK
    Docker

## Getting Started

To run the Web API with the PostgreSQL database in a Docker container, follow these steps:

    Clone the repository or download the source code.

    Build the Docker image:

docker build -t bookstoreapi .

Run a Docker container with the built image:

arduino

    docker run -d -p 8080:80 --name bookstore-container bookstoreapi

    The API should now be accessible at http://localhost:8080/api/author.

## Api Endpoints - Author Controller
The following API endpoints are available:
Get Author List

    URL: GET /api/author
    Response:
        Status code: 200 (OK)
        Body: Array of author objects

Get Author by ID

    URL: GET /api/author/{id}
    Parameters:
        id: ID of the author to retrieve
    Response:
        Status code: 200 (OK)
        Body: Author object
    Error response:
        Status code: 404 (Not Found)

Add Author

    URL: POST /api/author
    Request body: Author object
    Response:
        Status code: 201 (Created)
        Body: Created author object
    Error response:
        Status code: 400 (Bad Request)

Delete Author

    URL: DELETE /api/author/{id}
    Parameters:
        id: ID of the author to delete
    Response:
        Status code: 204 (No Content)
    Error response:
        Status code: 404 (Not Found)

Update Author

    URL: PUT /api/author
    Request body: Author object
    Response:
        Status code: 200 (OK)
        Body: Success message
    Error response:
        Status code: 204 (No Content)
        Body: Error message

        API Endpoints - Book Controller

## Api Endpoints - Book Controller

    URL: POST /api/book
    Request body: Book object
    Response:
        Status code: 201 (Created)
        Body: Created book object
    Error response:
        Status code: 400 (Bad Request)

Get Book List

    URL: GET /api/book
    Response:
        Status code: 200 (OK)
        Body: Array of book objects

Get Book by ID

    URL: GET /api/book/{id}
    Parameters:
        id: ID of the book to retrieve
    Response:
        Status code: 200 (OK)
        Body: Book object
    Error response:
        Status code: 404 (Not Found)

Delete Book

    URL: DELETE /api/book/{id}
    Parameters:
        id: ID of the book to delete
    Response:
        Status code: 204 (No Content)
    Error response:
        Status code: 404 (Not Found)

Update Book

    URL: PUT /api/book
    Request body: Book object
    Response:
        Status code: 200 (OK)
        Body: Success message
    Error response:
        Status code: 204 (No Content)
        Body: Error message


Database Configuration

The Web API is configured to connect to a PostgreSQL database running in a Docker container. The connection string can be configured in the appsettings.json file.

By default, the following connection string is used:

json

    "ConnectionString": "Host=localhost;Port=5432;Database=bookstore;Username=postgres;Password=your_password"

Make sure to replace your_password with the actual password for the PostgreSQL database.
Dependencies

The Web API uses the following dependencies:

    MediatR - A simple mediator pattern implementation for .NET.
    Microsoft.AspNetCore.Mvc - ASP.NET Core MVC framework for building Web APIs.

Conclusion

This Web API provides basic functionality for managing authors in a book store. It demonstrates how to use .NET 6, MediatR for handling commands and queries, and PostgreSQL as the database backend. The API can be easily extended to include additional features and endpoints as per your requirements.