# Check In App Missouri Valley College

## Introduction
Since we are facing a pandemic right now, the need of a contactless measurement is a must. Thus, a good measurement for this is to have a Web application where Student can access their information and check what academic papers they need prior to attend to the institution. 

## Table of Contents
1. [Technologies Used](#technologies-used)
2. [Example2](#example2)
3. [Third Example](#third-example)
4. [Fourth Example](#fourth-examplehttpwwwfourthexamplecom)



## Technologies Used
* HTML
* CSS
* Javascript
* C#
* SQL Server
* Bootstrap

## Usage
The students will be able to input their ID numbers in order to check what needs to be done in the offices of the college, also their residence and entrance. It is as easy as the user input his or her ID and click on the submit button to view their information.

## Instructions
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
