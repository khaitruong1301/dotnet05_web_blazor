
public class NumberService
{
    public int Number{get;set;} = 10;
    public event Action OnChange;



    public void Increment()
    {
        Number++;
        //Kêu giao diện blazor cập nhật lại
        setStateHasChanged();
    }
    public void Decrement()
    {
        Number--;
        //Kêu giao diện blazor cập nhật lại
        setStateHasChanged();
    }

    public void setStateHasChanged()
    {
        //Kêu giao diện blazor cập nhật lại
        OnChange.Invoke();
    }



}