# PaginationWithApi Project

This project contains an API and an MVC application developed using ASP.NET Core. The data is provided using the "NYC Taxi" sample database.

## Database

The project is integrated with Microsoft's [NYC Taxi database](https://learn.microsoft.com/en-us/sql/machine-learning/tutorials/demo-data-nyctaxi-in-sql?view=sql-server-ver15#download-files). This database contains 1.7 million records.

## API Details

The API includes a controller named NytaxiController. The controller has the following functions:

- `GetAll`: A GET endpoint that retrieves all data. For example:
  ```http
  GET /api/Nytaxi/GetAll

- `GetPaged`: A GET endpoint that retrieves data with pagination and sorting. Users can specify the desired page size. The GetPaged endpoint retrieves data based on the requested page size using the pageIndex, pageSize, and sortOrder parameters. For example:
  ```http
  GET /api/Nytaxi/GetPaged?pageIndex=1&pageSize=100&sortOrder=Medallion
	
- `SearchWithPagedByMedallion`:  An endpoint for searching based on Medallion data. It allows users to search using the pageIndex, pageSize, searchParameter, and optionally sortOrder parameters. For example:
  ```http
  GET /api/Nytaxi/SearchWithPagedByMedallion?pageIndex=1&pageSize=100&sortOrder=pickupDatetime&searchParameter=D9EFD19ACE46CDC57BD7B05B30D9ED9D


## MVC (UI) Details

The UI section includes a table created using Bootstrap.

- Page Size Selection: Users can choose the page size as 10, 50, or 100.
- Sorting: Users can click on column headers to sort data in ascending or descending order.
- Search: Users can filter data for a specific Medallion using the search box.
- Paging Buttons: Paging buttons are numbered buttons located below the table. These buttons enable the user to navigate to the desired page. You can navigate through the dataset by clicking on the paging buttons.

AJAX is used on the UI side to communicate with the API.

![Data Table](/screenshots/table.png)

## How to Use

1. Clone the project files to your computer.
2. Download the NYTaxi database from Microsoft and add it to SQL Server.
3. Update the database connection settings in the appsettings.json file.
4. Open the project files with Visual Studio or your preferred IDE.
5. Start the project and view the application in your browser.
