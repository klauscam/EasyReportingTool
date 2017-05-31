# Easy Reporting Tool
An Easy, Fast and Lightweight web based report publishing tool based on .NET 4 and SQL Server

# License
Apache License Version 2.0

# Inspiration
Basically I needed a lightweight web application to share any required ad-hoc queries.
I managed to find some based on PHP and MySql but I had no luck with C#/Sql Server so I decided to build one myself.

# How it works
Navigate to /publisher.aspx and fill in the details of your query. Details include:
server/instance name, catalog, db username, db password and the sql query itself.<br/>

After hitting save the data is stored in the project's database (so it can be used later) and a url is given to the user.
This URL can be distributed and accessed directly. On the report page one finds basic report
functionality like filter, pagination and sorting.

# Requirements
+ IIS 6 or 7
+ SQL Server 2008 or later

# Installation
+ So first, create a virtual directory in IIS and point it to the root of the project
+ Go to your SQL Server and create a new database
+ Grap the file named database.sql and execute it against you newly created database
+ Go to web.config file in the root directory and modify the connection string to match yours
+ Lastly, go to you browser and navigate to your virtual directory eg. http://localhost:8080/publisher.aspx
+ If the web page shows, your installation was successful

# Current Limitations
Currently the data is being transferred as a whole to the browser, that means that if the query returns x number of rows
all will be transferred to the clients browser and then cut off for pagination. This is because the current pagination works on the client side.
All data will be displayed in tabular format.


# TODO
+ Add download to CSV
+ Add API for automatic creation of reports
+ Ability to display graphs
+ Ability to display geographic maps

Buy me a beer using Bitcoin
## [163anEKNWhuRuv1srtPcvzEw7iLPQnz1qr](bitcoin:163anEKNWhuRuv1srtPcvzEw7iLPQnz1qr)
