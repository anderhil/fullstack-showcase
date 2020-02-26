# Task

Web Application for managing savings deposits:

* User must be able to create an account and log in.
* When logged in, a user can see, edit and delete saving deposits he entered.
* Three roles with different permission levels: a regular user would only be able to CRUD on their owned records, a user manager would be able to CRUD users, and an admin would be able to CRUD all records and users.
* A saving deposit is identified by a bank name, account number, an initial amount saved (currency in USD), start date, end date, interest percentage per year and taxes percentage.
* The interest could be positive or negative. The taxes are only applied over profit.
* User can filter saving deposits by the amount (minimum and maximum), bank name and date.
* User can generate a revenue report for a given period, that will show the gains and losses from interest and taxes for each deposit. The amount should be green or red if respectively it represents a gain or loss. The report should show the sum of profits and losses at the bottom for that period. 
* The computation of profit/loss is done on a daily basis. Consider that a year is 360 days. 
* REST API. Make it possible to perform all user actions via the API, including authentication

# Frontend

Frontend was developed using Angular 7.1.2

Project is structured with separate communication services, models, components, etc.
Bootstrap styles were used for the application with some custom tweaks

Using the UI is quite straightforward, on Home screen there are buttons which lead to the data tables,
from where user can edit the data

Showing of data was based on the simple table, as there were no requirements for something more advanced
Actions as links on the table, different users can access different actions 

# Backend

ASP.NET Core 2.1 using EF Core for working with data
SQL Server as database
JWT Tokens for AUTH
ASP.NET Roles for roles

API is quite simple, I implemented it on go, I have in mind some refactoring I would do, but not for the current stage of the project
