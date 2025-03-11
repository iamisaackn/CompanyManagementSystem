USE company;

-- DELETE FROM Clients WHERE ClientId = 'client1';
-- DELETE FROM Clients WHERE ClientId = 'client2';

INSERT INTO `Clients` (`ClientId`, `ClientName`, `BranchId`, `CreatedAt`, `UpdatedAt`)
VALUES
-- Health Technology Companies
('client1', 'Telehealth Solutions', 'branch1', NOW(), NOW()),
('client2', 'Digital Health Kenya', 'branch2', NOW(), NOW()),
-- Pharmaceutical Companies
('client3', 'Pharma Life Nairobi', 'branch3', NOW(), NOW()),
('client4', 'Kenya Pharma Hub', 'branch4', NOW(), NOW()),
-- Medical Device Providers
('client5', 'MediEquip Supplies', 'branch5', NOW(), NOW()),
('client6', 'Surgical Tools Ltd', 'branch6', NOW(), NOW()),
-- Dentistry Clients
('client7', 'Smile Bright Dentistry', 'branch7', NOW(), NOW()),
('client8', 'Pearl Dental Services', 'branch8', NOW(), NOW()),
-- Emergency Medical Services
('client9', 'Rapid EMS Solutions', 'branch9', NOW(), NOW()),
('client10', 'EMS Coastal Aid', 'branch10', NOW(), NOW()),
-- Biotechnology Companies
('client11', 'Advanced Biotech Kenya', 'branch11', NOW(), NOW()),
('client12', 'Innovative Biotech Labs', 'branch12', NOW(), NOW()),
-- Diagnostic Companies
('client13', 'Westlands Diagnostics', 'branch13', NOW(), NOW()),
('client14', 'PathCare Kenya', 'branch14', NOW(), NOW()),
-- Dietetics and Nutrition Services
('client15', 'NutriWell Kenya', 'branch15', NOW(), NOW()),
('client16', 'Kenya Dietetics Center', 'branch16', NOW(), NOW()),
-- Healthcare Facilities
('client17', 'Medicare Services HQ', 'branch17', NOW(), NOW()),
('client18', 'Universal Health Providers', 'branch18', NOW(), NOW()),
-- Hospitals
('client19', 'Prime County Hospital', 'branch19', NOW(), NOW()),
('client20', 'Lifesaver Clinics', 'branch20', NOW(), NOW());
