CREATE DATABASE HospitalSystem;

USE HospitalSystem;

CREATE TABLE Doctor (
DoctorId INT PRIMARY KEY,
[Name] VARCHAR(20), 
Specialty VARCHAR(20),
YearsOfExperience INT,
);
CREATE TABLE Patient (
	PatientID INT PRIMARY KEY,
	[Name] VARCHAR(20),
	PhoneNumber VARCHAR(11),
	[Address] VARCHAR(30),
	DateOfBirth DATE,
	EmergencyContactName VARCHAR(30),
	EmergencyContactPhone VARCHAR(11),
	InsuranceInformation VARCHAR(30)
);
CREATE TABLE Nurse (
NurseID INT PRIMARY KEY,
[Name] VARCHAR(20),
YearsOfExperience INT
);

CREATE TABLE Department (
DepartmentID INT PRIMARY KEY,
DoctorID INT FOREIGN KEY REFERENCES Doctor(DoctorId),
NurseID INT FOREIGN KEY REFERENCES Nurse(NurseID),
[Name] VARCHAR(20),
);


CREATE TABLE Room (
    RoomId INT PRIMARY KEY,
    RoomType VARCHAR(20),
    [Location] VARCHAR(20)
);

CREATE TABLE Treatment (
    TreatmentID INT PRIMARY KEY,
    [Description] VARCHAR(100),
    Cost FLOAT
);

CREATE TABLE Medication (
    MedicationID INT PRIMARY KEY,
    [Name] VARCHAR(30),
    dosage VARCHAR(30),
    [description] VARCHAR(150)
);



CREATE TABLE Patient_Diagnosis (
DoctorID INT,
PatientID INT,

PRIMARY KEY (DoctorID, PatientID), 
FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);


CREATE TABLE PatientMedication (
    PatientID INT,
    MedicationID INT,
    Frequency INT,
    Amount VARCHAR(20),
    StartDate DATE,
    EndDate DATE,
    PRIMARY KEY (PatientID, medicationid),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
    FOREIGN KEY (MedicationID) REFERENCES Medication(MedicationID)
);

CREATE TABLE PatientTreatment (
	PatientID INT,
	TreatmentID INT,
	PRIMARY KEY (PatientID, TreatmentID),
	FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
	FOREIGN KEY (TreatmentID) REFERENCES Treatment(TreatmentID)
);

CREATE TABLE Diagnosis (
	DiagnosisID INT PRIMARY KEY,
	DoctorID INT FOREIGN KEY REFERENCES Doctor (DoctorID),
	PatientID INT FOREIGN KEY REFERENCES Patient (PatientID),
	DiagnosisCode INT,
	[Description] VARCHAR(100),
	DiagnosisDate DATE
);


CREATE TABLE Appointment (
	AppointmentID INT PRIMARY KEY,
	PatientID INT FOREIGN KEY REFERENCES Patient(PatientID),
	DoctorID INT FOREIGN KEY REFERENCES Doctor (DoctorID),
	ReasonForVisit VARCHAR(100),
	AppointmentDate DATE,
	AppointmentTime TIME
);


CREATE TABLE MedicalHistory (
	MedicalRecordID INT PRIMARY KEY,
	DiagnosisID INT FOREIGN KEY REFERENCES Diagnosis (DiagnosisID),
	TreatmentID INT FOREIGN KEY REFERENCES Treatment (TreatmentID),
	DateOfVisit DATE
);



