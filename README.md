# C# TCP Driver for Secure Communication with Industrial Devices

## 📌 Project Overview
This project is a **C# TCP Server-Client communication driver** that enables **secure interaction** with industrial devices such as PLCs (Programmable Logic Controllers). It includes features like **TLS encryption**, **multithreading**, **logging**, and a **WPF UI** for real-time monitoring.

---

## 📂 Project Structure
```
📁 CSharpTcpDriver/
 ├── 📄 TcpServer.cs   (Multi-client TCP Server with TLS)
 ├── 📄 TcpClientApp.cs (TCP Client for testing commands)
 ├── 📄 Logger.cs      (File-based logging system)
 ├── 📄 SensorData.cs  (Simulated PLC sensor readings)
 ├── 📁 UI/
 │   ├── 📄 MainWindow.xaml  (WPF GUI for monitoring)
 │   ├── 📄 MainWindow.xaml.cs (Logic for UI updates)
 ├── 📁 Certificates/  (TLS Certificates for secure communication)
 ├── 📄 README.md  (Project documentation)
```

---

## 🚀 Features
✅ **Multi-client TCP server** with **TLS encryption** (via OpenSSL).  
✅ **C# TCP client** for sending commands.  
✅ **Simulated PLC sensor data** (temperature, humidity, status).  
✅ **Real-time monitoring UI** built with **WPF**.  
✅ **Logging system** to track server activity.  
✅ **Error handling** for secure and stable communication.  
✅ **Multithreading** for handling multiple clients simultaneously.  

---

## ⚙️ Installation & Setup
### 1️⃣ Clone the Repository
```sh
git clone https://github.com/your-repo/CSharpTcpDriver.git
cd CSharpTcpDriver
```

### 2️⃣ Install Dependencies
Ensure you have **.NET 6+** installed. You can check by running:
```sh
dotnet --version
```
If not installed, download from [Microsoft .NET](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

### 3️⃣ Generate TLS Certificates (Optional)
The project includes default certificates under the `Certificates/` folder, but you can generate your own:
```sh
openssl req -x509 -newkey rsa:4096 -keyout server.key -out server.crt -days 365
openssl pkcs12 -export -out Certificates/server.pfx -inkey server.key -in server.crt
```

---

## ▶️ Running the Project
### 1️⃣ Start the Server
```sh
dotnet run --project TcpServer.cs
```
The server listens on port **5000** and accepts multiple clients.

### 2️⃣ Run the TCP Client
```sh
dotnet run --project TcpClientApp.cs
```
Enter predefined commands like:
```sh
GET_TEMP
GET_HUMIDITY
GET_STATUS
```
The client will receive simulated PLC sensor data.

### 3️⃣ Run the WPF Monitoring UI (Optional)
Open `CSharpTcpDriver.sln` in **Visual Studio**, set `UI/MainWindow.xaml` as the startup project, and run it.

---

## 🔥 Example Output
**Client sends:**
```sh
GET_TEMP
```
**Server responds:**
```sh
Temperature: 25.3°C
```

**Client sends:**
```sh
GET_STATUS
```
**Server responds:**
```sh
Status: Active
```

---

## 🛠️ Technologies Used
- **C# .NET 6+**
- **TCP/IP Sockets**
- **Multithreading**
- **TLS Encryption (OpenSSL)**
- **WPF for UI**
- **Logging & Error Handling**

---

## 👨‍💻 Future Improvements
✅ **Database storage** for logged data.
✅ **Web API** for remote monitoring.
✅ **MQTT Integration** for IoT devices.
✅ **PLC Protocols Support (Modbus, Profinet, etc.)**.



