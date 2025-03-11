USE company;

INSERT INTO `aspnetuserlogins` (`LoginProvider`, `ProviderKey`, `ProviderDisplayName`, `UserId`)
VALUES
-- Admin and Management Logins
('HealthTechProvider', 'admin_key1', 'Admin Portal', 'user1'),
('HealthTechProvider', 'manager_key2', 'Manager Portal', 'user2'),
-- Pharmaceutical Logins
('PharmaConnect', 'pharma_key3', 'Pharma Dashboard', 'user3'),
('PharmaConnect', 'pharma_key4', 'Supplier Portal', 'user4'),
-- Medical Device Logins
('MediDevicesLogin', 'device_key5', 'Equipment Dashboard', 'user5'),
('MediDevicesLogin', 'device_key6', 'Device Monitoring', 'user6'),
-- Dentistry Logins
('DentalCare', 'dental_key7', 'Dentist Hub', 'user7'),
('DentalCare', 'dental_key8', 'Orthodontics Portal', 'user8'),
-- Emergency Services Logins
('EMSLogin', 'ems_key9', 'Response Portal', 'user9'),
('EMSLogin', 'ems_key10', 'Emergency Dashboard', 'user10'),
-- Biotechnology Logins
('BioTechSystems', 'biotech_key11', 'Research Portal', 'user11'),
('BioTechSystems', 'biotech_key12', 'Lab Management', 'user12'),
-- Diagnostics Company Logins
('DiagnosticsHub', 'diagnostic_key13', 'Diagnostics Dashboard', 'user13'),
('DiagnosticsHub', 'diagnostic_key14', 'Lab Results Portal', 'user14'),
-- Nutrition and Dietetics Logins
('DietitianConnect', 'diet_key15', 'Nutrition Center', 'user15'),
('DietitianConnect', 'diet_key16', 'Dietetics Portal', 'user16'),
-- Healthcare Facilities Logins
('MediFacilities', 'facility_key17', 'Hospital Management', 'user17'),
('MediFacilities', 'facility_key18', 'Healthcare Coordination', 'user18'),
-- Hospital Logins
('HospitalNetwork', 'hospital_key19', 'Patient Management', 'user19'),
('HospitalNetwork', 'hospital_key20', 'Inpatient Services', 'user20');
