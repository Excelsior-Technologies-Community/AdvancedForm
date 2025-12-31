# AdvancedForm

This project is ideal for learning **real-world form handling**, **JavaScript library integration**, and **server-side image processing** in ASP.NET Core.

---

## 🚀 Features

- ✅ **TinyMCE Rich Text Editor**
- ✅ **Drag & Drop File Upload** (Dropzone.js)
- ✅ **Google Address Autocomplete** (optional)
- ✅ **Image Upload with Crop Tool** (CropperJS)
- ✅ **Drag & Drop Sequence Ordering**
- ✅ **ASP.NET Core MVC + EF Core**
- ✅ **Clean MVC Architecture**

---

## 🧱 Tech Stack

| Layer | Technology |
|-----|-----------|
| Backend | ASP.NET Core MVC (.NET 7/8) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Frontend | Razor Views + Bootstrap |
| JS Libraries | TinyMCE, Dropzone.js, CropperJS |
| Image Processing | Base64 → Server Save |

---

## 📁 Project Structure

AdvancedForm/
│
├── Controllers/
│   └── ContentController.cs
│
├── Models/
│   ├── ContentItem.cs
│   └── ImageCropRequest.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Views/
│   └── Content/
│       ├── Create.cshtml
│       └── Index.cshtml
│
├── wwwroot/
│   └── uploads/
│
└── README.md


---

## ⚙️ Setup Instructions

### 1️⃣ Clone / Open Project

```bash
git clone <repo-url>
cd AdvancedForm
````

---

### 2️⃣ Install Required Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

### 3️⃣ Configure Database

Update `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=AdvancedFormDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

### 4️⃣ Apply Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 5️⃣ Ensure Upload Folder Exists

Create this folder manually (once):

```
wwwroot/uploads
```

---

### 6️⃣ Run Project

```bash
dotnet run
```

Open browser:

```
https://localhost:7210/Content/Create
```
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/b37e5cc2-6c8a-4999-9654-37be96dc21ae" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/3f894cbe-eeb1-439f-b0e6-a773066ece75" />

```
https://localhost:7210/Content/Index
```
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/b7126e69-f273-4f9c-b851-9a14859dedb2" />


---

## 🖼️ Image Crop Feature (IMPORTANT)

This project uses **CropperJS v1.5.13**.

### ✅ Correct CDN (DO NOT CHANGE)

```html
<link href="https://unpkg.com/cropperjs@1.5.13/dist/cropper.min.css" rel="stylesheet" />
<script src="https://unpkg.com/cropperjs@1.5.13/dist/cropper.min.js"></script>
```



This is intentional for AJAX image upload.

---

## 🧪 How to Use the Form

1. Enter **Title**
2. Add **Content** using TinyMCE
3. (Optional) Enter **Address**
4. Upload files using **Drag & Drop**
5. Select image → crop → **Crop & Save**
6. Click **Save Content**
7. View saved items in **Index page**

---




