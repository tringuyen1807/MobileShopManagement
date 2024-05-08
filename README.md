# final

Hướng dẫn Thay đổi Nguồn Dữ liệu
Trong ứng dụng của bạn, nguồn dữ liệu hiện tại được cấu hình để sử dụng một máy chủ cụ thể (ví dụ: LAPTOP-LB0J18JM\SQLEXPRESS) để kết nối với cơ sở dữ liệu. Đối với mỗi máy tính, tên máy chủ và cài đặt cụ thể có thể khác nhau. Dưới đây là cách thay đổi nguồn dữ liệu:

Mở File Connection.cs: Mở tệp Connection.cs trong dự án của bạn.
Tìm chuỗi Kết nối: Tìm đến dòng code sau:

string s = "initial catalog = MobileShopManagement; data source = LAPTOP-LB0J18JM\\SQLEXPRESS; integrated security = true";

Thay đổi tên máy chủ: Thay đổi phần "LAPTOP-LB0J18JM\\SQLEXPRESS" thành tên máy chủ SQL Server bạn muốn kết nối.
Lưu và Biên dịch: Sau khi thay đổi, lưu tệp Connection.cs và biên dịch lại dự án của bạn.

Link github: https://github.com/tringuyen1807/MobileShopManagement.git