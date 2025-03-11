-- DROP DATABASE company;

-- USE company;

-- INSERT INTO `AspNetUsers` (`Id`, `Discriminator`, `Firstname`, `Lastname`, `CreatedAt`, `UpdatedAt`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnabled`, `AccessFailedCount`)
-- VALUES
-- ('user1', 'ApplicationUser', 'John', 'Doe', NOW(), NOW(), 'johndoe', 'JOHNDOE', 'john@example.com', 'JOHN@EXAMPLE.COM', 1, 'hashedpassword', 'stamp1', '1234567890', 1, 0, 1, 0),
-- ('user2', 'ApplicationUser', 'Jane', 'Smith', NOW(), NOW(), 'janesmith', 'JANESMITH', 'jane@example.com', 'JANE@EXAMPLE.COM', 1, 'hashedpassword', 'stamp2', '0987654321', 1, 0, 1, 0);

-- INSERT INTO `Products` (`ProductId`, `Name`, `Description`, `ProductImage`, `CreatedAt`, `UpdatedAt`)
-- VALUES
-- ('prod1', 'Laptop', 'High-end gaming laptop', NULL, NOW(), NOW()),
-- ('prod2', 'Phone', 'Latest smartphone model', NULL, NOW(), NOW());

-- INSERT INTO `Employees` (`EmpId`, `UserId`, `FirstName`, `LastName`, `BirthDay`, `Sex`, `Salary`, `SupervisorId`, `BranchId`, `CreatedAt`, `UpdatedAt`)
-- VALUES
-- ('emp1', 'user1', 'John', 'Doe', '1990-05-20', 'M', 50000, NULL, NULL, NOW(), NOW()),
-- ('emp2', 'user2', 'Jane', 'Smith', '1992-07-15', 'F', 60000, 'emp1', NULL, NOW(), NOW());

-- INSERT INTO `Branches` (`BranchId`, `BranchName`, `ManagerId`, `ManagerStartDate`, `CreatedAt`, `UpdatedAt`)
-- VALUES
-- ('branch1', 'Downtown Office', 'emp1', NOW(), NOW(), NOW()),
-- ('branch2', 'Uptown Store', 'emp2', NOW(), NOW(), NOW());

-- INSERT INTO `Clients` (`ClientId`, `ClientName`, `BranchId`, `CreatedAt`, `UpdatedAt`)
-- VALUES
-- ('client1', 'ABC Corp', 'branch1', NOW(), NOW()),
-- ('client2', 'XYZ Ltd', 'branch2', NOW(), NOW());

-- INSERT INTO `Sales` (`SaleId`, `EmpId`, `ClientId`, `ProductType`, `Cost`, `CreatedAt`, `UpdatedAt`)
-- VALUES
-- ('sale1', 'emp1', 'client1', 'Laptop', 1200.00, NOW(), NOW()),
-- ('sale2', 'emp2', 'client2', 'Phone', 800.00, NOW(), NOW());

-- INSERT INTO `AspNetRoles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
-- ('role1', 'Admin', 'ADMIN', NULL),
-- ('role2', 'User', 'USER', NULL),
-- ('role3', 'Manager', 'MANAGER', NULL);



