# Route MVC Project – Gym Management System

🌐 **Live Demo:** http://mygymmanagment.runasp.net/  
🎥 **Project Walkthrough Video:** https://drive.google.com/file/d/1hFKY7rW5r1RNzcY26mB57fzCTlCR4fxf/view?usp=drive_link  
📜 **Certificate:** https://drive.google.com/file/d/19RqIrDpleaDBigK_zqCGFvM50ogRDtXL/view?usp=drive_link  

---

## Overview

This is a **3-layer ASP.NET Core MVC** application built to demonstrate **clean architecture** and **best practices** in .NET development.  
The solution is structured into **Presentation**, **Business Logic**, and **Data Access** layers with clear separation of concerns.

---

## Architecture

### 1) Data Access Layer (DAL)
- Defines domain **Entities** representing core models.
- Implements **Repository Pattern** (interfaces + implementations) to abstract data operations.
- Includes **Entity configurations** and entity relationships.
- Provides **Database Seeding** to initialize the database with sample/required data.
- Keeps data access clean, maintainable, and testable.

### 2) Business Logic Layer (BLL)
- Contains **Services** that encapsulate business rules and workflows.
- Includes **service interfaces** to support Dependency Injection and unit testing.
- Uses **ViewModels / DTOs** and mapping logic to transform entities into presentation models.
- Supports consistent data flow through automated mapping.

### 3) Presentation Layer (MVC)
- Implements **MVC Controllers** to handle HTTP requests and orchestrate responses.
- Uses **Razor Views** for UI rendering, keeping business logic out of views.
- Includes shared components / filters to promote reuse and consistency.
- Handles **validation**, **error handling**, and user-friendly presentation.

---

## Project Highlights
- Clean **layered architecture** and modular design.
- Applies **Dependency Injection**, **Repository Pattern**, and **Service Pattern**.
- Includes full database setup: **configuration + initialization + seeding** (ready-to-run).
- Built as a complete end-to-end project after finishing a learning course, showcasing practical ASP.NET Core MVC skills.

---

## Notes
- The repository includes a **final walkthrough video** demonstrating features and project structure.
