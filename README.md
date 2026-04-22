

# 🔐 SecureVault – Modern .NET 6.0 Encryption & Decryption System

## 📌 Overview
SecureVault is a robust cryptographic utility developed using **C#** and the modern **.NET 6.0** framework. It provides secure end-to-end data encryption while bridging the gap between legacy desktop utilities and modern distributed environments. The application is fully containerized using **Docker** to ensure seamless deployment and portability across different platforms.

---

## 🎯 Features
* 🔒 **Industrial-Grade Cryptography:** Supports multiple high-speed symmetric and asymmetric algorithms.
* 📂 **Universal Support:** Designed to handle various file types and metadata.
* 🧠 **Modular OOP Architecture:** Clean separation of concerns using Abstraction and Interfaces (`ICipher.cs`).
* 🧾 **Persistence Layer:** Lightweight flat-file database system for logging encryption history (`history.txt`).
* 🖥️ **Adaptive UI:** Supports Windows Native File Explorer via `FileDialogHelper.cs` and console-based input for Linux/Docker.
* 📦 **Multi-Stage Dockerization:** Optimized for small image sizes and high-availability deployment.

---

## 🛠️ Technologies Used
* **Language:** C# 10
* **Framework:** .NET 6.0 (Migrated from legacy .NET Framework 4.7.2)
* **IDE:** Visual Studio 2022 / 2026 Community
* **Database:** Flat File System (Local Persistence)
* **Containerization:** Docker Desktop

---

## 🔐 Encryption Algorithms Implemented
The application includes a wide range of algorithms for educational and practical use:
1. **AES (Advanced Encryption Standard):** High-speed symmetric encryption.
2. **RSA (Rivest–Shamir–Adleman):** Asymmetric public/private key logic.
3. **DES (Data Encryption Standard):** Legacy block cipher.
4. **Base64 Encoding:** Binary-to-text representation.
5. **Caesar & Vigenère Ciphers:** Classic cryptographic examples.

---

## 🧱 Project Structure
```text
SecureVault/
├── Program.cs
├── DatabaseService.cs
├── FileDialogHelper.cs
├── Core/
│   ├── ICipher.cs (Interface)
│   └── CipherBase.cs (Abstract Base)
├── Algorithms/
│   ├── AesCipher.cs
│   ├── RsaCipher.cs
│   ├── DesCipher.cs
│   └── ... (Legacy Ciphers)
└── Dockerfile (Multi-stage build)
```


---

## 🐳 Docker Strategy & Deployment
SecureVault uses a **Multi-Stage Build** to ensure the production image is lightweight and contains only the necessary runtime.

### 🔹 Step 1: The Dockerfile
```dockerfile
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "SecureVault.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SecureVault.dll"]
```

### 🔹 Step 2: Build & Run
1. Open a terminal in the project directory.
2. Build the image:
   `docker build -t secure-vault .`
3. Run the interactive container:
   `docker run -it secure-vault`

---

## 🖼️ Visual Outputs

### 🖥️ Windows Interface
On Windows, the application successfully triggers native dialogs for file selection.
*(Insert Screenshot: VS Main Menu / File Explorer)*

### 🐳 Docker Deployment
The containerized application shows active status in Docker Desktop.
*(Insert Screenshot: Docker Build Terminal)*

---

## 🎓 Technical Challenges Overcome
* **Framework Migration:** Successfully migrated logic from .NET 4.7.2 to .NET 6.0 to allow cross-platform compatibility.
* **Conditional Compilation:** Used `#if WINDOWS` directives to handle GUI-specific code that cannot run in headless Docker environments.
* **Path Management:** Resolved "Access Denied" errors and drive migration issues (C: to E:) by clearing build artifacts and resetting permissions.

---

**Author:** Irsa Maryam
**Course:** Parallel & Distributed Computing (Lab)
**Date:** April 2026
