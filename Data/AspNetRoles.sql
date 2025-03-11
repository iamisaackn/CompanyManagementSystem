USE company;

-- DELETE FROM AspNetRoles WHERE Id = 'role1';
-- DELETE FROM AspNetRoles WHERE Id = 'role2';

INSERT INTO `AspNetRoles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`)
VALUES
-- Administrative Roles
('role1', 'Admin', 'ADMIN', NULL),
('role2', 'User', 'USER', NULL),
('role3', 'Manager', 'MANAGER', NULL),
('role4', 'Health Administrator', 'HEALTH ADMINISTRATOR', NULL),
('role5', 'Branch Manager', 'BRANCH MANAGER', NULL),
-- Healthcare Professionals
('role6', 'Doctor', 'DOCTOR', NULL),
('role7', 'Nurse', 'NURSE', NULL),
('role8', 'Dentist', 'DENTIST', NULL),
('role9', 'Pharmacist', 'PHARMACIST', NULL),
('role10', 'Emergency Technician', 'EMERGENCY TECHNICIAN', NULL),
-- Technical and Research Roles
('role11', 'Biotech Specialist', 'BIOTECH SPECIALIST', NULL),
('role12', 'Lab Technician', 'LAB TECHNICIAN', NULL),
('role13', 'Diagnostics Specialist', 'DIAGNOSTICS SPECIALIST', NULL),
('role14', 'Medical Researcher', 'MEDICAL RESEARCHER', NULL),
('role15', 'Dietitian', 'DIETITIAN', NULL),
-- Support and Administrative Services
('role16', 'Patient Coordinator', 'PATIENT COORDINATOR', NULL),
('role17', 'Health IT Specialist', 'HEALTH IT SPECIALIST', NULL),
('role18', 'Insurance Agent', 'INSURANCE AGENT', NULL),
('role19', 'Home Healthcare Provider', 'HOME HEALTHCARE PROVIDER', NULL),
('role20', 'Hospital Receptionist', 'HOSPITAL RECEPTIONIST', NULL);
