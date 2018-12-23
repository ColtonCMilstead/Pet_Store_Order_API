# Pet_Store_Order_API
A .NET Web Core Application for a pet store's order API, a Client API to use it, and XUnit testing. 

This Project accepts an order entry request with JSON, calculates the Total Cost of the order (if possible, meaning if product prices are entered
in the order), and has an XUnit test to confirm that the API successfully returns the correct order total. 

This Project has DummyData for an order with the Product Name, ID, and Price due to the URL links for the Inventory API being disabled.
New orders can be entered via a Post Method to URL: https://localhost:44373/api/orders. GET, PUT, and DELETE requests will return, edit, and delete
orders from the database respectively. 

This Project is using the SQL Server on Visual Studio 2017 for its database. 

VIEW THE ORDER DETAILS 
  Go to Client API. Open the 'wwwroot' folder. Right-click on the index.html file and click on 'View in Browser'. 
  The HTML page will display a list of order IDs currently in the DB. Below it is a text box to enter an Order ID to display
  that order's summary (list of products, quantity, and Total Cost). 



STEPS TO SET UP DB




