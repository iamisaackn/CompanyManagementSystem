USE company;

INSERT INTO `aspnetuserclaims` (`Id`, `UserId`, `ClaimType`, `ClaimValue`)
VALUES
-- Admin Claims
(1, 'user1', 'Permission', 'FullAccess'),
(2, 'user1', 'Permission', 'ManageUsers'),
-- User Claims
(3, 'user2', 'Permission', 'ViewDashboard'),
(4, 'user2', 'Permission', 'ViewReports'),
-- Manager Claims
(5, 'user3', 'Permission', 'ManageTeam'),
(6, 'user3', 'Permission', 'ApproveRequests'),
-- Doctor Claims
(7, 'user4', 'Permission', 'ViewPatientRecords'),
(8, 'user4', 'Permission', 'WritePrescriptions'),
-- Nurse Claims
(9, 'user5', 'Permission', 'AdministerMedications'),
(10, 'user5', 'Permission', 'AssistSurgeries'),
-- Dentist Claims
(11, 'user6', 'Permission', 'PerformDentalProcedures'),
(12, 'user6', 'Permission', 'ViewPatientHistories'),
-- Emergency Technician Claims
(13, 'user7', 'Permission', 'OperateMedicalEquipment'),
(14, 'user7', 'Permission', 'HandleEmergencies'),
-- Lab Technician Claims
(15, 'user8', 'Permission', 'ManageLabEquipment'),
(16, 'user8', 'Permission', 'ConductDiagnosticTests'),
-- Health IT Specialist Claims
(17, 'user9', 'Permission', 'MaintainEHRSystems'),
(18, 'user9', 'Permission', 'ResolveITIssues'),
-- Biotech Specialist Claims
(19, 'user10', 'Permission', 'HandleGeneticData'),
(20, 'user10', 'Permission', 'ManageResearchProjects');
