USE company;

-- DELETE FROM Sales WHERE SaleId = 'sale1';
-- DELETE FROM Sales WHERE SaleId = 'sale2';

INSERT INTO `Sales` (`SaleId`, `EmpId`, `ClientId`, `ProductType`, `Cost`, `CreatedAt`, `UpdatedAt`)
VALUES
-- Health Technology Sales
('sale1', 'emp1', 'client1', 'Telemedicine Platform', 5000.00, NOW(), NOW()),
('sale2', 'emp2', 'client2', 'Electronic Health Record (EHR) System', 8500.00, NOW(), NOW()),
-- Pharmaceuticals Sales
('sale3', 'emp3', 'client3', 'Pain Reliever', 250.00, NOW(), NOW()),
('sale4', 'emp4', 'client4', 'Vitamin Supplements', 300.00, NOW(), NOW()),
-- Medical Devices Sales
('sale5', 'emp5', 'client5', 'Blood Pressure Monitor', 1500.00, NOW(), NOW()),
('sale6', 'emp6', 'client6', 'Surgical Tools Kit', 2000.00, NOW(), NOW()),
-- Dentistry Services
('sale7', 'emp7', 'client7', 'Electric Toothbrush', 120.00, NOW(), NOW()),
('sale8', 'emp8', 'client8', 'Dental X-ray Machine', 4500.00, NOW(), NOW()),
-- Emergency Medical Services
('sale9', 'emp9', 'client9', 'First Aid Training', 1500.00, NOW(), NOW()),
('sale10', 'emp10', 'client10', 'Defibrillator', 1800.00, NOW(), NOW()),
-- Biotechnology Services
('sale11', 'emp11', 'client11', 'DNA Testing Kit', 250.00, NOW(), NOW()),
('sale12', 'emp12', 'client12', 'Gene Therapy Research', 12000.00, NOW(), NOW()),
-- Diagnostics Companies Sales
('sale13', 'emp13', 'client13', 'Blood Test Package', 500.00, NOW(), NOW()),
('sale14', 'emp14', 'client14', 'MRI Scan Service', 4000.00, NOW(), NOW()),
-- Dietetics and Nutrition
('sale15', 'emp15', 'client15', 'Nutritional Counseling Package', 700.00, NOW(), NOW()),
('sale16', 'emp16', 'client16', 'Meal Replacement Shakes', 120.00, NOW(), NOW()),
-- Healthcare Facilities
('sale17', 'emp17', 'client17', 'Hospital Bed Rental', 2000.00, NOW(), NOW()),
('sale18', 'emp18', 'client18', 'Diagnostic Imaging Package', 3000.00, NOW(), NOW()),
-- Hospitals
('sale19', 'emp19', 'client19', 'Outpatient Consultation', 100.00, NOW(), NOW()),
('sale20', 'emp20', 'client20', 'Inpatient Care Package', 15000.00, NOW(), NOW());
