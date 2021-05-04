# Employee-Management-system
An Employee Management system with several features such as image uploading, CRUD operations . Written in ASp.Net CoreWeb API, Angular11, MSSQL . ( 5 layers application )
First of all, I have added the DB script so regardless of your db instance version you can just run the script and the tables and procedures will be created.
For the API it's devided into several parts. The Dalc ( data access layer component) its role is so dummy just to call the procedures from the DB and return it to the BLC. The BLC ( business logic component ) its role is to take the results from the DALC and add up your own rules, such as sorting the data, removing data where date is > todays date etc..
The webAPI is also dummy its role is just to take the filtered data from the BLC and return it to the interface. 
