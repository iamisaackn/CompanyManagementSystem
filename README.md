# CompanyManagementSystem

## **Step 1: Download the Required Software**
1. **Download MySQL Workbench**:
   - Go to the [MySQL official website](https://dev.mysql.com/downloads/workbench/).
   - Select your operating system and download the installer.
   - Run the installer and follow the instructions to install MySQL Workbench on your computer.

2. **Download XAMPP**:
   - Visit the [XAMPP official website](https://www.apachefriends.org/index.html).
   - Download the installer for your operating system.
   - Run the installer and follow the steps to install XAMPP.

3. **Download Microsoft Visual Studio**:
   - Navigate to the [Microsoft Visual Studio website](https://visualstudio.microsoft.com/).
   - Download the Community edition (free version).
   - Install it on your system and include `.NET desktop development` in the installation options.

## **Step 2: Configure MySQL Workbench**
1. **Open MySQL Workbench**:
   - Launch the application after installation.

2. **Set Up a New Connection**:
   - Click the **+** button (New Connection) in the main screen.
   - Fill in the connection details:
     - **Connection Name**: Local Host (or any name you prefer).
     - **Hostname**: 127.0.0.1 (this refers to your local machine).
     - **Port**: 3306 (default MySQL port).
     - **Username**: root (default MySQL username).
   - Save the connection and test it to ensure it works.

## **Step 3: Start XAMPP**
1. **Open XAMPP Control Panel**:
   - Launch XAMPP after installation.

2. **Start the Required Services**:
   - Start **Apache** (web server).
   - Start **MySQL** (database server).

3. **Access phpMyAdmin**:
   - Click the **Admin** button next to MySQL in the XAMPP control panel.
   - This will open your default web browser and redirect you to the phpMyAdmin page where you can manage your databases.

## **Step 4: Create Migrations**
1. Open your project directory in a terminal or command prompt.
2. Use the following command to create an initial migration for your database schema:
   ```bash
   dotnet ef migrations add InitialCreate
   ```
   - This will generate a migration file that describes the changes to your database schema.

## **Step 5: Apply Migrations to the Database**
1. Apply the migration to update your database schema:
   ```bash
   dotnet ef database update
   ```
   - This will apply all pending migrations to your database.

2. If you want to generate a migration script (SQL script), use:
   ```bash
   dotnet ef migrations script
   ```

## **Step 6: Build and Run Your Project**
1. Build your project to ensure everything is working properly:
   ```bash
   dotnet build
   ```

2. Run the application to test it:
   ```bash
   dotnet run
   ```

## **Step 7: Open the Project in Visual Studio**
1. Locate the `CompanyManagementSystem.sln` file in your project directory.
2. Double-click the file to open it in Microsoft Visual Studio.
3. Use Visual Studio to review, debug, and edit your application as needed.

## **Key Notes**
- Make sure the database connection settings (e.g., `connection string` in `appsettings.json`) match your local MySQL setup.
- Ensure that XAMPP services (Apache and MySQL) are running whenever you work with your application.
- Always test your migrations and database updates on a non-production environment first.
