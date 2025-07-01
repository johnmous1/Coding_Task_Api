Customer and Order Management API
A .NET API for managing customers and their orders, built with a focus on clean architecture using DDD and CQRS patterns.

✅ Requirements Checklist
This project fulfills the following requirements:

[x] Customer Management: Full CRUD operations (Create, Update, Delete) for customers.

[x] Order Management: API to create and view customer orders.

[x] Persistence: Uses Entity Framework Core with an in-memory database.

[x] Repository Pattern: Data access is abstracted through repositories.

[x] Unit of Work Pattern: Ensures transactional integrity for business operations.

[x] Sorted Order Iteration: Supports viewing customer orders sorted by date.

[x] Domain-Driven Design (DDD): Core logic is modeled in a rich domain layer.

[x] CQRS: Commands (writes) and Queries (reads) are segregated for clarity.

[x] XML Documentation: API endpoints are documented and visible in Swagger.

🛠️ Tech Stack
.NET 8

ASP.NET Core Web API

Entity Framework Core (In-Memory Provider)

MediatR (for CQRS implementation)

AutoMapper (for DTO projection)

Swagger/OpenAPI (for API documentation and testing)

🚀 Getting Started
Clone the repository.

Open the solution file (.sln) in Visual Studio 2022.

Press F5 or the Start button (▶) to build and run the project.

The API will launch, and a browser window will open to the Swagger UI (https://localhost:7253/swagger).

🧪 Testing Workflow
Use the Swagger UI to test the endpoints in the following order. You will need to copy the id from the response of one step to use in the request of the next step.

1. Create a Product
POST /api/products

Request Body:

JSON

{
  "name": "Laptop Pro",
  "price": 1200
}
Action: Copy the productId from the response.

2. Create a Customer
POST /api/customers

Request Body:

JSON

{
  "firstName": "John",
  "lastName": "Doe",
  "street": "123 Main St",
  "city": "Anytown",
  "postalCode": "12345"
}
Action: Copy the customerId from the response.

3. Create an Order
POST /api/orders

Request Body: Use the customerId and productId from the previous steps.

JSON

{
  "customerId": "PASTE_CUSTOMER_ID_HERE",
  "items": [
    {
      "productId": "PASTE_PRODUCT_ID_HERE",
      "quantity": 1
    },
    
    //if you want and other product:
    {
     "productId": "PASTE_PRODUCT_ID_HERE",
      "quantity": 1
    }
  ]
}
4. View the Customer's Orders
GET /api/customers/{id}/orders

Action: Use the customerId from Step 2. You should see the order you just created.

5. Update the Customer
PUT /api/customers/{id}

Action: Use the customerId from Step 2.

Request Body:

JSON

{
  "firstName": "Johnathan",
  "lastName": "Doe",
  "street": "456 Market St",
  "city": "Anytown",
  "postalCode": "54321"
}
You should get a 204 No Content or 200 OK response confirming the update.

6. Delete the Customer
DELETE /api/customers/{id}

Action: First, try to delete the customer with the ID from Step 2. This should fail with an error because the customer has an order. Then, delete the order first (if that endpoint is implemented) or create a new, order-less customer and delete them. A successful deletion will return a 204 No Content response.
