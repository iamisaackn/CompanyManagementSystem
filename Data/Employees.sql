USE company;

-- DELETE FROM Employees WHERE EmpId = 'emp1';
-- DELETE FROM Employees WHERE EmpId = 'emp2';

INSERT INTO `Employees` (`EmpId`, `UserId`, `FirstName`, `LastName`, `BirthDay`, `Sex`, `Salary`, `SupervisorId`, `BranchId`, `CreatedAt`, `UpdatedAt`)
VALUES
-- Health Tech
('emp1', 'user1', 'Alice', 'Kimani', '1990-06-15', 'F', 75000, NULL, NULL, NOW(), NOW()),
-- Pharmaceuticals
('emp2', 'user2', 'Brian', 'Otieno', '1987-08-10', 'M', 80000, 'emp1', NULL, NOW(), NOW()),
-- Medical Device
('emp3', 'user3', 'Cynthia', 'Mutua', '1993-03-25', 'F', 70000, NULL, NULL, NOW(), NOW()),
-- Dentistry
('emp4', 'user4', 'Daniel', 'Wanjohi', '1991-01-15', 'M', 65000, 'emp3', NULL, NOW(), NOW()),
-- Emergency Medical Services
('emp5', 'user5', 'Esther', 'Kariuki', '1995-07-19', 'F', 60000, 'emp1', NULL, NOW(), NOW()),
-- Biotechnology
('emp6', 'user6', 'Frank', 'Njoroge', '1985-10-22', 'M', 90000, 'emp2', NULL, NOW(), NOW()),
-- Diagnostics Companies
('emp7', 'user7', 'Grace', 'Wambui', '1989-04-12', 'F', 70000, 'emp3', NULL, NOW(), NOW()),
-- Dietetics
('emp8', 'user8', 'Henry', 'Maina', '1994-09-30', 'M', 50000, 'emp7', NULL, NOW(), NOW()),
-- General Medical Services
('emp9', 'user9', 'Irene', 'Omondi', '1992-02-17', 'F', 55000, NULL, NULL, NOW(), NOW()),
-- Specialist Medical Services
('emp10', 'user10', 'James', 'Njenga', '1988-11-05', 'M', 95000, 'emp6', NULL, NOW(), NOW()),
-- Healthcare Facilities
('emp11', 'user11', 'Katherine', 'Muriuki', '1993-06-01', 'F', 78000, NULL, NULL, NOW(), NOW()),
-- Health Administration
('emp12', 'user12', 'Leon', 'Mwangi', '1986-12-18', 'M', 85000, 'emp10', NULL, NOW(), NOW()),
-- Health Technology
('emp13', 'user13', 'Mary', 'Ngugi', '1989-03-04', 'F', 60000, 'emp2', NULL, NOW(), NOW()),
-- Hospitals
('emp14', 'user14', 'Nathan', 'Kamau', '1990-07-11', 'M', 87000, 'emp12', NULL, NOW(), NOW()),
-- Medical Research
('emp15', 'user15', 'Olivia', 'Wafula', '1987-11-24', 'F', 92000, NULL, NULL, NOW(), NOW()),
-- Pharmaceuticals
('emp16', 'user16', 'Peter', 'Omondi', '1991-04-16', 'M', 78000, 'emp9', NULL, NOW(), NOW()),
-- Emergency Medical Services
('emp17', 'user17', 'Quinn', 'Mbugua', '1995-01-09', 'M', 50000, 'emp15', NULL, NOW(), NOW()),
-- Diagnostics Companies
('emp18', 'user18', 'Ruth', 'Kariuki', '1989-09-13', 'F', 60000, NULL, NULL, NOW(), NOW()),
-- Biotechnology
('emp19', 'user19', 'Samuel', 'Kimani', '1988-08-02', 'M', 95000, NULL, NULL, NOW(), NOW()),
-- BAYADA Home Healthcare
('emp20', 'user20', 'Tina', 'Mwangi', '1990-05-27', 'F', 70000, 'emp14', NULL, NOW(), NOW());
