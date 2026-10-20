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

**پیش‌نیازها:** .NET 10 SDK و [TaskManagerAPI](https://github.com/zahra88esmaeli-lgtm/TaskManagerAPI) که **باید اول اجرا شود**.

```
git clone https://github.com/zahra88esmaeli-lgtm/TaskManagerWeb.git
cd TaskManagerWeb/TaskManager
```

در `appsettings.json` مقدار `ApiSettings:BaseUrl` را برابر **آدرس API** بگذار (نه آدرس خود Web):

```json
"ApiSettings": { "BaseUrl": "http://localhost:5280" }
```

```
dotnet run
```

سپس آدرسی که در خروجی چاپ می‌شود (مثلاً `http://localhost:5217`) را در مرورگر باز کن.

<div dir="rtl">

## مخزن مرتبط
-- TaskManager API: [TaskManagerApi] (https://github.com/zahra88esmaeli-lgtm/TaskManagerAPI.git)

## سازنده
Niki

</div>
