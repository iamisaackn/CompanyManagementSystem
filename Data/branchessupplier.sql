USE company;

INSERT INTO `branchessupplier` (`BranchId`, `SupplierName`, `SupplyType`, `CreatedAt`, `UpdatedAt`)
VALUES
-- Health Technology Suppliers
('branch1', 'TechHealth Solutions', 'Telemedicine Equipment', NOW(), NOW()),
('branch2', 'EHR Systems Inc', 'Health IT Software', NOW(), NOW()),
-- Pharmaceuticals Suppliers
('branch3', 'PharmaCare Ltd', 'Medicines and Drugs', NOW(), NOW()),
('branch4', 'VitaHealth Kenya', 'Vitamin Supplements', NOW(), NOW()),
-- Medical Devices Suppliers
('branch5', 'MediDevices Co', 'Surgical Instruments', NOW(), NOW()),
('branch6', 'Quick Diagnostics', 'Blood Test Kits', NOW(), NOW()),
-- Dentistry Suppliers
('branch7', 'Smile Supplies', 'Dental Equipment', NOW(), NOW()),
('branch8', 'DentalPro Supplies', 'Orthodontics Tools', NOW(), NOW()),
-- Emergency Medical Services Suppliers
('branch9', 'First Response Kits', 'First Aid Kits', NOW(), NOW()),
('branch10', 'EMS Medical Supplies', 'Emergency Equipment', NOW(), NOW()),
-- Biotechnology Suppliers
('branch11', 'GeneLab Solutions', 'DNA Testing Kits', NOW(), NOW()),
('branch12', 'BioTech Innovations', 'Lab Equipment', NOW(), NOW()),
-- Diagnostics Companies
('branch13', 'WestDiagnostics Ltd', 'Diagnostic Reagents', NOW(), NOW()),
('branch14', 'PathoLab Supplies', 'Testing Chemicals', NOW(), NOW()),
-- Dietetics and Nutrition
('branch15', 'NutriWorld', 'Meal Replacements', NOW(), NOW()),
('branch16', 'Healthy Nutrition Co', 'Dietary Supplements', NOW(), NOW()),
-- Healthcare Facilities Suppliers
('branch17', 'Hospital Equip Ltd', 'Beds and Furniture', NOW(), NOW()),
('branch18', 'MediCare Partners', 'General Hospital Supplies', NOW(), NOW()),
-- Hospitals Suppliers
('branch19', 'SurgicalTech Co', 'Operating Room Supplies', NOW(), NOW()),
('branch20', 'Prime Medical Supplies', 'Diagnostic Machines', NOW(), NOW());
