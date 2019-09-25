# APIGateway
This is Checkout.com .Net challenge attempt designed in .Net Core 2.2.The API Gateway is designed as a RESTFUL API

# Assumptions

1.Only an integer amount is allowed.Reference was taken from [current checkout api](https://api-reference.checkout.com/#tag/Payments/paths/~1payments/post)

2.Cvv 3 or 4 characters

3.Use of [three-character ISO 4217 currency symbol](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.regioninfo.isocurrencysymbol?view=netcore-2.2) for currency

# Features

1.Get endpoint to get a specific payment detail
2.Post endpoint to process a payment

In addition to these 2 main requirements the following extra requirements have also been designed

- Application logging
 
- API client

- Swagger UI

- MS Test Unit Test

- API versioning


# Demo
![Swagger UI](https://i.gyazo.com/eaa6aebafe5f87257aa79d89dd19fd23.png "Swagger UI")
# Improvements

- Application logging

  ElasticSEARCH can be added to allow efficient debugging.

- Server Side Caching 

  A memory based cache store like Redis could be used to cache Get request in RAM.Care should be taken to delete a resource from cache     as well if a delete operation has been performed.
  
- SSL Encryption
  
  The API gateway domain should have a valid SSL domain to prevent MITM attacks and snopping.
  
- Performance testing

  Stress testing could be performed once the api is hosted so as to ensure that the API is able to handle the load in production.This     could be performed by an external service such as BlazeMeter
  

 
  
  
