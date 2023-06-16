# Minimal API with Swagger Documentation

This code represents a set of API handlers for different endpoints. Each handler is responsible for processing requests and generating responses based on the specified models.

## RootHandler

This handler handles requests to the root endpoint (`"/"`) and returns a simple _"Hello world"_ message.

### Request Model

- `Name` (string): The name parameter.
- `Age` (int): The age parameter.

### Response Model

- `Message` (string): The response message.

#### Request

- HTTP Method: POST
- Consumes: application/json

#### Response

- Content-Type: application/json
- Status Code: 200 (OK)

---

## PatientsHandler

This handler handles requests to the `"/patients"` endpoint and returns a customized greeting message for patients.

### Request Model

- `Name` (string): The name parameter.

### Response Model

- `Message` (string): The response message.
- `CreatedAt` (DateTime): The timestamp of when the response was created.
- `Success` (bool, default: true): Indicates the success status of the response.

#### Request

- HTTP Method: POST

#### Response

- Content-Type: application/json
- Status Code: 200 (OK)

---

## DoctorsHandler

This handler handles requests to the `"/doctors"` endpoint and returns a customized greeting message for doctors.

### Request Model

- `Name` (string): The name parameter.

### Response Model

- `Message` (string): The response message.
- `CreatedAt` (DateTime): The timestamp of when the response was created.
- `Success` (bool, default: true): Indicates the success status of the response.

#### Request

- HTTP Method: POST
- Consumes: application/json

#### Response

- Content-Type: application/json
- Status Code: 201 (Created)
- Status Code: 400 (Bad Request)

---

## Usage

The code snippet provided demonstrates how to set up and configure the API handlers using a web application.

### Endpoint Mapping

The following endpoints are mapped to their respective handlers:

- `/`: Handled by `RootHandler.Process`
- `/doctors`: Handled by `DoctorsHandler.Process`
- `/patients`: Handled by `PatientsHandler.Process`

### OpenAPI Documentation

The OpenAPI documentation is generated for each endpoint using the `WithOpenApi` extension method.

### Running the Application

To run the application, execute the `Helpers.Start` method with the appropriate arguments.

Make sure you have the necessary dependencies and configurations set up before running the code.
