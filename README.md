# Pet Store Order API | Singlestone 
A .NET Web Core Application for a pet store's order API, a Client API to use it, and XUnit testing. 

This Project accepts an order entry request with JSON, calculates the Total Cost of the order (if possible, meaning if product prices are entered
in the order), and has an XUnit test to confirm that the API successfully returns the correct order total. 

This Project has DummyData for an order with the Product Name, ID, and Price due to the URL links for the Inventory API being disabled.
New orders can be entered via a Post Method to URL: https://localhost:44373/api/orders. GET, PUT, and DELETE requests will return, edit, and delete orders from the database respectively. 

The format for the JSON data is entered below. Note, if no Order Id is entered, one will be automatically generated. However, if no Product price or quantity is entered, the total can't be calculated. This is due to the Inventory API being disabled. The Dummy Data has an order already in the DB with Product details, so the cost can be calculated for it. 

{
	"orderID": "2",
  "customerId": "67890",
  "items": [
    {
      "productId": "qwertrr",
      "quantity": 1
    }
  ]
}

This Project is using the SQL Server on Visual Studio 2017 for its database.

# STEPS TO SET UP DB
- Open the Package Manager Console 
- Type "Drop-Databse" in the PM console
- Then type "Update-Database". This will upload the Items and Order tables under the PetStoreOrderAPI database folder.
- Open the SQL Server Object Extension window in VS to view the tables. 

# VIEW THE ORDER DETAILS 
  -Go to Client API project.
  -Open the 'wwwroot' folder. 
  -Right-click on the index.html file and click on 'View in Browser'. 
  
  The HTML page will display a list of order IDs currently in the DB. Below it is a text box to enter an Order ID to display
  that order's summary (list of products, quantity, and Total Cost). 








