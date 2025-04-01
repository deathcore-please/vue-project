# INTERVIEW TASK - Learned how to use .NET and VUE!

I created a Vue page to display the events stored in the SQLite database located in the **database** folder of the project file. It has the following columns:

- Event Id
- Date Time
- Event Type
- Location
- Fob Code

This is how my **Events page** looks like:

![image](https://github.com/user-attachments/assets/2d0ef6a1-b3d1-40a5-882b-b6a3427caa7a)

The **location** displays the area the event occurred in, and all of the parent areas above it in the chain. Each area in the areas chain in location is separated by a **" > "** symbol. The **event type** is displayed as a colored label:
- **Green** if access is authorized.
- **Red** if access is denied for any reason.

The **Date Time** is displayed in **DD/MM/YYYY HH:MM:SS** format and is **sorted with the newest events first**.

## 
The task took me a few hours (about **3-4 hours**) of solid sitting to complete since I had to learn **Vue** from scratch and draw parallels to my knowledge of **API integration** from a **Python-Django framework** to a **.NET framework**. 

Coming from an **ML background**, this was an extremely interesting task to complete, and it really helped me get a **working knowledge** of how the frontend and backend work, how **WebAPIs** are hosted, how to use **API endpoints**, and most importantly, how to **troubleshoot** while using an API endpoint for the frontend.

While I did use **ChatGPT** for this task, its role was limited to function implementation such that I had an understanding of the project at a **functional level**, making it far easier for me to understand and debug the code.

**PS:** Please change the variable "private readonly string _connectionString" variable inside EventsController.db to the absolute path where the eve.ts.db is stored in your pc, as a relative path breaks the code.

## 🛠️ How to Run the Project:

### Step 1: Clone the Repository
First, clone the project from the repository to your local machine:
```bash
git clone https://github.com/your-repo/CameKmsStarter.git
cd CameKmsStarter
```

### Step 2: Install .NET SDK
Make sure you have **.NET version 8** installed:
```bash
dotnet --version
```
If not, download and install it from the official .NET website:  
[.NET Download Page](https://dotnet.microsoft.com/download)

### Step 3: Configure the Database Path
Open the **EventsController.cs** file:
```
repo/Controllers/EventsController.cs
```
Locate the line:
```csharp
private readonly string _connectionString = @"Data Source=C:\Users\HP\Desktop\Everything Else\Python Projects\vue-project\repo\Database\events.db";
```
Replace the path with the **absolute path** to where `events.db` is stored on your system:
```csharp
private readonly string _connectionString = @"Data Source=ABSOLUTE_PATH_TO_EVENTS.DB";
```

### Step 4: Install Node.js (if not already installed)
Check your Node.js version:
```bash
node -v
npm -v
```
If not installed, download it from the official website:  
[Node.js Download Page](https://nodejs.org/)

### Step 5: Install Frontend Dependencies
Navigate to the ClientApp folder:
```bash
cd ClientApp
npm install
```

### Step 6: Run the Frontend Server
Start the frontend server:
```bash
npm run serve
```
This will start the Vue development server on:
```
http://localhost:8080
```

### Step 7: Run the Backend Server
Go back to the **root project folder**:
```bash
cd ..
dotnet run
```
This will start the backend server on:
```
http://localhost:5000
```

### Step 8: Access the Application
Now, open your browser and visit:
```
http://localhost:8080
```
Navigate to the **Events page** to see the data displayed as required.

## ✅ Troubleshooting:
- If you encounter **CORS issues**, make sure that the **backend server** is running correctly on **localhost:5000**.
- If the **events page is blank**, open the browser's **console** to check for errors and verify the API endpoint by visiting:
```
http://localhost:5000/api/events
```

## 📧 Support:
If you have any questions or run into issues, feel free to reach out to me!
