# Povio FlowerSpot

## About project
The app is used for flower spotting while hiking, traveling, etc. 
Users can check out different flowers, their details, and sightings as well as add their owm. 
Think of it as Instagram, but only for flower spotters.

## Requirements
Must have installed:
- .NET 6
- Docker

Optional to be installed:
- Postman
- Docker Desktop

## How to get the project up and running
1. Clone the project
2. Run command `docker-compose up -d` in project's root
3. Start the project
4. If everything is ok, Swagger page inside of browser should open
5. You can use preseeded user to test out requests
    - **username**: `test` 
    - **password**: `test`
6. Happy coding :)

## Additional information
You can use the `Povio - FlowerSpot.postman_collection.json` file and import it into your Postman client. 
Database migrations have been configured to be migrated automatically on application startup. 
Please note that this is not a best practice by any means, rather to enable the app to be started as easy as possible. 

## Project structure
Project is built using principles of the clean architecture with .NET 6, C# 10 and PostgreSQL as a database provider.

- Solution Items: *contains `docker-compose.yaml` and `Povio - FlowerSpot.postman_collection.json` postman collection*
- src
    - API: *contains Api project*
    - Core: *contains business logic, request/response contract models and domain entities*
    - Infrastructure: *contains external clients cofiguration and persistence configuration*
- tests
    - Unit tests
    - Integration tests
    
## Further improvements
We could introduce Identity Service to separate authentication and authorization from the main app. 
Further on, we could introduce Redis to cache number of likes for each sighting so we don't have to recalculate it all over again. 
Personally, I'd introduce also MassTransit if we were going to make a distributed system out of this. 
To enhace logging experience SEQ could be added as well. Also if app gets larger we could add Benchmark tests and Stress/Load Tests using k6. 

## Contributors
Code is written and maintained by Nisvet Mujkic. You can reach me at: nisvet.mujkic@outlook.com.
