USE company;

-- DELETE FROM Branches WHERE BranchId = 'branch1';
-- DELETE FROM Branches WHERE BranchId = 'branch2';

INSERT INTO `Branches` (`BranchId`, `BranchName`, `ManagerId`, `ManagerStartDate`, `CreatedAt`, `UpdatedAt`)
VALUES
-- Health Technology Branches
('branch1', 'Telehealth Headquarters', 'emp1', NOW(), NOW(), NOW()),
('branch2', 'Health IT Solutions Office', 'emp2', NOW(), NOW(), NOW()),
-- Pharmaceutical Branches
('branch3', 'Pharma Kenya Nairobi Central', 'emp3', NOW(), NOW(), NOW()),
('branch4', 'Pharma Kenya Mombasa Hub', 'emp4', NOW(), NOW(), NOW()),
-- Medical Device Branches
('branch5', 'Medical Equipment Warehouse', 'emp5', NOW(), NOW(), NOW()),
('branch6', 'Surgical Supplies Outlet', 'emp6', NOW(), NOW(), NOW()),
-- Dentistry Clinics
('branch7', 'Downtown Dental Clinic', 'emp7', NOW(), NOW(), NOW()),
('branch8', 'Uptown Dental Solutions', 'emp8', NOW(), NOW(), NOW()),
-- Emergency Medical Services
('branch9', 'EMS Rapid Response Nairobi', 'emp9', NOW(), NOW(), NOW()),
('branch10', 'EMS Coastal Response Center', 'emp10', NOW(), NOW(), NOW()),
-- Biotechnology Branches
('branch11', 'Biotech Research Lab Nairobi', 'emp11', NOW(), NOW(), NOW()),
('branch12', 'Advanced Biotech Mombasa', 'emp12', NOW(), NOW(), NOW()),
-- Diagnostics Companies
('branch13', 'Diagnostics Kenya Westlands', 'emp13', NOW(), NOW(), NOW()),
('branch14', 'Pathology Labs Eastlands', 'emp14', NOW(), NOW(), NOW()),
-- Dietetics and Nutrition Centers
('branch15', 'Wellness and Nutrition Hub', 'emp15', NOW(), NOW(), NOW()),
('branch16', 'Dietetics Kenya Support Center', 'emp16', NOW(), NOW(), NOW()),
-- Healthcare Facilities
('branch17', 'MediCare Regional HQ', 'emp17', NOW(), NOW(), NOW()),
('branch18', 'National Healthcare Services', 'emp18', NOW(), NOW(), NOW()),
-- Hospitals
('branch19', 'Careplus County Hospital', 'emp19', NOW(), NOW(), NOW()),
('branch20', 'Lifesaver Community Clinic', 'emp20', NOW(), NOW(), NOW());
