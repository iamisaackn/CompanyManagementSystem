USE company;

-- DELETE FROM AspNetUsers WHERE Id = 'user1';
-- DELETE FROM AspNetUsers WHERE Id = 'user2';

INSERT INTO AspNetUsers (Id, Discriminator, Firstname, Lastname, CreatedAt, UpdatedAt, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
VALUES
-- Health tech
('user1', 'ApplicationUser', 'Alice', 'Kimani', NOW(), NOW(), 'alicekimani', 'ALICEKIMANI', 'alice@example.com', 'ALICE@EXAMPLE.COM', 1, 'hashedpassword', 'stamp1', '1234567890', 1, 0, 1, 0),
-- Pharmaceuticals
('user2', 'ApplicationUser', 'Brian', 'Otieno', NOW(), NOW(), 'brianotieno', 'BRIANOTIENO', 'brian@example.com', 'BRIAN@EXAMPLE.COM', 1, 'hashedpassword', 'stamp2', '0987654321', 1, 0, 1, 0),
-- Medical device
('user3', 'ApplicationUser', 'Cynthia', 'Mutua', NOW(), NOW(), 'cynthiamutua', 'CYNTHIAMUTUA', 'cynthia@example.com', 'CYNTHIA@EXAMPLE.COM', 1, 'hashedpassword', 'stamp3', '1122334455', 1, 0, 1, 0),
-- Dentistry
('user4', 'ApplicationUser', 'Daniel', 'Wanjohi', NOW(), NOW(), 'danielwanjohi', 'DANIELWANJOHI', 'daniel@example.com', 'DANIEL@EXAMPLE.COM', 1, 'hashedpassword', 'stamp4', '2233445566', 1, 0, 1, 0),
-- Emergency medical services
('user5', 'ApplicationUser', 'Esther', 'Kariuki', NOW(), NOW(), 'estherkariuki', 'ESTHERKARIUKI', 'esther@example.com', 'ESTHER@EXAMPLE.COM', 1, 'hashedpassword', 'stamp5', '3344556677', 1, 0, 1, 0),
-- Biotechnology
('user6', 'ApplicationUser', 'Frank', 'Njoroge', NOW(), NOW(), 'franknjoroge', 'FRANKNJOROGE', 'frank@example.com', 'FRANK@EXAMPLE.COM', 1, 'hashedpassword', 'stamp6', '4455667788', 1, 0, 1, 0),
-- Diagnostics companies
('user7', 'ApplicationUser', 'Grace', 'Wambui', NOW(), NOW(), 'gracewambui', 'GRACEWAMBUI', 'grace@example.com', 'GRACE@EXAMPLE.COM', 1, 'hashedpassword', 'stamp7', '5566778899', 1, 0, 1, 0),
-- Dietetics
('user8', 'ApplicationUser', 'Henry', 'Maina', NOW(), NOW(), 'henrymaina', 'HENRYMAINA', 'henry@example.com', 'HENRY@EXAMPLE.COM', 1, 'hashedpassword', 'stamp8', '6677889900', 1, 0, 1, 0),
-- General medical services
('user9', 'ApplicationUser', 'Irene', 'Omondi', NOW(), NOW(), 'ireneomondi', 'IRENEOMONDI', 'irene@example.com', 'IRENE@EXAMPLE.COM', 1, 'hashedpassword', 'stamp9', '7788990011', 1, 0, 1, 0),
-- Specialist medical services
('user10', 'ApplicationUser', 'James', 'Njenga', NOW(), NOW(), 'jamesnjenga', 'JAMESNJENGA', 'james@example.com', 'JAMES@EXAMPLE.COM', 1, 'hashedpassword', 'stamp10', '8899001122', 1, 0, 1, 0),
-- Healthcare facilities
('user11', 'ApplicationUser', 'Katherine', 'Muriuki', NOW(), NOW(), 'katherinemuriuki', 'KATHERINEMURIUKI', 'katherine@example.com', 'KATHERINE@EXAMPLE.COM', 1, 'hashedpassword', 'stamp11', '9900112233', 1, 0, 1, 0),
-- Health administration
('user12', 'ApplicationUser', 'Leon', 'Mwangi', NOW(), NOW(), 'leonmwangi', 'LEONMWANGI', 'leon@example.com', 'LEON@EXAMPLE.COM', 1, 'hashedpassword', 'stamp12', '0011223344', 1, 0, 1, 0),
-- Health technology
('user13', 'ApplicationUser', 'Mary', 'Ngugi', NOW(), NOW(), 'maryngugi', 'MARYNGUGI', 'mary@example.com', 'MARY@EXAMPLE.COM', 1, 'hashedpassword', 'stamp13', '1122334455', 1, 0, 1, 0),
-- Hospitals
('user14', 'ApplicationUser', 'Nathan', 'Kamau', NOW(), NOW(), 'nathankamau', 'NATHANKAMAU', 'nathan@example.com', 'NATHAN@EXAMPLE.COM', 1, 'hashedpassword', 'stamp14', '2233445566', 1, 0, 1, 0),
-- Medical research
('user15', 'ApplicationUser', 'Olivia', 'Wafula', NOW(), NOW(), 'oliviawafula', 'OLIVIAWAFULA', 'olivia@example.com', 'OLIVIA@EXAMPLE.COM', 1, 'hashedpassword', 'stamp15', '3344556677', 1, 0, 1, 0),
-- Pharmaceuticals
('user16', 'ApplicationUser', 'Peter', 'Omondi', NOW(), NOW(), 'peteromondi', 'PETEROMONDI', 'peter@example.com', 'PETER@EXAMPLE.COM', 1, 'hashedpassword', 'stamp16', '4455667788', 1, 0, 1, 0),
-- Emergency medical services
('user17', 'ApplicationUser', 'Quinn', 'Mbugua', NOW(), NOW(), 'quinnmbugua', 'QUINNMBUGUA', 'quinn@example.com', 'QUINN@EXAMPLE.COM', 1, 'hashedpassword', 'stamp17', '5566778899', 1, 0, 1, 0),
-- Diagnostics companies
('user18', 'ApplicationUser', 'Ruth', 'Kariuki', NOW(), NOW(), 'ruthkariuki', 'RUTHKARIUKI', 'ruth@example.com', 'RUTH@EXAMPLE.COM', 1, 'hashedpassword', 'stamp18', '6677889900', 1, 0, 1, 0),
-- Biotechnology
('user19', 'ApplicationUser', 'Samuel', 'Kimani', NOW(), NOW(), 'samuelkimani', 'SAMUELKIMANI', 'samuel@example.com', 'SAMUEL@EXAMPLE.COM', 1, 'hashedpassword', 'stamp19', '7788990011', 1, 0, 1, 0),
-- BAYADA Home Healthcare
('user20', 'ApplicationUser', 'Tina', 'Mwangi', NOW(), NOW(), 'tinamwangi', 'TINAMWANGI', 'tina@example.com', 'TINA@EXAMPLE.COM', 1, 'hashedpassword', 'stamp20', '8899001122', 1, 0, 1, 0);
