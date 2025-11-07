using System;
using Npgsql;
using SupermarketManagement.Models;
using SupermarketManagement.Utils;

namespace SupermarketManagement.Services
{
    public class AuthService
    {
        public NhanVien DangNhap(string tenDangNhap, string matKhau)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT nv.*, vt.TenVaiTro 
                             FROM NHANVIEN nv 
                             JOIN VAITRO vt ON nv.MaVaiTro = vt.MaVaiTro 
                             WHERE nv.TenDangNhap = @TenDangNhap AND nv.MatKhau = @MatKhau";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("MatKhau", matKhau);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new NhanVien
                            {
                                MaNV = Convert.ToInt32(reader["MaNV"]),
                                HoTen = reader["HoTen"].ToString(),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MaVaiTro = Convert.ToInt32(reader["MaVaiTro"]),
                                TenVaiTro = reader["TenVaiTro"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}