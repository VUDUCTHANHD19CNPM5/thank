# Lab Equipment Checkout

Ứng dụng Windows Forms C# quản lý mượn trả thiết bị tại phòng thực hành.

## Yêu cầu
- Windows
- Visual Studio 2022 (có workload **.NET desktop development**)
- .NET 8 SDK

## Chạy ứng dụng
1. Giải nén ZIP.
2. Mở `LabEquipmentCheckout.csproj` bằng Visual Studio.
3. Chọn cấu hình `Debug` và chạy bằng F5.

Hoặc mở Terminal tại thư mục dự án:
```powershell
dotnet run
```

## Chức năng
- Thêm, cập nhật, xóa phiếu (xóa có xác nhận).
- Chọn thiết bị từ ComboBox, nhập ngày bằng DateTimePicker.
- Kiểm tra mã phiếu trùng, mã sinh viên, họ tên, thiết bị, số lượng, hạn trả và ngày trả.
- Tìm theo mã sinh viên hoặc tên thiết bị.
- Lọc theo trạng thái Đang mượn / Quá hạn / Đã trả.
- Tự động nhận diện phiếu quá hạn nếu chưa trả và hạn trả trước ngày hiện tại.
- Đánh dấu đã trả, tự điền ngày trả thực tế.
- StatusStrip hiển thị tổng số phiếu và số phiếu quá hạn.
- Xuất các phiếu đang hiển thị ra CSV.
- Có sẵn một vài dữ liệu mẫu để thử nghiệm. Dữ liệu chỉ nằm trong bộ nhớ, chưa lưu vào cơ sở dữ liệu.

## Kiểm thử nhanh
1. Nhập ngày mượn hôm nay và hạn trả hôm qua: cần báo lỗi, không lưu.
2. Chọn phiếu PM001 mẫu: phiếu có hạn trả đã qua và chưa trả phải là Quá hạn.
3. Chọn phiếu đang mượn và bấm **Đánh dấu đã trả**: ngày trả và trạng thái trên bảng được cập nhật.
