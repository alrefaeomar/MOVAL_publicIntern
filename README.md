# Check In App Missouri Valley College
![Screenshot1](https://github.com/alrefaeomar/MOVAL_publicIntern/blob/main/Screenshots/Screenshot%202021-03-29%20103145.jpg)

## Table of Contents
#### 1. [Instructions](#instructions) 
#### 2. [Technologies Used](#technologies-used)
#### 3. [Usage](#usage)


## Introduction
Since we are facing a pandemic right now, the need of a contactless measurement is a must. Thus, a good measurement for this is to have a Web application where Student can access their information and check what academic papers they need prior to attend to the institution. 

## Technologies Used
* HTML
* CSS
* Javascript
* C#
* SQL Server
* Bootstrap


## Instructions

### Prequisites
The first action needed to use this application is to clone it, by using:
```
$ git clone https://github.com/alrefaeomar/MOVAL_publicIntern
```

Then, Visual Studio (preferably Visual Studio 2017) will be needed in order to modify or alter the components inside the application, such as the Controllers, Layout, etc.

### Installation
In order this Web application to be used in a different servers and computers, since the server are named and configured different. The following code needs to be changed according the SQL database information of the server that you will be using with this app.


On the Web.config file located in the main folder, the *connectionString* has to be changed to the name of the Server, the *Initial Catalog* to the name of the Database, the *ID* to the name of the user in the SQL server, and then the *password* of the user.
```
<connectionStrings>
  <add name="con" connectionString="Data Source=SEBASTIANCAPPAD\SQLEXPRESS01; Initial Catalog=CheckInDB;Persist Security Info=True;User ID=admin;Password=0000;MultipleActiveResultSets=true;" />
 </connectionStrings>
  
```

On the CheckInController.cs located in the Controller folder, the SQL query can be changed according to the column names created in the database, so the query can be executed without problems. 
```
            string sqlQuery = "SELECT STD_NAME, STD_ENTRANCE, STD_RESIDENCE FROM STUDENT_TABLE WHERE STD_ID=@sid";

```

## Usage
The students will be able to input their ID numbers in order to check what needs to be done in the offices of the college, also their residence and entrance. It is as easy as the user input his or her ID and click on the submit button to view their information.

## Acknowledgements

* [Font-Awesome](https://fontawesome.com/)
* [W3Schools](https://www.w3schools.com/)
* [BootStrap](https://getbootstrap.com/)
* [Missouri Valley College](https://www.moval.edu/)

