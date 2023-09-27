# Ballast Lane Application - Technical Exercise

## Demo User Story
Create a WebAPI to store Students and Courses data, the web api should allow to create students, courses
and register students to courses.
It is also required to provide an endpoint to login users and register

## Constraints
- Use Clean Architecture 
- DO NOT use Entity Framework
- The database should contain At Least ONE table in addition to users table
- Add Docker support

## Solution
The following image demonstrate the architecture of the proposed solution indicating the names of the projects
in their correspondant level:
![Architecture](ArchitectureModel.JPG)

### Libraries/Frmks used
- NHibernate for db access
- Swagger
- AutoMapper
- netcore DI
- Log4Net(I added a not in the place in which we could used but not added)
- NUnit/Moq

## Notes 
Some TODO's and dummy code was added to some places I didn't consider too relevant for the present excersise.
also because of the limited time,  not all possible unit tests were added. only the ones I thought enough to demonstrate how to do it the rest


 
