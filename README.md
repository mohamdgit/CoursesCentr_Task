# My Project

## ERD
![ERD Diagram](erdimage/Erd-diagram.png)

---

## Project Overview
هذا المشروع عبارة عن **Training Center System** مصمم باستخدام .NET، ويحتوي على APIs لإدارة الطلبة والكورسات والمدرسين.

---

## APIs

### 1️⃣ Get Students
- **Endpoint:** `GET /api/getstudents`  
- **الوصف:** تجيب قائمة الطلبة **بدون التفاصيل الكاملة**، بس بياناتهم الأساسية (مثل الاسم والإيميل).

### 2️⃣ Get Student Details
- **Endpoint:** `GET /api/getstudentdetails`  
- **الوصف:** تجيب كل الطلبة مع:
  - الكورسات اللي مسجلين فيها  
  - المدرسين المرتبطين  
- **ميزات:** يمكن البحث عن طالب معين بالاسم أو غيره.

### 3️⃣ Get Student by ID
- **Endpoint:** `GET /api/get/student/{id}`  
- **الوصف:** تجيب بيانات طالب محدد فقط.

### 4️⃣ Add / Edit / Delete
- **Endpoints:**  
  - `POST /api/addstudent`  
  - `PUT /api/editstudent`  
  - `DELETE /api/deletestudent/{id}`  

---

## Architecture & Patterns Used

- **Unit of Work (UoW) Pattern** → لإدارة الـ transactions على قاعدة البيانات بشكل مركزي.  
- **Generic Repository Pattern** → للوصول للـ entities بدون تكرار الكود.  
- **Service Manager Pattern** → لفصل الـ business logic عن الـ controller.  
- **Specification Pattern** → لعمل استعلامات ديناميكية وفلترة للبيانات.  
- **AutoMapper & Manual Mapper** → لتحويل الـ entities إلى DTOs.  
- **DTOs (Data Transfer Objects)** → لفصل البيانات التي ترسل/تستقبل عن الـ entities.  
- **Seeding for Data** → لإضافة بيانات تجريبية عند إنشاء قاعدة البيانات.

---

## Features
- RESTful APIs لإدارة الطلبة والكورسات والمدرسين.  
- بحث متقدم عن الطلبة بالكورسات أو بالمدرسين.  
- فصل واضح بين الـ layers (Controller → Service → Repository → DbContext).  
- استخدام Patterns لتسهيل الصيانة وإعادة الاستخدام.  
