using System;

namespace SupermarketManagement.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public decimal DonGia { get; set; }
        public int SLTon { get; set; }
        public DateTime? HSD { get; set; }
        public int MucTonToiThieu { get; set; }
        public int MaDM { get; set; }
        public int MaNCC { get; set; }

        public SanPham() { }

        public SanPham(string maSP, string tenSP, string donViTinh, decimal donGia, 
                      int slTon, DateTime? hsd, int mucTonToiThieu, int maDM, int maNCC)
        {
            MaSP = maSP;
            TenSP = tenSP;
            DonViTinh = donViTinh;
            DonGia = donGia;
            SLTon = slTon;
            HSD = hsd;
            MucTonToiThieu = mucTonToiThieu;
            MaDM = maDM;
            MaNCC = maNCC;
        }
    }
}