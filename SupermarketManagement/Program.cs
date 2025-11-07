using System;
using SupermarketManagement.Models;
using SupermarketManagement.Services;

namespace SupermarketManagement
{
    class Program
    {
        private static NhanVien _currentUser;
        private static AuthService _authService;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _authService = new AuthService();
            
            KhoiDongUngDung();
        }

        static void KhoiDongUngDung()
        {
            while (true)
            {
                if (_currentUser == null)
                {
                    HienThiManHinhDangNhap();
                }
                else
                {
                    HienThiMenuChinh();
                }
            }
        }

        static void HienThiManHinhDangNhap()
        {
            Console.Clear();
            Console.WriteLine("=== ĐĂNG NHẬP HỆ THỐNG SIÊU THỊ ===");
            Console.Write("Tên đăng nhập: ");
            string username = Console.ReadLine();
            Console.Write("Mật khẩu: ");
            string password = Console.ReadLine();

            _currentUser = _authService.DangNhap(username, password);

            if (_currentUser != null)
            {
                Console.WriteLine($"\n✅ Đăng nhập thành công! Chào mừng {_currentUser.HoTen}");
                Console.WriteLine($"Vai trò: {_currentUser.TenVaiTro}");
                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n❌ Sai tên đăng nhập hoặc mật khẩu!");
                Console.WriteLine("Nhấn phím bất kỳ để thử lại...");
                Console.ReadKey();
            }
        }

        static void HienThiMenuChinh()
        {
            Console.Clear();
            Console.WriteLine($"=== HỆ THỐNG QUẢN LÝ SIÊU THỊ ===");
            Console.WriteLine($"Xin chào: {_currentUser.HoTen} ({_currentUser.TenVaiTro})");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Quản lý Sản phẩm");
            Console.WriteLine("2. Quản lý Kho");
            Console.WriteLine("3. Bán hàng (POS)");
            Console.WriteLine("4. Quản lý Khuyến mãi");
            Console.WriteLine("5. Đăng xuất");
            Console.WriteLine("==================================");
            Console.Write("Chọn chức năng: ");

            string choice = Console.ReadLine();
            var spService = new SanPhamService();

            switch (choice)
            {
                case "1":
                    MenuQuanLySanPham(spService);
                    break;
                case "2":
                    // Menu quản lý kho
                    break;
                case "3":
                    // Menu bán hàng
                    break;
                case "4":
                    // Menu khuyến mãi
                    break;
                case "5":
                    _currentUser = null;
                    Console.WriteLine("Đã đăng xuất!");
                    System.Threading.Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    System.Threading.Thread.Sleep(1000);
                    break;
            }
        }

        static void MenuQuanLySanPham(SanPhamService spService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== QUẢN LÝ SẢN PHẨM ===");
                Console.WriteLine("1. Thêm sản phẩm mới");
                Console.WriteLine("2. Xem danh sách sản phẩm");
                Console.WriteLine("3. Tìm kiếm sản phẩm");
                Console.WriteLine("4. Quay lại");
                Console.Write("Chọn: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        spService.ThemSanPhamMoi();
                        Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case "2":
                        spService.HienThiDanhSachSanPham();
                        Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case "3":
                        // Tìm kiếm sản phẩm
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}