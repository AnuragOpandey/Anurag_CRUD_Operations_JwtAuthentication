******************************************************************************
*	Created By : Anurag Pandey                                              *
*	Contact    : anurag.pandey@atos.net                                     *
******************************************************************************
# HCA Lab Test
	This is a Web API application for lab test data handing and reporting developed using .Net Core 6.0.
	Visual Studio 2022

Note: This program does not have a stratup file as >NetCore 6.0 does not have a concept of startup instead they use program.cs for startupp related configuration.
	Also, Please ignore Helper Folder and jwtController.

# Problem statement
	Need application that is capable of
	1. Generate authentication token for security access(created Role based Authentication(Roles = "Admin"))
	2. Creating/Managing Patient securely
	3. Creating/Managing Test securely
	4. Creating/Managing/Reporting Test Reports securely
	5. Managing the PatientReport details and applying specific filters on the reports securely.

# Tables (As model classes for In-Memory DB implementation(registration and login) as well as mock data implementation(Patient and LabTest details))
	LoggedInUser
		string Username //Logged in user name
		string Password //User password
		
	Patient
        int Id //PrimarKey(Guid generation )
		string PatientName //Patient Name
		DateTime DateOfBirth //Date of birth of patient
        	string PatientGender //Gender of patient (Male,Female)
		int Age //Patient Age
		string Type//Patient Test type to classify patient
		string patientID //To fetch the report of the patient(Foreign key to Report details)
	
	LabTest
	int Id //PrimarKey(Guid generation )
		string patientID //To fetch the report of the patient(Foreign key to Patient details)
		string Type//Patient Test type to classify patient
		string result//Negative or positive
		DateTime timeOfTest //Time of the test
		DateTime EnteredTime //Entered Time before the test
		
	PatientLapReport
		string PatientName //Patient Name
		DateTime DateOfBirth //Date of birth of patient
        	string PatientGender //Gender of patient (Male,Female)
		int Age //Patient Age
		string Type//Patient Test type to classify patient
		string patientID //To fetch the report of the patient(Foreign key to Report details)
		string result//Negative or positive
		DateTime timeOfTest //Time of the test
		DateTime EnteredTime //Entered Time before the test

		
# Approach
	Followed Controllers, Model and The Data Layer approach.
	Implemention using MockData for Patient and Lab Details
	Implemention using InMemory Db for Admin Login and Registration to manage the patient and other details of 	the patient and Lap Report
	User details and User credentials in User and UserDto classrespectively
	Patient details in Patient class
	Test details in LabTest class
	Report details with the patient Details in PatientLabTest class
	
#Operations Supported with endpoints
	Operations supported with endpoint details, sample URL and payload information 
	
	1. Endpoint Login
		* Register: (Post : https://localhost:44367/Auth/Register)
			{
  				"username": "Admin",
  				"passwordHash": "zqKr/9kyTk8KSgIWmp1k99TIRS7VaTX2EvLboHuMXfphRNFg2Vz9c2XMxSQG+						+bE1VSpwU5rtrvGGPrW/NWPxQ==",							 			"passwordSalt":"Kgr5pMmlE58O88eqvRFtYChtxcP3JNjfPFApIL3mFzEmWuA738miJv7EL3LxjtYdU4fiO6vdTKN		+Y926UsnCbckzOhi9+THQQycn01cWFFDclhjmxELAvMtxhc0iAF08LcmuIknXJUHoBM/evVolJjs+LW84RIpOagcHqz8VxtA="
}
		* Login: (Post : https://localhost:44367/Auth/Login)
			{
 				 "username": "Admin",
 				 "password": "Admin"
			}			
	2. Endpoint Patient
		* GetAllPatients: Get: https://localhost:44367/Patients)
			  {
    				"id": "ba551e1b-562c-424e-9b94-c847540c6b19",
    				"patientID": "P1",
   				 "type": "Typhoid",
  				  "result": "Positive",
   				 "timeOfTest": "2021-09-20T00:00:00",
    				"enteredTime": "2021-09-20T00:00:00"
  },
		* AddPatient: (Post : https://localhost:44367/AddPatients)
			{
				  {
    					"id": "de1fcda5-c027-456a-a1ff-d84d41cb49ce",
    					"patientID": "P5",
   					 "name": "Yogita",
  					  "gender": "Female",
    					"age": 31,
    					"type": "Dengue",
    					"dOB": "1990-02-20T00:00:00"
  					},
			}
		* GetPatientbyId: : Get: https://localhost:44367/Patients/GetPatientsbyid/{id})
		* DeletePatientByid: Delete: https://localhost:44367/DeletPatientByid/{id})
		* GetAll : (Patch : https://localhost:44367/Patients/EditPatientsbyid)
		
	3. Endpoint LabTest
		* GetAllPatients: Get: https://localhost:44367/Patients)
			  {
    				"id": "ba551e1b-562c-424e-9b94-c847540c6b19",
    				"patientID": "P1",
   				 "type": "Typhoid",
  				  "result": "Positive",
   				 "timeOfTest": "2021-09-20T00:00:00",
    				"enteredTime": "2021-09-20T00:00:00"
  },
		* AddPatient: (Post : https://localhost:44367/AddPatients)
			{
				  {
    					"id": "de1fcda5-c027-456a-a1ff-d84d41cb49ce",
    					"patientID": "P5",
   					 "name": "Yogita",
  					  "gender": "Female",
    					"age": 31,
    					"type": "Dengue",
    					"dOB": "1990-02-20T00:00:00"
  					},
			}
		* GetPatientbyId: : Get: https://localhost:44367/Patients/GetPatientsbyid/{id})
		* DeletePatientByid: Delete: https://localhost:44367/DeletPatientByid/{id})
		* GetAll : (Patch : https://localhost:44367/Patients/EditPatientsbyid)
		
	3. Endpoint LabTest
		* GetAllPatients: Get: https://localhost:44367/Patients)
			  {
    				"id": "ba551e1b-562c-424e-9b94-c847540c6b19",
    				"patientID": "P1",
   				 "type": "Typhoid",
  				  "result": "Positive",
   				 "timeOfTest": "2021-09-20T00:00:00",
    				"enteredTime": "2021-09-20T00:00:00"
  },
		* AddPatient: (Post : https://localhost:44367/AddPatients)
			{
				  {
    					"id": "de1fcda5-c027-456a-a1ff-d84d41cb49ce",
    					"patientID": "P5",
   					 "name": "Yogita",
  					  "gender": "Female",
    					"age": 31,
    					"type": "Dengue",
    					"dOB": "1990-02-20T00:00:00"
  					},
			}
		* GetPatientbyId: : Get: https://localhost:44367/Patients/GetPatientsbyid/{id})
		* DeletePatientByid: Delete: https://localhost:44367/DeletPatientByid/{id})
		* EditPatientByid: (Patch : https://localhost:44367/Patients/EditPatientsbyid)
		
	3. Endpoint LabTest
		* GetAllLabTests: Get: https://localhost:44367/api/LapTest)
			  {
    				"id": "ba551e1b-562c-424e-9b94-c847540c6b19",
   				 "patientID": "P1",
  				  "type": "Typhoid",
  				  "result": "Positive",
  				  "timeOfTest": "2021-09-20T00:00:00",
   				 "enteredTime": "2021-09-20T00:00:00"
  },
  },
		* AddLabTestDetails(Post : https://localhost:44367/AddLabTestDetails)
						  {
    				"id": "ba551e1b-562c-424e-9b94-c847540c6b19",
   				 "patientID": "P1",
  				  "type": "Typhoid",
  				  "result": "Positive",
  				  "timeOfTest": "2021-09-20T00:00:00",
   				 "enteredTime": "2021-09-20T00:00:00"
  },
  },
		* GetLabTestsbyId: : Get: https://localhost:44367api/LabTests/GetLabTestsbyid/{id})
		* DeleteLabTestsByid: Delete: https://localhost:44367api/LabTests/DeletLabTestsByid/{id})
		* EditLabtestsPatientByid: : (Patch : https://localhost:44367api/LabTests/EditLabTestsbyid)
		* GetPatientLabReportDetails by id: : Get: 		https://localhost:44367/api/LabTests/GetPatientLabReportDetails by id/{id})
  			{
 			   "name": "Piyush",
  			  "gender": "Male",
 			   "age": 21,
			    "dob": "2001-03-29T00:00:00",
			    "type": "Typhoid",
			    "result": "Positive",
			    "timeOfTest": "2021-09-20T00:00:00",
			    "enteredTime": "2021-09-20T00:00:00"
  },
		* GetPatientLabReportByTime : Get: 				https://localhost:44367/api/LabTests/GetPatientLabReportByTime/{FromDate}/{ToDate}/{Type})
		
		(accepts 3 paramters fromdate todate and the type)
		
	
#Installation
	1. Copy code in a folder
	2. Open LabTest soultion using Microsoft Visual Studio 2022 (CRUD_PatientLabTestAPI.sln)
	3. Build and Run project CRUD_PatientLabTestAPI
	4. Application should run in browser using Swagger UI
	5. Postman can also be configured (as per above url and payload details) for generating and passing token
	
#Steps to run with Swagger
	1. Execute endpoint Login,Register User(Admin) and Login using Admin creds,the token will be generated 	after login(Role based Authentication is given Role must be Admin for the Authorization)
	2. Once token is generated, copy the generated token
	3. Click Authorize button in page header to open "Available Authorizations" dialogue
	4. Enter 'bearer' [space] and then token in the text input under value
	5. click Authorize and then Close button
	6. Now you are ready to run, follow sequence as below to handle data dependencies 
	7. Create Patient (if executed Get(), will create hardcoded Patients from the mockdata)(Anonymous access),
		Post(),Delete() and Patch() will need Authorization(Admin).
	8. Create Patient (if executed Get(), will create hardcoded Patients from the mockdata)(Anonymous access),
		Post(),Delete() and Patch() will need Authorization(Admin).
	9. Create Patient (if executed Get(), will create hardcoded Patients from the mockdata)(Anonymous access),
		Post(),Delete() and Patch() will need Authorization(Admin).

