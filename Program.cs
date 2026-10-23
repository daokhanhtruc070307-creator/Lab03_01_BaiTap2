using System;
using System.Collections.Generic;

namespace QuanLyNhanVien
{
    // 1. Lop co so Nguoi
    public class Nguoi
    {
        protected string hoTen;
        protected DateTime ngaySinh;
        protected string diaChi;

        // Constructors
        public Nguoi()
        {
            hoTen = "";
            ngaySinh = DateTime.Now;
            diaChi = "";
        }

        public Nguoi(string hoTen, DateTime ngaySinh, string diaChi)
        {
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
        }

        // Properties
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        // Property dac biet chi doc: LayTuoi (tinh tuoi dua tren Nam hien tai - Nam sinh)
        public int LayTuoi
        {
            get
            {
                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                if (DateTime.Now.DayOfYear < ngaySinh.DayOfYear)
                {
                    tuoi--;
                }
                return tuoi;
            }
        }

        public override string ToString()
        {
            return $"Ho ten: {hoTen}, Ngay sinh: {ngaySinh.ToString("dd/MM/yyyy")}, Tuoi: {LayTuoi}, Dia chi: {diaChi}";
        }
    }

    // 2. Lop dan xuat NhanVien ke thua tu Nguoi
    public class NhanVien : Nguoi
    {
        private string maNhanVien;
        private double luongCoBan;

        public NhanVien() : base()
        {
            maNhanVien = "";
            luongCoBan = 0;
        }

        public NhanVien(string hoTen, DateTime ngaySinh, string diaChi, string maNhanVien, double luongCoBan)
            : base(hoTen, ngaySinh, diaChi)
        {
            this.maNhanVien = maNhanVien;
            this.luongCoBan = luongCoBan;
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        public double LuongCoBan
        {
            get { return luongCoBan; }
            set { luongCoBan = value; }
        }

        // Phuong thuc tinh luong (co the override cho cac loai nhan vien khac nhau neu sau nay mo rong)
        public virtual double TinhLuong()
        {
            return luongCoBan;
        }

        public override string ToString()
        {
            return $"Nhan vien [Ma NV: {maNhanVien}, Ho ten: {hoTen}, Ngay sinh: {ngaySinh.ToString("dd/MM/yyyy")}, Tuoi: {LayTuoi}, Dia chi: {diaChi}, Luong: {TinhLuong()}]";
        }
    }

    // --- CHUONG TRINH CHINH KIEM THU ---
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== KIEM THU BAI TAP 2: QUAN LY NHAN VIEN ===\n");

            // Khoi tao doi tuong Nhan Vien
            NhanVien nv1 = new NhanVien("Nguyen Van A", new DateTime(2000, 5, 15), "Quan 1, TP.HCM", "NV001", 5000000);
            NhanVien nv2 = new NhanVien("Tran Thi B", new DateTime(2002, 10, 20), "Thu Duc, TP.HCM", "NV002", 6500000);

            // In thong tin ra man hinh
            Console.WriteLine(nv1.ToString());
            Console.WriteLine(nv2.ToString());

            // Thay doi thong tin de kiem tra property va tinh tuoi tu dong
            nv1.HoTen = "Nguyen Van An";
            nv1.LuongCoBan = 5500000;

            Console.WriteLine("\nSau khi cap nhat thong tin Nhan vien 1:");
            Console.WriteLine(nv1.ToString());

            Console.ReadKey();
        }
    }
}