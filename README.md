Municipality API
This is a .NET API designed to interact with municipal data, fetching and processing information about various municipalities, including their IBGE codes, names, and other related details. The API is backed by MongoDB, where municipality records are stored and queried.

Features
Municipality Information: Includes details such as the municipality's name, IBGE code, and foundation year.
CRUD Operations: Perform Create, Read, Update, and Delete operations on municipalities.
MongoDB Integration: Data is stored and retrieved from MongoDB.
Technologies
Backend: .NET Core / ASP.NET Core
Database: MongoDB
ORM: MongoDB.Driver
Data Generation: Bogus (for generating test data)
Installation
Prerequisites
Make sure you have the following installed:

.NET SDK
MongoDB (or a MongoDB cloud account)
Postman or any API testing tool
Steps to Run the Project Locally
Clone this repository:

bash
Copiar
Editar
git clone https://github.com/yourusername/municipality-api.git
Navigate into the project directory:

bash
Copiar
Editar
cd municipality-api
Restore the dependencies:

bash
Copiar
Editar
dotnet restore
Configure MongoDB connection:

Open the appsettings.json file.
Update the connection string for MongoDB with your local or cloud MongoDB instance.
json
Copiar
Editar
"ConnectionStrings": {
  "MongoDb": "mongodb://localhost:27017/municipalitydb"
}
Run the project:

bash
Copiar
Editar
dotnet run
The application will start on http://localhost:5000.

Using the API
Once the application is running, you can test the endpoints using Postman or any HTTP client.

Endpoints
Get all municipalities

GET /api/municipios
Retrieves a list of all municipalities stored in the database.
Get a municipality by ID

GET /api/municipios/{id}
Retrieves a municipality by its MongoDB ID.
Create a new municipality

POST /api/municipios
Creates a new municipality record.
Request body example:

json
Copiar
Editar
{
  "CodigoMunicipioTom": "3047",
  "CodigoMuniciopioIBGE": "2932457",
  "MunicipioTom": "Umburanas",
  "MuniciopioIBGE": "Umburanas",
  "Uf": "BA"
}
Update a municipality

PUT /api/municipios/{id}
Updates an existing municipality.
Request body example:

json
Copiar
Editar
{
  "CodigoMunicipioTom": "3047",
  "CodigoMuniciopioIBGE": "2932457",
  "MunicipioTom": "Umburanas",
  "MuniciopioIBGE": "Umburanas",
  "Uf": "BA"
}
Delete a municipality

DELETE /api/municipios/{id}
Deletes a municipality by its MongoDB ID.
Data Model
Municipality Model
The Municipio class represents the structure of a municipality object:

csharp
Copiar
Editar
public class Municipio
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [Key]
    public ObjectId Id { get; set; }

    [BsonElement("CÓDIGO DO MUNICÍPIO - TOM")]
    [BsonRequired]
    public string CodigoMunicipioTom { get; set; }

    [BsonElement("CÓDIGO DO MUNICÍPIO - IBGE")]
    [BsonRequired]
    public string CodigoMuniciopioIBGE { get; set; }

    [BsonElement("MUNICÍPIO - TOM")]
    [BsonRequired]
    public string MunicipioTom { get; set; }

    [BsonElement("MUNICÍPIO - IBGE")]
    [BsonRequired]
    public string MuniciopioIBGE { get; set; }

    [BsonElement("UF")]
    [BsonRequired]
    public string Uf { get; set; }
}
Example JSON Representation
The following is an example of a municipality object in JSON format:

json
Copiar
Editar
{
  "_id": "67b73c621ee39a4c3bc50804",
  "CÓDIGO DO MUNICÍPIO - TOM": "3047",
  "CÓDIGO DO MUNICÍPIO - IBGE": "2932457",
  "MUNICÍPIO - TOM": "Umburanas",
  "MUNICÍPIO - IBGE": "Umburanas",
  "UF": "BA"
}
Error Handling
The API returns appropriate HTTP status codes and error messages. Example:

404 Not Found: If the municipality with the specified ID does not exist.
400 Bad Request: If the request data is invalid.
500 Internal Server Error: If an unexpected error occurs.
Data Generation for Testing
For testing purposes, the API uses Bogus to generate fake data for municipalities. This is useful for loading the database with sample records for development and testing.

Contributing
If you would like to contribute to this project, feel free to fork the repository, create a branch, and submit a pull request with your changes. Ensure that you follow best practices for coding standards and write tests for any new features.

License
This project is licensed under the MIT License - see the LICENSE file for details.