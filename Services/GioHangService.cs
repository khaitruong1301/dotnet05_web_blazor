using System.Net.Http;
using System.Net.Http.Json;
using web_blazor_server.Models;
// blazor-state-service
public class GioHangService(HttpClient http)
{
    public List<SanPhamGioHang> gioHangState{ get; set; } = new List<SanPhamGioHang>()
    {
        new SanPhamGioHang() { MaSanPham=1, TenSanPham="I phone 17", DonGia=1000, HinhAnh="https://dummyimage.com/300x200/000/fff?text=I+phone+17", SoLuong=2 },
    };


    public void themGioHang(SanPhamItemDTO spClick)
    {
        //Tạo ra sản phẩm giỏ hàng có số lượng
        SanPhamGioHang spGioHang = new SanPhamGioHang();
        spGioHang.MaSanPham = spClick.MaSanPham;
        spGioHang.TenSanPham = spClick.TenSanPham;
        spGioHang.DonGia = spClick.DonGia;
        spGioHang.HinhAnh = spClick.HinhAnh;
        spGioHang.SoLuong = 1;
        //Kiểm tra sản phẩm đã có trong giỏ hàng chưa
        var spTrongGioHang = gioHangState.Find(spGH => spGH.MaSanPham == spClick.MaSanPham);
        if (spTrongGioHang != null)
        {
            spTrongGioHang.SoLuong += 1;
        }else
        {
            gioHangState.Add(spGioHang);
        }
        //Gọi sự kiện thay đổi giao diện
        setStateHasChange();
    }


    public void xoaGioHang(int idClick)
    {
        var spTrongGioHang = gioHangState.Find(spGH => spGH.MaSanPham == idClick);
        if (spTrongGioHang != null)
        {
            gioHangState.Remove(spTrongGioHang);
        }
        //Gọi sự kiện thay đổi giao diện
        setStateHasChange();
    }

    public void changeNumber (int idClick, int soLuongTangGiam)
    {
        var spTrongGioHang = gioHangState.Find(spGH => spGH.MaSanPham == idClick);
        if (spTrongGioHang != null)
        {
            spTrongGioHang.SoLuong += soLuongTangGiam;
            if (spTrongGioHang.SoLuong < 1)
            {
                spTrongGioHang.SoLuong = 1;
            }
        }
        //Gọi sự kiện thay đổi giao diện
        setStateHasChange();
    }
 

    public event Action? OnChange;
    private void  setStateHasChange()
    {
         OnChange?.Invoke();
    }



    // Place your HTTP methods below
}