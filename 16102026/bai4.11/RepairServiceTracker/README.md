# Repair Service Tracker

Ứng dụng Windows Forms quản lý đơn đăng ký dịch vụ sửa chữa.

## Yêu cầu
- Windows
- .NET 8 SDK
- Visual Studio 2022 có workload **.NET desktop development**.
- Để mở file `.slnx`, dùng phiên bản Visual Studio 2022 có hỗ trợ Solution XML (bản mới). Nếu IDE chưa hỗ trợ `.slnx`, mở trực tiếp `RepairServiceTracker/RepairServiceTracker.csproj` hoặc tạo solution `.sln`.

## Cách chạy
1. Giải nén `RepairServiceTracker.zip`.
2. Mở `RepairServiceTracker.slnx` bằng Visual Studio.
3. Chọn project `RepairServiceTracker` làm Startup Project.
4. Nhấn `F5`.

## Chức năng
- Thêm, cập nhật và xóa đơn (xóa có xác nhận).
- Kiểm tra mã đơn không trùng, tên khách hàng, số điện thoại, mô tả lỗi và chi phí không âm.
- Tìm kiếm tức thời theo mã đơn, tên khách hàng hoặc số điện thoại.
- Lọc trạng thái.
- Chọn ảnh thiết bị và hiển thị đúng tỷ lệ bằng PictureBox.
- Xuất danh sách đang hiển thị ra CSV.
- StatusStrip hiển thị số đơn đang hiển thị và tổng chi phí của đơn chưa hoàn tất/chưa hủy.

## Ghi chú
- Dữ liệu mẫu được nạp khi khởi động để tiện kiểm thử.
- Dữ liệu hiện được lưu trong bộ nhớ; đóng ứng dụng sẽ không giữ lại các đơn đã thêm.
- Mã nguồn tạo giao diện bằng code, nên không cần file `Form1.Designer.cs`.
