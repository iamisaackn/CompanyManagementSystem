USE company;

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`)
VALUES
-- Administrative Roles
('user1', 'role1'), -- Admin
('user2', 'role3'), -- Manager
-- Healthcare Professionals
('user3', 'role6'), -- Doctor
('user4', 'role7'), -- Nurse
-- Dentistry
('user5', 'role8'), -- Dentist
('user6', 'role8'), -- Dentist
-- Pharmaceuticals
('user7', 'role9'), -- Pharmacist
('user8', 'role9'), -- Pharmacist
-- Emergency Medical Services
('user9', 'role10'), -- Emergency Technician
('user10', 'role10'), -- Emergency Technician
-- Biotechnology
('user11', 'role11'), -- Biotech Specialist
('user12', 'role11'), -- Biotech Specialist
-- Diagnostics Companies
('user13', 'role13'), -- Diagnostics Specialist
('user14', 'role13'), -- Diagnostics Specialist
-- Dietetics and Nutrition
('user15', 'role15'), -- Dietitian
('user16', 'role15'), -- Dietitian
-- Healthcare Administration
('user17', 'role4'), -- Health Administrator
('user18', 'role17'), -- Health IT Specialist
-- Hospitals
('user19', 'role19'), -- Home Healthcare Provider
('user20', 'role20'); -- Hospital Receptionist
