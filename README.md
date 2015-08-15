# Easy Reporting Tool
An Easy, Fast and Lightweight web based report publishing tool based on .NET 4 and SQL Server

#Inspiration
Basically I needed a lightweight web application to share any required ad-hoc queries.
I managed to find some based on PHP and MySql but I had no luck with C#/Sql Server so I decided to build one myself.

#How it works
Navigate to /publisher.aspx and fill in the details of your query. Details include:
server/instance name, catalog, db username, db password and the sql query itself.<br/>

After hitting save the data is stored in the project's database (so it can be used later) and a url is given to the user.
This URL can be distributed and accessed directly. On the report page one finds basic report
functionality like filter, pagination and sorting.

#Current Limitations
Currently the data is being transferred as a whole to the browser, that means that if the query returns x number of rows
all will be transferred to the clients browser and then cut off for pagination. This is because the current pagination works on the client side.
All data will be displayed in tabular format.


# TODO
[x] Database creation script<br/>
[x] User Documentation<br/>
[ ] Installation notes<br/>
[ ] Add download to CSV<br/>
[ ] Add API for automatic creation of reports<br/>
[ ] Ability to display graphs<br/>
[ ] Ability to display geographic maps<br/>