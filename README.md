# Apple Product Inventory Manager

## Introduction

Hi there! Here I have built a inventory management system for Apple products, allowing users to add, update and delete products from inventory. Written in C#, this console application is connected with a SQL Server database to hold information on all the existing products. However, because it is a console application, it unfortunately cannot be deployed to Github or Heroku, so I have included screenshots with descriptions below!

Running program --> Read function is performed and all existing inventory products are displayed

![Alt text](InventoryScreenshots/dotnetrun.png?raw=true "Run Program")

Add product --> User types add command, enters details of new product and product is inserted into database

![Alt text](InventoryScreenshots/addproduct.png?raw=true "Add Product")

Update product --> User types update command, selects field to be updated, enters new text, and product is updated in database

![Alt text](InventoryScreenshots/updateproduct.png?raw=true "Add Product")

Delete product - User types delete command, selects product to be deleted by ID, and product is deleted from database

![Alt text](InventoryScreenshots/deleteproduct.png?raw=true "Add Product")

Final view of database - Mouse has been added (ID: 12), iPad (ID: 6) Description has been updated, and AirPods (ID: 10) has been deleted 

![Alt text](InventoryScreenshots/finalinventory.png?raw=true "Add Product")

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

