# LibraryApp.Server
Back-end project of Pet-application

## Installation
1. Clone the github repository:
```bash
git clone https://github.com/HikashiMlbb/LibraryApp.Server.git
```
2. Change directory to the local repository:
```bash
cd LibraryApp.Server
```
3. Restore dotnet dependencies:
```bash
dotnet restore
```
## Configuration
1. Go to the `src\LibraryApp.API\appsettings.json` and edit `ConnectionStrings`
2. Replace string `"SqlServer_Dev": "..."` with your own connection string.
3. Go to the `src\LibraryApp.Infrastructure\DependencyInjection.cs` and replace value of `const string DefaultConnection` to your own.
4. Create the database using cli command:
```bash
dotnet ef database update -p src\LibraryApp.Infrastructure -s src\LibraryApp.API
```
## Running
Execute cli command:
```bash
dotnet run --project src\LibraryApp.API -lp "http"
```
***
# Endpoints info
|**Method**|**Endpoint**|**Description**           |
|----------|------------|---------------           |
|**GET**   |`/api/books`|  Gets the list of books |
|**POST**  |`/api/books`|  Creates the book to the database |
|**PUT**   |`/api/books`|  Updates the book by given parameters |
|**DELETE**|`/api/books`|  Deletes the book with specified ID |
|-|-|-|
|**GET**   |`/api/authors`|  Gets the list of authors |
|**POST**  |`/api/authors`|  Creates the author to the database |
|**PUT**   |`/api/authors`|  Updates the author data in the database |
|**DELETE**|`/api/authors`|  Deletes the author from the database |

# Examples
1. Create a book:
```http
POST /api/Books HTTP/1.1
Host: localhost:5124
User-Agent: curl/8.2.1
accept: */*
Content-Type: application/json
Content-Length: 168

{
  "title": "A book with interesting title",
  "description": "The best book with interesting and long description",
  "publicationDate": "1956-08-29T00:00:00.000Z"
}
```

2. Get all books:
```http
GET /api/Books HTTP/1.1
host: localhost:5124
user-agent: curl/8.2.1
accept: */*
```
**Response**:
```json
[
  {
    "id": "c62f175c-fcff-4ec7-868d-ecc4b82d48bd",
    "title": "A book with interesting title",
    "description": "The best book with interesting and long description",
    "authorId": null,
    "publicationDate": "1956-08-29T00:00:00"
  }
]
```

3. Create an author:
```http
POST /api/Authors HTTP/1.1
Host: localhost:5124
User-Agent: curl/8.2.1
accept: */*
Content-Type: application/json
Content-Length: 96

{
  "name": "William Shakespeareeeee",
  "birthDay": "1564-04-23T00:00:00.000Z",
  "books": []
}
```

4. Get his ID:
```http
GET /api/Authors?Name=William%20Shakespeareeeee HTTP/1.1
host: localhost:5124
user-agent: curl/8.2.1
accept: */*
```
**Response**:
```json
[
  {
    "id": "801e969b-379d-4202-889d-6cf7e6dd8d48",
    "name": "William Shakespeareeeee",
    "books": [],
    "birthDay": "1564-04-23T00:00:00"
  }
]
```

5. Create a book with author:
```http
POST /api/Books HTTP/1.1
Host: localhost:5124
User-Agent: curl/8.2.1
accept: */*
Content-Type: application/json
Content-Length: 712

{
  "title": "Romeo and Juliet",
  "description": "\"Romeo and Juliet\" is a tragedy by William Shakespeare, telling about the love of a young man and a girl from two warring Veronese families — the Montagues and the Capulets. The plot of the tragedy revolves around how Romeo, upon learning of Juliet's death, rushes to say goodbye to her. In the family crypt of the Capulets, he stumbles upon Count Paris and kills him in the heat of a quarrel. Thinking that Juliet is dead, and not knowing that this is just a dream, Romeo drinks poison. Juliet wakes up and in despair, seeing his corpse, stabs herself.",
  "authorId": "801e969b-379d-4202-889d-6cf7e6dd8d48",
  "publicationDate": "1597-01-01T00:00:00.000Z"
}
```

6. Change Author name:
```http
PUT /api/Authors HTTP/1.1
Host: localhost:5124
User-Agent: curl/8.2.1
accept: */*
Content-Type: application/json
Content-Length: 83

{
  "id": "801e969b-379d-4202-889d-6cf7e6dd8d48",
  "name": "William Shakespeare"
}
```

7. Making first book a book of William Shakespeare:
```http
PUT /api/Books HTTP/1.1
Host: localhost:5124
User-Agent: curl/8.2.1
accept: */*
Content-Type: application/json
Content-Length: 104

{
  "id": "C62F175C-FCFF-4EC7-868D-ECC4B82D48BD",
  "authorId": "801e969b-379d-4202-889d-6cf7e6dd8d48"
}
```

8. List all books of William Shakespeare:
```http
GET /api/Books?AuthorId=801e969b-379d-4202-889d-6cf7e6dd8d48 HTTP/1.1
host: localhost:5124
user-agent: curl/8.2.1
accept: */*
```
**Response**:
```json
[
  {
    "id": "9eaa9d5f-65cc-44db-84cd-81835e9f341b",
    "title": "Romeo and Juliet",
    "description": "\"Romeo and Juliet\" is a tragedy by William Shakespeare, telling about the love of a young man and a girl from two warring Veronese families — the Montagues and the Capulets. The plot of the tragedy revolves around how Romeo, upon learning of Juliet's death, rushes to say goodbye to her. In the family crypt of the Capulets, he stumbles upon Count Paris and kills him in the heat of a quarrel. Thinking that Juliet is dead, and not knowing that this is just a dream, Romeo drinks poison. Juliet wakes up and in despair, seeing his corpse, stabs herself.",
    "authorId": "801e969b-379d-4202-889d-6cf7e6dd8d48",
    "publicationDate": "1597-01-01T00:00:00"
  },
  {
    "id": "c62f175c-fcff-4ec7-868d-ecc4b82d48bd",
    "title": "A book with interesting title",
    "description": "The best book with interesting and long description",
    "authorId": "801e969b-379d-4202-889d-6cf7e6dd8d48",
    "publicationDate": "1956-08-29T00:00:00"
  }
]
```

# Thank you for visit my github repository :3 <3
