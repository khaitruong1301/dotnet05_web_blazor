

using web_blazor_server.Pages.DemoStateManagement.BT_Burger;
//.net 7.0 trở lên
// public class BurgerService(BurgerDTO _burgerDTO)
// {

// }

//Cách viết cũ thông dụng hơn
public class BurgerService
{
    public readonly BurgerDTO _burgerDTO;

    public BurgerService(BurgerDTO burgerDTO)
    {
        _burgerDTO = burgerDTO;
        _burgerDTO.ListTopping = new List<ToppingDTO>()
        {
            new ToppingDTO(){Id=ETopping.salad, Quantity=2, Price=10},
            new ToppingDTO(){Id=ETopping.cheese, Quantity=3, Price=20},
            new ToppingDTO(){Id=ETopping.beef, Quantity=2, Price=30},
        };

    }

    public void ChangeTopping(ETopping idTopping, int Quantity)
    {
        ToppingDTO? topping = _burgerDTO.ListTopping.Find(item => item.Id == idTopping);
        if (topping != null)
        {
            if (topping.Quantity + Quantity < 0)
            {
                topping.Quantity = 0;
            }
            else
            {
                topping.Quantity += Quantity;
            }
        }
        //Cập nhật lại giao diện
        setStateHasChanged();
    }



    public event Action OnChange;

    public void setStateHasChanged()
    {
        OnChange?.Invoke();
    }

}