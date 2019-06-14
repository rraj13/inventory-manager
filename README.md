# Apple Product Inventory Manager

## Introduction

Hi there! Here I have built a inventory management system for Apple products, allowing users to add, update and delete products from inventory. Written in C#, this console application is connected with a SQL Server database to hold information on all the existing products. However, because it is a console application, it unfortunately cannot be deployed to Github or Heroku, so I have made a short video demonstrating the program! Please see below: 

LINK

Please read on for more details regarding technologies, principles used and general methodologies!

## Technologies

C# <br>
SQL Server <br>
.NET Console <br>
Object Oriented Programming

## General Methodologies

The main idea behind this application was allowing users to perform basic C.R.U.D operations on an inventory database. The user runs the program and is greeting with a basic read function, displaying all the existing products in inventory. From here, they can enter one of the following commands: Add, Update or Delete, and depending on their input, relevant data is gathered and a SQL Query is performed.

In terms of the structuring the program, I have followed the Object-Oriented Programming paradigm. Specifically, I created a class for "Product", which essentially serves as a model for adding a product to the database, as well as classes for the program logic and database query functions. The program calls on these classes and methods in the Main() function.

This was my first C#/.NET application, and it was wonderful to learn the nuances of the language, apply Object-Oriented Programming principles as well as connect to a SQL Server!

Please reach out with any questions!

