
******************************************************************************
*	Created By : Raghavan Nadar                                              *
*	Contact    : raghavan.nadar@atos.net                                     *
******************************************************************************
# Lab Reports API Test
	This is a Web API application for lab test data handing and reporting developed using .Net Core 6.0

# Problem statement
	Need application that is capable of
	1. Generate authentication token for security access
	2. Creating/Managing Patient securely
	3. Creating/Managing Test securely
	4. Creating/Managing/Reporting Test Reports securely

# Tables (As model classes for In-Memory DB implementation)
	UserCredential
		string Username //Logged in user name
		string Password //User password
		
	Patient
        	Guid Id //PrimarKey
		string PatientID //Patient Name		
        	string Gender //Gender of patient 
		int Age
		DateTime DateOfBirth //Date of birth of patient
		string Address //Patient address
	
	LabTest
		Guid Id //PrimarKey
		string PatientID
		string Patient Name	
		string Type
		string Result
		DateTime Time Of Test
		DateTime Entered Time
		
	PatientLabTest
		string Name 
        	string Gender 
        	int Age 
        	DateTime DOB 
        	string Type 
        	string Result 
        	DateTime TimeOfTest 
        	DateTime EnteredTime 
		
# Approach
	Implemention using In-Memory DB
	User credentials in UserCredential class
	Patient details in Patient class
	Test details in LabTest class
	Report details in PatientLabTest class
	
#Operations Supported with endpoints
	Operations supported with endpoint details, sample URL and payload information 
	
	1. Endpoint Login
		* Login : (Post : https://localhost:44373/Authenticate)
			{
				"username": "Demouser",
				"password": "DemoPassword"
			}			
	2. Endpoint Patient
		* Create : (Post : https://localhost:44373/Patient/Create)
			{
				"id": "99ae7c0c-5478-494f-9297-8e470b6f6bf9",
    				"patientID": "1",
    				"name": "Max Aarons",
    				"gender": "Male",
   				"age": 22,
    				"dob": "1999-01-24T00:00:00"
			}
		* Update : (Patch : https://localhost:44373/Patient/Update/1)
			{
				"id": "99ae7c0c-5478-494f-9297-8e470b6f6bf9",
    				"patientID": "1",
    				"name": "Max Aarons",
    				"gender": "Male",
   				"age": 22,
    				"dob": "1999-01-24T00:00:00"
			}
		* Delete : (Delete : https://localhost:44373/Patient/Delete/1)
		* GetAll : (Get : https://localhost:44373/Patient/Get)
		* GetById : (Get : https://localhost:44373/Patient/Get/1)
		
	3. Endpoint LabTest
		* Create : (Post : https://localhost:44373/LabTest/Create)
			{
				 "id": "ee22f338-d146-469e-a4f1-eb5818d9d33a",
    				 "patientID": "1",
   				 "patientName": "Max Aarons",
   				 "type": "Covid-19",
   				 "result": "Positive",
   				 "timeOfTest": "2021-08-29T00:00:00",
   				 "enteredTime": "2021-08-30T00:00:00"
			}		
		* Update : (Put : https://localhost:44373/LabTest/Update/1)
			{
				 "id": "ee22f338-d146-469e-a4f1-eb5818d9d33a",
    				 "patientID": "1",
   				 "patientName": "Max Aarons",
   				 "type": "Covid-21",
   				 "result": "Positive",
   				 "timeOfTest": "2021-08-29T00:00:00",
   				 "enteredTime": "2021-08-30T00:00:00"
			}	
		* Delete : (Delete : https://localhost:44373/LabTest/Delete/1)
		* GetAll : (Get : https://localhost:44373/LabTest/Get)
		* GetById : (Get : https://localhost:44373/LabTest/Get/1)
		
	4. Endpoint LabReport
		* Create : (Post : https://localhost:44367/LabReport/Create)
			{
				"id": 0,
				"patientId": 1,
				"labTestId": 1,
				"sampleReceivedOn": "2021-01-10T00:00:00",
				"sampleTestedOn": "2021-01-11T00:00:00",
				"reportCreatedOn": "2021-01-12T00:00:00",
				"testResult": 125,
				"refferredBy": "Dr. Physician 1"
			}
		* Update : (Put : https://localhost:44367/LabReport/Update/1)
			{
				"id": 1,
				"patientId": 1,
				"labTestId": 1,
				"sampleReceivedOn": "2021-01-10T00:00:00",
				"sampleTestedOn": "2021-01-11T00:00:00",
				"reportCreatedOn": "2021-01-12T00:00:00",
				"testResult": 125,
				"refferredBy": "Dr. Physician 1 Modified"
			}
		* Delete : (Delete : https://localhost:44367/LabReport/Delete/1)
		* GetAll : (Get : https://localhost:44367/LabReport/Get)
		* GetById : (Get : https://localhost:44367/LabReport/Get/1)
		* GetByLabTest : (Get : https://localhost:44367/LabReport/GetByLabTest/1/2021-01-01/2021-12-31)
		
#Installation
	1. Copy code in a folder
	2. Open LabTest soultion using Microsoft Visual Studio (LabTests.sln)
	3. Build and Run project LabReportsAPI
	4. Application should run in browser using Swagger UI
	5. Postman can also be configured (as per above url and payload details) for generating and passing token
	
#Steps to run with Swagger
	1. Execute endpoint Login (Credentials as in Login endpoint details above) to generate token
	2. Now you are ready to run, follow sequence as below to handle data dependencies 
	3. Create Patient (if executed Get(), will create hardcoded Patients from backed if Patient table is empty)
	4. Create LabTest (if executed Get(), will create hardcoded Tests from backed if LabTest table is empty)
	5. Create LabReport (if executed Get(), will create hardcoded LabReports from if when LabReport table is empty)

© 2021 GitHub, Inc.
Terms
Privacy
Securit
