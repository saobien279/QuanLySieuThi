using System;
using System.Collections.Generic;
using SupermarketManagement.Models;
using SupermarketManagement.Repositories;

namespace SupermarketManagement.Services
{
    public class SanPhamService
    {
        private SanPhamRepository _sanPhamRepo;

        public SanPhamService()
        {
            _sanPhamRepo = new SanPhamRepository();
        }

        public bool ThemSanPhamMoi()
        {
            Console.Clear();
            Console.WriteLine("=== THÊM SẢN PHẨM MỚI ===");
            
            try
            {
                Console.Write("Mã sản phẩm: ");
                string maSP = Console.ReadLine();

                Console.Write("Tên sản phẩm: ");
                string tenSP = Console.ReadLine();

                Console.Write("Đơn vị tính: ");
                string donViTinh = Console.ReadLine();

                Console.Write("Đơn giá: ");
                decimal donGia = decimal.Parse(Console.ReadLine());

                Console.Write("Số lượng tồn: ");
                int slTon = int.Parse(Console.ReadLine());

                Console.Write("Mức tồn tối thiểu: ");
                int mucTonToiThieu = int.Parse(Console.ReadLine());

                Console.Write("Mã danh mục: ");
                int maDM = int.Parse(Console.ReadLine());

                Console.Write("Mã nhà cung cấp: ");
                int maNCC = int.Parse(Console.ReadLine());

                // Tạo đối tượng sản phẩm
                var sanPham = new SanPham(
                    maSP, tenSP, donViTinh, donGia, slTon, 
                    null, mucTonToiThieu, maDM, maNCC
                );

                // Gọi repository để lưu lên cloud
                bool result = _sanPhamRepo.ThemSanPham(sanPham);
                
                if (result)
                {
                    Console.WriteLine("✅ Thêm sản phẩm thành công!");
                    Console.WriteLine($"Mã SP: {maSP} đã được lưu lên database cloud.");
                }
                else
                {
                    Console.WriteLine("❌ Thêm sản phẩm thất bại!");
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public void HienThiDanhSachSanPham()
        {
            var danhSach = _sanPhamRepo.LayTatCaSanPham();
            
            Console.Clear();
            Console.WriteLine("=== DANH SÁCH SẢN PHẨM ===");
            Console.WriteLine($"{"Mã SP",-10} {"Tên SP",-20} {"Đơn giá",-12} {"Tồn kho",-10}");
            Console.WriteLine(new string('=', 60));
            
            foreach (var sp in danhSach)
            {
                Console.WriteLine($"{sp.MaSP,-10} {sp.TenSP,-20} {sp.DonGia,-12} {sp.SLTon,-10}");
            }
        }
    }
}