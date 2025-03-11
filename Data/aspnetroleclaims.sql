USE company;

INSERT INTO `aspnetroleclaims` (`Id`, `RoleId`, `ClaimType`, `ClaimValue`)
VALUES
-- Admin Claims
(1, 'role1', 'Permission', 'FullAccess'),
(2, 'role1', 'Permission', 'ManageUsers'),
-- User Claims
(3, 'role2', 'Permission', 'ViewDashboard'),
(4, 'role2', 'Permission', 'ViewReports'),
-- Manager Claims
(5, 'role3', 'Permission', 'ManageTeam'),
(6, 'role3', 'Permission', 'ApproveRequests'),
-- Health Administrator Claims
(7, 'role4', 'Permission', 'ManageBranches'),
(8, 'role4', 'Permission', 'ViewFinancialReports'),
-- Doctor Claims
(9, 'role6', 'Permission', 'WritePrescriptions'),
(10, 'role6', 'Permission', 'ViewPatientRecords'),
-- Nurse Claims
(11, 'role7', 'Permission', 'AdministerMedications'),
(12, 'role7', 'Permission', 'AssistSurgeries'),
-- Dentist Claims
(13, 'role8', 'Permission', 'PerformDentalProcedures'),
(14, 'role8', 'Permission', 'ViewPatientHistories'),
-- Pharmacist Claims
(15, 'role9', 'Permission', 'DispenseDrugs'),
(16, 'role9', 'Permission', 'ViewPrescriptions'),
-- Emergency Technician Claims
(17, 'role10', 'Permission', 'OperateMedicalEquipment'),
(18, 'role10', 'Permission', 'HandleEmergencies'),
-- Biotech Specialist Claims
(19, 'role11', 'Permission', 'ManageResearchProjects'),
(20, 'role11', 'Permission', 'HandleGeneticData');
