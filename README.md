# Blazor Cart Demo — Hướng dẫn chạy

Ứng dụng demo quản lý giỏ hàng viết bằng Blazor WebAssembly (hosted/static template). Tài liệu ngắn này chỉ cách build và chạy dự án trên máy local.

## Yêu cầu
- .NET SDK 9.x (repo có `global.json` để pin SDK 9.0.x). Nếu máy bạn đang dùng .NET 10 và gặp lỗi, cài .NET 9 hoặc dùng `global.json` để pin SDK.
- Windows (hướng dẫn dưới dùng PowerShell/terminal trên Windows).

## Thiết lập và build
1. Mở terminal ở thư mục dự án:

```powershell
cd C:\Users\ADMIN\Desktop\dotnet-blazor\Blazor-cart-demo
```

2. Khôi phục và build:

```bash
dotnet restore
dotnet build
```

## Chạy ở chế độ phát triển
Chạy app cục bộ (chỉ định port nếu muốn):

```bash
dotnet run --urls http://localhost:5199
```

- Nếu port bị chiếm, đổi `5199` thành port rảnh (ví dụ `5188`, `5144`).
- Dừng server bằng `Ctrl+C`.

## Publish (sản xuất)

```bash
dotnet publish -c Release -o publish
```

Thư mục đầu ra: `publish`.

## Các file hữu ích trong mã nguồn
- Trang giỏ hàng: [Pages/Cart.razor](Pages/Cart.razor)
- Trang thanh toán (checkout): [Pages/Checkout.razor](Pages/Checkout.razor)
- Service quản lý giỏ: [Services/CartState.cs](Services/CartState.cs)
- CSS chính: [wwwroot/css/app.css](wwwroot/css/app.css)
- File khởi động client: [wwwroot/index.html](wwwroot/index.html)

## Thay đổi port / URL
- Dùng `--urls` như ví dụ ở trên.
- Hoặc chỉnh `Properties/launchSettings.json` nếu chạy trong Visual Studio/VS Code launch profile.

## Vấn đề thường gặp & cách xử lý
- Lỗi biên dịch liên quan .NET 10 (CET): cài .NET 9 hoặc dùng `global.json` trong repo.
- 404 `_framework/blazor.webassembly.js`: chạy `dotnet build` rồi `dotnet run` để đảm bảo assets được sinh.
- Lỗi preload/importmap từ template mới: mở `wwwroot/index.html` và loại bỏ placeholder không hợp lệ.

## Mẹo nhanh
- Mã đơn hàng ở trang checkout là giả lập (không có backend). Nếu muốn lưu giỏ khi reload, mình có thể thêm localStorage.

---
Nếu bạn muốn, mình sẽ bổ sung phần Dockerfile, hướng dẫn CI, hoặc lưu giỏ hàng/đơn vào localStorage. Nói mình làm tiếp nhé.