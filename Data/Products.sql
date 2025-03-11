USE company;

-- DELETE FROM Products WHERE ProductId = 'prod1';
-- DELETE FROM Products WHERE ProductId = 'prod2';


INSERT INTO `Products` (`ProductId`, `Name`, `Description`, `ProductImage`, `CreatedAt`, `UpdatedAt`)
VALUES
-- Health Technology
('prod1', 'Telemedicine Platform', 'A platform for virtual doctor consultations', NULL, NOW(), NOW()),
-- Pharmaceuticals
('prod2', 'Pain Reliever', 'Over-the-counter pain relief medication', NULL, NOW(), NOW()),
-- Medical Device
('prod3', 'Digital Thermometer', 'Accurate and quick-read thermometer', NULL, NOW(), NOW()),
-- Diagnostics
('prod4', 'Blood Pressure Monitor', 'Portable monitor for tracking blood pressure', NULL, NOW(), NOW()),
-- Dentistry
('prod5', 'Electric Toothbrush', 'Advanced toothbrush with multiple cleaning modes', NULL, NOW(), NOW()),
-- Emergency Medical Services
('prod6', 'First Aid Kit', 'Comprehensive kit for emergency care', NULL, NOW(), NOW()),
-- Biotechnology
('prod7', 'DNA Testing Kit', 'At-home kit for genetic testing and analysis', NULL, NOW(), NOW()),
-- Healthcare Facilities
('prod8', 'Hospital Bed', 'Adjustable bed for patient care', NULL, NOW(), NOW()),
-- Health Administration
('prod9', 'Medical Billing Software', 'Software for handling hospital billing and coding', NULL, NOW(), NOW()),
-- Health Technology
('prod10', 'Wearable Fitness Tracker', 'Monitors heart rate and activity levels', NULL, NOW(), NOW()),
-- Hospitals
('prod11', 'MRI Machine', 'Advanced magnetic resonance imaging system', NULL, NOW(), NOW()),
-- Medical Research
('prod12', 'Research Microscope', 'High-powered microscope for laboratory use', NULL, NOW(), NOW()),
-- Pharmaceuticals
('prod13', 'Vitamin Supplements', 'Essential vitamins to support health', NULL, NOW(), NOW()),
-- Dietetics
('prod14', 'Nutritional Shakes', 'Meal replacement shakes for balanced nutrition', NULL, NOW(), NOW()),
-- Diagnostics Companies
('prod15', 'COVID-19 Test Kit', 'Rapid antigen test for COVID-19 detection', NULL, NOW(), NOW()),
-- BAYADA Home Healthcare
('prod16', 'Home Care Software', 'Software to manage home healthcare services', NULL, NOW(), NOW()),
-- Medical Devices
('prod17', 'Pulse Oximeter', 'Device to measure oxygen levels in blood', NULL, NOW(), NOW()),
-- Dentistry
('prod18', 'Dental Chair', 'Specialist chair for dental procedures', NULL, NOW(), NOW()),
-- Emergency Medical Services
('prod19', 'Defibrillator', 'Portable AED for cardiac emergencies', NULL, NOW(), NOW()),
-- Healthcare Tech
('prod20', 'Electronic Health Records (EHR) System', 'Software for managing patient medical records', NULL, NOW(), NOW());
