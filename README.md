# InternetMoviesOnDemand 
Api To Authenticate, Authorize, Add, Update and View the category wise movies. 


This API is made using ASP.Net Core 2.2, In Memory Database using List of Collection, Jwt Token for authentication and authorization.

The project is divided into 3 modules to keep loose coupling. Also in terms of large project this focus on modularity apporach, thus in future if required we can deploy different modules on different servers.

1) InternetMoviesOnDemand.Repository : It contains the DataContext, The Repository for User, Video, Category. I have made different interface for UserRepository, VideoRepository & CategoryRepository. IT contains Models for User, Videos and Category. Which are used to pass Data to the Database.

2) InternetMoviesOnDemand.BusinessAccessLayer: As the name suggest it is used to write the Business logic for CRUD operation for User, Video and Category. IT also contains the ViewModels needed to pass the data. This Layer contains reference to the Repository layer.

3) InternetMoviesOnDemand.Api: This is the Top Layer which is access to the users. IT contains a UserHelper class which is used to genrate the JWT token. JWT token contians claims for userid, role. This layer contains reference to the Business Access Layer.

There are two roles used = "Administrator" and "Viewer".
The Add and Delete Functionality is specific to Administrator for Video and Category.

A new User can be registered using the register method of the User controller.


To Run the project, You will need Visual Studio 2017, .Net core 2.2 installed on your machine.
Download the internetMoviesOnDemand project and open it with visual stuido.

The test project is in progress.

