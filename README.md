# InfoTrackDevelopmentProject

First of all I would like to thank infotrack for giving me this opportunity to showcase my skills, going to have my two sleepless nights back.

## ConnectionStrings
1. first set **WebScrape.Data** as start up project
    there is a **WebScrapeDBContextFactory** object for Database Migration and Seeding
    Update-Database
2. WEB API
    in project **WebScrape.API** appsettings.json

## WebScrape.API
1. API-First approach: link between the data service and business
2. the 2 most important abstraction in this project, which helps decouple data flow from business logic
    ```csharp
    builder.Services.AddScoped(typeof(IRankValueRetrieve), typeof(WebScrapeRankRetrieve));
    builder.Services.AddScoped(typeof(IWebScrapeSearchLogic), typeof(SearchThenStoreRankLogic));
    ```
3. By changing the implementation of the abstract interface new business logic can be achived, with no impact on the underlying data link
4. **GET  /Search**: perform a rank search without DB - fulfilled by  WebScrapeRankRetrieve
5. **POST /Search**: perform a rank search with will record - fulfilled by  WebScrapeRankRetrieve & SearchThenStoreRankLogic
6. **GET  /Rank**  : get all ranking details related to current search only - did not involve the business layer

 
## WebScrape.Business
   where I thought of some different logic.

## WebScrape.Service
1. I spend most of my time on implementation
2. CQRS Pattern With MediatR
3. FluentValidation (auto,thus keeping the API controller lean yet powerful)
4. MediatR Pipeline Behaviors, I have implemented the 3 common ones (validation, logging and errors)  
    ```csharp
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
    cfg.AddOpenBehavior(typeof(ExceptionBehavior<,>));
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    ```
## SearchEngine.Library
1. feels to me too much business logic in it so made it into a standard class library
2. Factory method pattern with
3. 2 dependency injection (data & parse)

## WebScrape.Web
1. need change the port 7167 if not avaliable 
    ```javascript
    const { createApp } = Vue;
    const API_Host = 'https://localhost:7167/';
    ```
2. lightweight, not really need the razor pages capability
3. Vue,bootstrap grid layout SPA
4. JavaScript fetch() promise pattern
5. with help of Chart.js, I manager to show Trends / History as a diagram
6. I believe UI design should be minimalistic and focus on delivering data to the user without requiring too much navigation.
7. With this in mind, the UI consists of only one button but provides maximum data output.


## WebScrape.Data
1. Repository Pattern
2. I setup a hash value as indexing, so I can quickly find out the exact search combination made
    ```csharp
    public new string GetHashCode()
    {  
        using (HashAlgorithm algorithm = SHA256.Create())
            return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(SearchEngine + KeyWord + TargetURL)));
    }
    ```
3. with this the Trends / History in the UI diagram is all related to the search you just made, much more meaningful than list of random searches.