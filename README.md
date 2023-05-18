# Appointmentscheduler built using C#/.Net

# API Collection Description

This API collection provides endpoints to manage appointments and user authentication. It allows developers to perform operations such as retrieving appointments, creating new appointments, updating existing appointments, and managing user registration, login, and password reset.

## Appointments

The Appointments API endpoints enable you to interact with appointments in the system. You can perform operations such as retrieving all appointments, retrieving a specific appointment by ID, creating new appointments, and updating existing appointments.

## Authentication

The Authentication API endpoints allow users to register, login, and manage their passwords. Developers can integrate these endpoints to implement user registration, login, and password reset functionality.

---

## API Endpoints

- **GET /api/Appointment/GetAll**: Retrieve all appointments.
- **DELETE /api/Appointment/{id}**: Delete a specific appointment by ID.
- **GET /api/Appointment/{id}**: Retrieve details of a specific appointment by ID.
- **POST /api/Appointment**: Create a new appointment.
- **PUT /api/Appointment**: Update an existing appointment.
- **POST /Auth/Register**: Register a new user.
- **POST /Auth/Login**: Authenticate a user and generate an access token.
- **POST /Auth/ForgotPassword**: Initiate the password reset process for a user.
- **POST /Auth/ResetPassword**: Reset the password for a user.
    

---

Please refer to the individual API endpoints for more detailed information on their usage, request parameters, and response formats.

## POST http://localhost:5049/Auth/Register

Description: Registers a new user.

Parameters: Request body containing user registration details.

Returns: Confirmation message and the registered user details.

## POST http://localhost:5049/Auth/Login

Description: Authenticates a user and generates an access token.

Parameters: Request body containing user login credentials.

Returns: Access token and user details upon successful login.

## GET http://localhost:5049/api/Appointment/GetAll

Description: Retrieves all appointments.

Parameters: None.

Returns: A list of all appointments.

## POST http://localhost:5049/api/Appointment

Description: Creates a new appointment.

Parameters: Request body containing the appointment details.

Returns: Confirmation message and the created appointment details.

## GET http://localhost:5049/api/Appointment/{id}

Description: Retrieves details of a specific appointment.

Parameters:
id (path parameter) - The ID of the appointment to retrieve.

Returns: Details of the requested appointment.

## PUT http://localhost:5049/api/Appointment

Description: Updates an existing appointment.

Parameters: Request body containing the updated appointment details.

Returns: Confirmation message and the updated appointment details.

## DELETE http://localhost:5049/api/Appointment/{id}

Description: Deletes a specific appointment.

Parameters:
id (path parameter) - The ID of the appointment to be deleted.

Returns: Confirmation message indicating whether the deletion was successful.

## POST http://localhost:5049/Auth/ForgotPassword

Description: Initiates the password reset process for a user.

Parameters: Request body containing the user's email address.

Returns: Confirmation message and instructions for resetting the password.

## POST http://localhost:5049/Auth/ResetPassword

Description: Resets the password for a user.

Parameters: Request body containing the password reset token and the new password.

Returns: Confirmation message indicating whether the password reset was successful.
    
