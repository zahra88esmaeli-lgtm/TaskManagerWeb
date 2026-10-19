فارسی | [English](README.md)

<div dir="rtl">

# TaskManager Web

یک برنامه‌ی مدیریت تسک که با ASP.NET Core MVC ساخته شده است.
این برنامه با یک REST API جدا (TaskManager API) و با احراز هویت JWT کار می‌کند.

## امکانات
- ثبت‌نام و ورود کاربر (توکن JWT در Session ذخیره می‌شود)
- تغییر رمز عبور و حذف حساب کاربری
- ساخت، ویرایش، حذف و نمایش تسک‌های شخصی
- نمایش پیام خطای مناسب وقتی API در دسترس نیست

## تکنولوژی‌ها
- C# و ASP.NET Core MVC
- Typed HttpClient برای ارتباط با API
- احراز هویت JWT و Session
- Bootstrap

## نحوه‌ی اجرا
1. اول پروژه‌ی TaskManager API را دریافت و اجرا کنید.
2. آدرس API را در `appsettings.json` تنظیم کنید:

</div>

```json
"ApiSettings": { "BaseUrl": "https://localhost:7244/" }
```

<div dir="rtl">

3. سپس این پروژه را اجرا کنید:

</div>

```bash
dotnet run
```

<div dir="rtl">

## مخزن مرتبط
-- TaskManager API: [TaskManagerApi](https://github.com/YOUR-USERNAME/TaskManagerApi)

## سازنده
Niki

</div>
