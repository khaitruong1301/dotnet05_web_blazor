
public class SanPhamItemDTO
{   
    public int MaSanPham { get; set; }
    public string TenSanPham { get; set; } = "";
    public double DonGia { get; set; } = 0;
    public string HinhAnh { get; set; } = "";

}

public class DataSanPham
{
     public static List<SanPhamItemDTO> DanhSachSanPhamDemo = new List<SanPhamItemDTO>()
    {
        new SanPhamItemDTO(){ MaSanPham=1, TenSanPham="I phone 17", DonGia=1000, HinhAnh="https://dummyimage.com/300x200/000/fff?text=I+phone+17" },
        new SanPhamItemDTO(){ MaSanPham=2, TenSanPham="Samsung galaxy s25", DonGia=2000, HinhAnh="https://dummyimage.com/300x200/000/fff?text=Samsung+galaxy+s25" },
        new SanPhamItemDTO(){ MaSanPham=3, TenSanPham="Xiaomi mi 17T", DonGia=3000, HinhAnh="https://dummyimage.com/300x200/000/fff?text=Xiaomi+mi+17T" },
    };

}