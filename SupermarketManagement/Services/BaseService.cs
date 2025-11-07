using System;
using Npgsql;
using SupermarketManagement.Models;
using SupermarketManagement.Utils;

namespace SupermarketManagement.Services
{
    public abstract class BaseService
    {
        protected NhanVien _currentUser;

        public BaseService(NhanVien currentUser)
        {
            _currentUser = currentUser;
        }

        protected bool KiemTraQuyen(int vaiTroYeuCau)
        {
            return _currentUser.MaVaiTro == vaiTroYeuCau;
        }

        protected void GhiLog(string hanhDong, string tenBang, string maDoiTuong)
        {
            // Ghi log vào database
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO LOG_HETHONG (ThoiGian, MaNV, HanhDong, TenBang, MaDoiTuong) 
                             VALUES (NOW(), @MaNV, @HanhDong, @TenBang, @MaDoiTuong)";
                
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("MaNV", _currentUser.MaNV);
                    cmd.Parameters.AddWithValue("HanhDong", hanhDong);
                    cmd.Parameters.AddWithValue("TenBang", tenBang);
                    cmd.Parameters.AddWithValue("MaDoiTuong", maDoiTuong);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}