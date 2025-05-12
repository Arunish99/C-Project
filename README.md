# 🎓 Student Grade Management System (C# Console Application)

A simple C# console application to manage student records, calculate average marks, assign grades, and store/retrieve data using file handling.

---

## 📌 Features

- ➕ Add new student records (Name, Roll No, Subject-wise Marks)
- 📊 Calculate total and average marks
- 🏅 Assign grades based on average performance
- 🔍 Search students by roll number
- 📁 Save data to file and load it on startup

---

## 💻 Technologies Used

- C# (.NET Framework/Core)
- Object-Oriented Programming (OOP)
- File Handling (Text File)
- LINQ for data operations

---

## 🏗️ Project Structure

- `Student` class: Encapsulates student data and behavior
- `Program` class: Manages user input, menu operations, and data persistence
- `students.txt`: Stores student records persistently (created automatically)

---

## 🚀 How to Run

1. Clone this repository or copy the code into a new console project in Visual Studio or VS Code.
2. Build and run the project.
3. Follow the on-screen menu to add, view, search, or exit the application.
4. Student records are saved in `students.txt` in the project directory.

---

## 📷 Sample Output

```text
--- Student Grade Management ---
1. Add Student
2. View All Students
3. Search Student by Roll No
4. Save & Exit
Enter choice: 1
Enter Roll No: 101
Enter Name: Alice
Enter marks for Subject 1: 85
Enter marks for Subject 2: 90
Enter marks for Subject 3: 88
Student added successfully.
