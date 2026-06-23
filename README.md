# 🚀 Metigator EF Core Course - Practical Application

هذا المستودع يحتوي على التطبيق العملي والمشاريع الخاصة بكورس **Entity Framework Core** (أسلوب Code-First). يركز المشروع على بناء بنية قواعد بيانات متكاملة لنظام إدارة أكاديمي (طلاب، كورسات، شعب دراسية، وجداول) وتطبيق أفضل الممارسات لتنظيم الكود وعمل الـ Migrations.

---

## 🛠️ التقنيات المستخدمة (Tech Stack)

* **Language:** C# (.NET 8.0 / .NET 9.0)
* **Framework:** Entity Framework Core
* **Database System:** SQL Server
* **Architecture:** Clean Architecture principles using Separate Configurations (`IEntityTypeConfiguration`)

---

## 📐 مخطط قاعدة البيانات والعلاقات (Database Schema)

يحتوي المشروع على الكيانات (Entities) التالية والعلاقات البرمجية بينها:

* **Student & Section:** علاقة متعدد إلى متعدد (*Many-to-Many*) تدار عبر جدول وسيط مخصص وهو `Enrollment` ويحتوي على مفتاح مركب (*Composite Primary Key*).
* **Section & Schedule:** علاقة متعدد إلى متعدد (*Many-to-Many*) تدار عبر جدول وسيط `SectionSchedule`.
* **Course & Section:** علاقة واحد إلى متعدد (*One-to-Many*).
* **Instructor & Section:** علاقة واحد إلى متعدد (*One-to-Many*).

---

## ⚙️ الميزات والمفاهيم المطبقة (Key Concepts Applied)

- [x] **Fluent API:** عزل إعدادات الجداول بالكامل عن الـ Entities في مجلد `Data/Configuration`.
- [x] **Composite Keys:** إعداد مفاتيح مركبة للجداول الوسيطة يدوياً وبشكل صريح.
- [x] **Data Seeding:** حقن بيانات أولية تلقائياً أثناء إنشاء قاعدة البيانات عبر `HasData`.
- [x] **Code-First Migrations:** إدارة وتحديث بنية قاعدة البيانات خطوة بخطوة وتجنب مشاكل الـ Conflicts.

---

## 🚀 كيف تبدأ وتشغل المشروع عندك؟ (Getting Started)

### 1. المتطلبات الأساسية
تأكد من تثبيت الأدوات التالية على جهازك:
* Visual Studio 2022 (أو أحدث)
* .NET SDK
* SQL Server LocalDB أو Local Instance

### 2. إعداد سلسلة الاتصال (Connection String)
قم بتعديل السلسلة داخل ملف الـ `DbContext` أو ملف الإعدادات لتشير إلى السيرفر الخاص بك:
```csharp
"Server=.;Database=
