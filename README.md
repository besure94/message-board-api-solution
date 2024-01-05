# Message Board API

#### An application that allows users to search for and post messages for specific message groups.

#### By Brian Scherner

## Technologies Used

* C#
* .NET
* MySQL

## Description

This application has full CRUD (Create, Read, Update, Delete) functionality. Users can GET (Read) all messages related to a specific group. They can also view a list of all groups, and they can additionally filter messages by inputting specific date parameters.

Users can POST (Create) messages by posting them to a specific group. They can also PUT (Update) and DELETE (Delete) messages, but only if they were written by the user. The "author" query value must match the value for the "author" property in the message. The ID's must also match, since many messages can be written by the same author.

## Setup Instructions

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-0-lessons-1-5-getting-started-with-c/3-0-0-01-welcome-to-c).

If you have not already, install the `dotnet-ef` tool by running the following command in your terminal:

```
dotnet tool install --global dotnet-ef --version 6.0.0
```

### Set Up and Run Project

1. Select the green button that says "Code", and clone this repository to your desktop.
2. Open your terminal and navigate to this project's production directory called `MessageBoardApi`.
3. Inside this production directory, create two new files: `appsettings.json` and `appsettings.Development.json`.
4. In the `appsettings.json` file, enter the following code. Make sure to replace the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL. For the LearnHowToProgram.com lessons, always assume the `uid` is `root` and the `pwd` is `epicodus`.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=message_board_api;uid=root;pwd=epicodus;"
  }
}
```

5. In the `appsettings.Development.json` file, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

6. Create the database by using the `Migrations` folder in the `MessageBoardApi` production directory. In the `MessageBoardApi` directory, run the command `dotnet ef database update`. This will create the database in MySQL.
    * If you want to create a migration, run the command `dotnet ef migrations add MigrationName`. `MigrationName` is your custom name for the migration, and should be written in UpperCamelCase.

## Testing API Endpoints

Within the production directory `MessageBoardApi`, run the command `dotnet watch run` to start making API calls using Swagger. This will automatically direct you to the domain _https://localhost:5001_.

You can also make API calls by using the [Postman](https://www.postman.com/) app, and running the command `dotnet run`. If you make API calls using Postman, use the domain _http://localhost:5000_. The available API endpoints will be shown below.

### Available EPI Endpoints

**Note: this API contains two versions. Both are properly functioning, but version 2 contains an additional feature that version 1 does not have. Depending on which version you want to test, simply place `v1` or `v2` after the `api` portion of the domain name. For these examples, I will be using `v2`.**

These API Endpoint examples use the domain _https://localhost:5001_, which is listed above. If you prefer to use Postman, you can use the other domain name listed above.

```
GET https://localhost:5001/api/v2/messages/
GET https://localhost:5001/api/v2/messages/groupList
GET https://localhost:5001/api/v2/messages/{id}
POST https://localhost:5001/api/v2/messages
PUT https://localhost:5001/api/v2/messages/{id}
DELETE https://localhost:5001/api/v2/messages/{id}
```

Note: `{id}` is a variable and should be replaced with the id number of the message that you want to GET, PUT, or DELETE. The id will be automatically created when you POST a message.

#### Optional Query String Parameters for GET Request

GET requests to `https://localhost:5001/api/v2/messages` can optionally include query strings to filter messages by different criteria.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| group    | String      | not required | Returns messages with a matching group value. |
| minimumDate        | String      | not required | Returns messages with a date value greater than the queried date. |
| maximumDate  | String      | not required | Returns messages with a date value less than the queried date. |
| pageNumber   | Number      | not required | Returns five reviews from a specified page number. |

The following query will return all messages with a group value of "Music Makers":

```
GET https://localhost:5001/api/v2/messages?group=music%20makers
```

The following query will return all messages with a minimum date value of 2019-01-01.
```
GET https://localhost:5001/api/v2/messages?minimumDate=2019-01-01
```

The following query will return all messages with a maximum date value of 2019-01-01.
```
GET https://localhost:5001/api/v2/messages?maximumDate=2019-01-01
```

The following query will return five messages from page two of the messages list:
```
GET https://localhost:5001/api/v2/messages?pageNumber=2
```

You can include multiple query strings by separating them with an `&`:

```
GET http://localhost:7245/api/messages?group=music%20makers&minimumDate=2019-01-01&maximumDate=2024-01-04
```

#### Additional Requirements for POST Request

When making a POST request to `https://localhost:5001/api/v2/messages/`, your request needs to include a "body". **Please note that when a POST request is successful, it will also automatically assign a time to the "date" value. You do not have to enter a time to create a "date". A simple "YYYY/mm/dd" format will suffice.** Example below:

```json
{
  "group": "Gardening",
  "userMessage": "Looking for nutrient-rich soil",
  "author": "herbalist024",
  "date": "2020-03-15"
}
```

#### Additional Requirements for PUT Request

PUT requests can only be made if the message was written by the person who wrote it. In other words, the author's name in the query must match the `author` property value in the message. The queried ID must also match the `messageId` property value in the message.

When making a PUT request such as `http://localhost:5001/api/messages/{id}?author=gamerchick`, your request needs to include a "body". Example below:

```json
{
  "messageId": 2,
  "group": "Gardening",
  "userMessage": "Looking to buy cheap tools",
  "author": "gamerchick",
  "date": "2024-01-05T18:33:25.622Z"
}
```

#### Additional Requirements for DELETE Request

Just like PUT requests, DELETE requests can only be made if the message was written by the person who wrote it. In other words, the author's name in the query must match the `author` property value in the message. The queried ID must also match the `messageId` property value in the message.

For example, making a DELETE request such as `'https://localhost:5001/api/v2/Messages/2?author=gamerchick` will successfully delete a message, as long as the ID and author in the query match the property values in the message.

## Known Bugs

None.

## License

MIT

Copyright(c) 2023 Brian Scherner