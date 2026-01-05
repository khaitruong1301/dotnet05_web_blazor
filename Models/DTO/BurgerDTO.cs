

public class BurgerDTO
{
    public List<ToppingDTO> ListTopping { get; set; } = new List<ToppingDTO>();
}



public class ToppingDTO
{
    public ETopping Id {get;set;} //Ngầm là name : salad, cheese, beef
    public int Quantity {get;set;} //Số lượng
    public double Price {get;set;} //Đơn giá
}

public enum ETopping
{
    salad,
    cheese,
    beef
}