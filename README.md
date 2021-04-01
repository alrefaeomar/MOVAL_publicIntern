# Check In App Missouri Valley College
![Screenshot1](https://github.com/alrefaeomar/MOVAL_publicIntern/blob/main/Screenshots/Screenshot%202021-03-29%20103145.jpg)

## Table of Contents
* [Introduction](#introduction) 
* [Technologies Used](#technologies-used)
* [Instructions](#instructions)
  * [Prequisites](#prequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Technical Documentation](#technical-documentation)
* [Acknowledgements](#acknowledgements)


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

## Technical Documentation
On the *CheckInController.cs*  we have two Index action methods. One will handle the view of the page, and the secon one will handle the functionability of the app. We use  `[HttpPost] ` in order to send the data inputted in the form to the database, and display it in the Tables and text boxes. One good thing about using `[HttpPost] ` is that it hides information from the URL, being more secure that `[HttpGet]` method.
```
  [HttpPost]
        public ActionResult Index(string stdSearch, Student student, string Button)
        {
          ...
        }
```

On the First *Index* action method, we set three parameters, **stdSearch** will help to handle the query in order to search for the ID of an student, **Student student** passes the current model used for this application, an **string Button** handles the *Clear Data* Button, so students will be able to clear all the fields of text.
   
Moving on with this Action method, we establish our connection string, so we can execute Sql queries and retreive the data from the database. We define a string for our query, where the two tables **STUDENT_TABLE** and **OFFICES_TABLE** are joined, so the attributes can be selected based on the ID **@sid**.
```
  SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            //Select Table Where student Id is the Input 
            string sqlQuery = @"SELECT STUDENT_TABLE.STD_ID, STD_NAME, STD_ENTRANCE, STD_RESIDENCE, REGISTRAR, 
                FIN_AID, BUSS_OFFICE, ADMISSIONS, CONSENT_TREAT, MED_ALERT, IMMUNIZATIONS, EMERG_CONTACT FROM STUDENT_TABLE
                INNER JOIN OFFICES_TABLE ON STUDENT_TABLE.STD_ID = OFFICES_TABLE.STD_ID WHERE STUDENT_TABLE.STD_ID=@sid";

```



## Acknowledgements

* [Font-Awesome](https://fontawesome.com/)
* [W3Schools](https://www.w3schools.com/)
* [BootStrap](https://getbootstrap.com/)
* [Missouri Valley College](https://www.moval.edu/)

