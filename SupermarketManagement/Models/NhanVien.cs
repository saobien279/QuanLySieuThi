namespace SupermarketManagement.Models
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }

        public enum VaiTro
        {
            Admin = 1,
            QuanLyKho = 2,
            ThuNgan = 3
        }
    }
}