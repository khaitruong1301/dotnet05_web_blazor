
using web_blazor_server.Models;
namespace web_blazor_server.Models.DTO;
// ItemCartVM 
// ItemCartViewModel 
// ItemCartDTO
// Các object dev tạo ra để xử lý về mặt api hoặc frontend
public class ItemCartDTO:Product
{
    public int Quantity {get;set;}
    
}

public class ItemQuantity
{
    public int Id {get;set;}
    public int Quantity {get;set;}

}