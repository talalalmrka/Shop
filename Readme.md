# 🛒 Shop

مشروع متجر ASP.NET Core MVC مع إدارة المنتجات، الفئات، وسلة التسوق.

---

## متطلبات التشغيل

- Visual Studio 2022 أو أحدث
- .NET 9 SDK
- SQLite (مدمج مع المشروع في `app.db`)

---

## تشغيل المشروع

1. افتح المشروع عبر `Shop.csproj` في Visual Studio.
2. استعادة الحزم:

```powershell
dotnet restore
```

3. إنشاء قاعدة البيانات وتشغيل Migrations:

```powershell
dotnet ef database update
```

4. تشغيل المشروع:

- اضغط **F5** في Visual Studio.
- افتح المتصفح على:

  ```
  http://localhost:5000
  ```

---

## Seeders لبيانات تجريبية

المشروع يحتوي على Seeders للفئات والمنتجات:

- `CategorySeeder.cs` → إضافة فئات افتراضية
- `ProductSeeder.cs` → إضافة منتجات لكل فئة

لتشغيل Seeders أضف هذا في `Program.cs` قبل `app.Run();`:

```csharp
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    CategorySeeder.Seed(context);
    ProductSeeder.Seed(context);
}
```

---

## روابط الصفحات

- الصفحة الرئيسية: `/Home/Index`
- المنتجات: `/Home/Products`
- تفاصيل المنتج: `/Home/Product/{id}`
- سلة التسوق: `/Home/Cart`
- Checkout: `/Home/Checkout`
- نجاح الطلب: `/Home/OrderSuccess`
- Admin Area: `/Admin/Home`

---

## رفع المشروع على GitHub

```bash
git init
git add .
git commit -m "Initial commit"
git branch -M main
git remote add origin https://github.com/<username>/Shop.git
git push -u origin main
```

> استبدل `<username>` باسم حساب GitHub الخاص بك.

---

## ملاحظات

- الصور موجودة في `wwwroot/images/`
- CSS و JS موجودة في `wwwroot/css/` و `wwwroot/js/`
- Project يستخدم TailwindCSS و fadgram-ui للواجهات
- ملفات ViewComponents موجودة لإعادة الاستخدام (مثل ProductCard و Pagination)
