# QUẢN LÝ HỘI THẢO
Hệ thống hỗ trợ quản lý toàn bộ quy trình tổ chức hội thảo khoa học của Khoa Công nghệ Thông tin, Trường Đại học Công Thương TP.HCM (HUIT).  
Từ khâu tiếp nhận bài viết, phản biện, phê duyệt đến xuất kết quả và báo cáo.

-----

## Mục lục
- [🚀 Giới thiệu](#-giới-thiệu)
- [🛠️ Công nghệ sử dụng](#️-công-nghệ-sử-dụng)
- [✨ Tính năng](#-tính-năng)
- [⚙️ Cài đặt & chạy](#-cài-đặt--chạy)
- [📸 Giao diện minh họa](#-giao-diện-minh-họa)
- [📬 Góp ý & Đóng góp](#-góp-ý--đóng-góp)
- [👨‍💻 Tác giả](#-tác-giả)
- [📄 Giấy phép](#-giấy-phép)

-----

## 🚀 Giới thiệu
Hệ thống giúp ban tổ chức dễ dàng:
- Quản lý thông tin người dùng (tác giả, phản biện, ban tổ chức)
- Thu nhận bài viết và phản hồi kết quả
- Phân công phản biện tự động
- Xuất danh sách bài được duyệt, thông báo kết quả qua Email

-----

## 🛠️ Công nghệ sử dụng
- 💻 **Backend**: ASP.NET MVC / .NET Framework 4.7.2
- 🗃️ **Database**: SQL Server + Entity Framework
- 🌐 **Frontend**: Razor Pages + Bootstrap 5 + HTML, CSS, Javascript
- 📤 **Gửi mail**: SMTP / MailKit
- 🔒 **Bảo mật**: Xác thực người dùng bằng Identity

-----

## ✨ Tính năng
- 🔐 Đăng nhập / Đăng xuất
- 📝 Nộp bài viết và chỉnh sửa
- 👨‍🔬 Quản lý phản biện, phân công bài
- 📧 Gửi email tự động thông báo kết quả
- 📄 Xuất báo cáo, thống kê theo hội thảo

-----

## ⚙️ Cài đặt & chạy
```bash
git clone https://github.com/tenban/ql-hoithao-huit.git
cd ql-hoithao-huit
dotnet restore
dotnet ef database update
dotnet run
```

-----

## 📸 Giao diện minh họa
Thêm ảnh giao diện vào thư mục images/ và sử dụng đường dẫn tương đối hoặc link ảnh trực tuyến

-----

## 📬 Góp ý & Đóng góp
Bạn có thể:
- Tạo Issue
- Gửi Pull Request
- Liên hệ trực tiếp với nhóm phát triển

-----

## 👨‍💻 Tác giả
- Nhóm trưởng: Nguyễn Hồng Thanh Thiện - MSSV: 2001216176 - Công việc:
- Thành viên 1: Ngô Gia Bảo - Công việc:
- Thành viên 2: Nguyễn Tiến Phước - Công việc:

-----

## 📄 License
Dự án được phát hành theo giấy phép MIT License. Xem chi tiết trong file LICENSE.
