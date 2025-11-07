using System;
using System.Collections.Generic;
using Npgsql;
using SupermarketManagement.Models;
using SupermarketManagement.Utils;

namespace SupermarketManagement.Repositories
{
    public class SanPhamRepository
    {
        public bool ThemSanPham(SanPham sanPham)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO SANPHAM 
                                (MaSP, TenSP, DonViTinh, DonGia, SLTon, HSD, MucTonToiThieu, MaDM, MaNCC) 
                                VALUES (@MaSP, @TenSP, @DonViTinh, @DonGia, @SLTon, @HSD, @MucTonToiThieu, @MaDM, @MaNCC)";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("MaSP", sanPham.MaSP);
                        cmd.Parameters.AddWithValue("TenSP", sanPham.TenSP);
                        cmd.Parameters.AddWithValue("DonViTinh", sanPham.DonViTinh ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("DonGia", sanPham.DonGia);
                        cmd.Parameters.AddWithValue("SLTon", sanPham.SLTon);
                        cmd.Parameters.AddWithValue("HSD", sanPham.HSD ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("MucTonToiThieu", sanPham.MucTonToiThieu);
                        cmd.Parameters.AddWithValue("MaDM", sanPham.MaDM);
                        cmd.Parameters.AddWithValue("MaNCC", sanPham.MaNCC);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");
                    return false;
                }
            }
        }

        public List<SanPham> LayTatCaSanPham()
        {
            var danhSach = new List<SanPham>();
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM SANPHAM ORDER BY MaSP";
                
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(new SanPham
                        {
                            MaSP = reader["MaSP"].ToString(),
                            TenSP = reader["TenSP"].ToString(),
                            DonViTinh = reader["DonViTinh"]?.ToString(),
                            DonGia = Convert.ToDecimal(reader["DonGia"]),
                            SLTon = Convert.ToInt32(reader["SLTon"]),
                            HSD = reader["HSD"] as DateTime?,
                            MucTonToiThieu = Convert.ToInt32(reader["MucTonToiThieu"]),
                            MaDM = reader["MaDM"] as int? ?? 0,
                            MaNCC = reader["MaNCC"] as int? ?? 0
                        });
                    }
                }
            }
            return danhSach;
        }
    }
}