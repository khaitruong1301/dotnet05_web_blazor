namespace web_blazor_server.Models;

public class SanPham
{
    public int Id { get; set; }
    public string Ten { get; set; }
    public decimal Gia { get; set; }
    public string HinhAnh { get; set; }
}

public class GioHang : SanPham
{
    public int SoLuong { get; set; }=0;
}