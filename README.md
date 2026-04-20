# 🔐 SecureVault – C# Console-Based Encryption & Decryption System

## 📌 Overview

SecureVault is a console-based application developed in C# that allows users to securely encrypt and decrypt files using multiple cryptographic algorithms. The project demonstrates strong implementation of Object-Oriented Programming (OOP) concepts along with file handling, error handling, and containerization using Docker.

---

## 🎯 Features

* 🔒 Multiple encryption & decryption algorithms
* 📂 Supports text and media files
* 🧠 Strong OOP implementation (Abstraction, Inheritance, Polymorphism, Encapsulation)
* 🧾 Flat file database for storing history
* ⚠️ Exception handling for safe execution
* 🖥️ Clean and interactive console UI
* 📦 Docker support for containerized execution

---

## 🛠️ Technologies Used

* **Language:** C#
* **Framework:** .NET Framework 4.7.2
* **IDE:** Visual Studio
* **Database:** Flat File System
* **Containerization:** Docker Desktop (Windows Containers)
* **OS Support:** Windows

---

## 🔐 Encryption Algorithms Implemented

The application includes the following algorithms:

1. Caesar Cipher
2. Vigenère Cipher
3. Base64 Encoding
4. AES (Advanced Encryption Standard)
5. RSA (Rivest–Shamir–Adleman)
6. DES (Data Encryption Standard)

---

## 🧱 Project Structure

```
SecureVault/
│
├── Program.cs
├── DatabaseService.cs
├── FileDialogHelper.cs
│
├── Core/
│   ├── ICipher.cs
│   ├── CipherBase.cs
│
├── Algorithms/
│   ├── CaesarCipher.cs
│   ├── VigenereCipher.cs
│   ├── Base64Cipher.cs
│   ├── AesCipher.cs
│   ├── RsaCipher.cs
│   ├── DesCipher.cs
│
├── bin/
├── obj/
└── Dockerfile
```

---

## ▶️ How to Run (Without Docker)

1. Open project in **Visual Studio**
2. Build the solution:

   ```
   Build → Build Solution
   ```
3. Run the application:

   ```
   Ctrl + F5
   ```
4. Follow on-screen console instructions:

   * Select Encrypt/Decrypt
   * Choose algorithm
   * Enter key (if required)
   * Select file
   * Save output

---

## 🐳 How to Run with Docker

### 🔹 Prerequisites

* Docker Desktop installed
* Windows Containers enabled

---

### 🔹 Step 1: Create Dockerfile

Ensure the following Dockerfile exists in the root directory:

```dockerfile
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8
WORKDIR /app
COPY . .
CMD ["SecureVault.exe"]
```

---

### 🔹 Step 2: Build Docker Image

Open terminal in project directory and run:

```bash
docker build -t securevault .
```

---

### 🔹 Step 3: Run Container

```bash
docker run -it securevault
```

---

### ⚠️ Note

File dialog (OpenFileDialog) does not work inside Docker containers.
Use manual file path input when running in Docker.

---

## 💾 Data Storage

* The application uses a **flat file database** to store:

  * Operation type (Encrypt/Decrypt)
  * Algorithm used
  * File path
  * Timestamp

---

## ⚠️ Exception Handling

* Handles invalid inputs
* Prevents crashes during file operations
* Ensures smooth execution with user-friendly messages

---

## 🎓 Learning Outcomes

This project demonstrates:

* Practical implementation of **OOP principles**
* Working with **file systems in C#**
* Implementation of **multiple encryption techniques**
* Use of **Docker for application deployment**
* Building structured and scalable console applications

---

## 🚀 Future Improvements

* GUI version (Windows Forms / WPF)
* Cloud storage integration
* Stronger encryption standards
* User authentication system
* Real database integration (SQL Server)

---

## 👩‍💻 Author

**Irsa Maryam**
BS Computer Science Student

---

## 📄 License

This project is developed for academic purposes and learning.

---
