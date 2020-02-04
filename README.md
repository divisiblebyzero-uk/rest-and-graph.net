[![Build Status](https://travis-ci.com/divisiblebyzero-uk/rest-and-graph.net.svg?branch=master)](https://travis-ci.com/divisiblebyzero-uk/rest-and-graph.net) ![.NET Core](https://github.com/divisiblebyzero-uk/rest-and-graph.net/workflows/.NET%20Core/badge.svg)
# Rest and Graph Demonstration project - .Net implementation

This is a project to demo REST and GraphQL using C# / EF Core. There are sister projects in Node.JS, Java and Kotlin.

NB this is not yet fully functional.

## Functional Description

The application has a simple entity model: Countries and Cities

### Country Example
```json
{
  "id": 1,
  "name": "UK",
  "language": "English"
}
```

### City Example
```json
{
  "id": 1,
  "name": "London",
  "country": {
    "id": 1,
    "name": "UK",
    "language": "English"
  },
  "size": "Huge"
}
```

These are modelled in the `entities` package.

## Implementation Description

By default, the application starts with a blank in-memory database, and uses EF to create the persistence structure and populate sample data.

There are several implementations:

### EF and ApiController

In the `controllers` package are two Crud controllers.

They have the following endpoints:
* /api/Countries - countries
* /api/Cities - cities

Note that the Cities are full-fat entities - ie the City record contains the entire Country record as well.

### GraphQL

In the `graphql` package are the Query and Mutation objects, the controller and schema for graphql.

The application includes an embedded graphiql interface, so fire it up and browse to /graphiql.

You can browse the API using the docs link at the right hand side of graphiql, or alternatively try one of the following:

#### List all countries
```graphql
{
  countries {
    id
    name
    language
  }
}
```

#### Grab a particular country
```graphql
{
  country(id: 1) {
    id
    name
    language
  }
}
```

#### Grab a particular city - NOT YET IMPLEMENTED
```graphql
{
  city(id: 1) {
    id
    name
    size
    country {
        name
    }       
  }
}
```


#### Insert a new country - NOT YET IMPLEMENTED
```graphql
mutation {
  createCountry(name: "Bolivia", language: "Bolivian")
  {
    id
  }
}
```

Behind the scene, the queries and mutations are using the manual JPA repositories used in the first implementation.

## Running the application

Run via "dotnet run".

As a convenience, / will return a web page with links to the live URIs.

