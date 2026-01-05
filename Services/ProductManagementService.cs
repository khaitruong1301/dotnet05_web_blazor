
public class ProductManagementService
{
    public List<ProductDTO>? _lstProduct;

    public HttpClient _httpClient;

    public ProductManagementService(List<ProductDTO> lstProduct,IHttpClientFactory httpClientFactory)
    {
        _lstProduct = lstProduct;
        _httpClient = httpClientFactory.CreateClient("apiStore");
    }
    public async Task GetAllProduct()
    {
        ResponseData<List<ProductDTO>>? res = await _httpClient.GetFromJsonAsync<ResponseData<List<ProductDTO>>>(@$"/api/Product");
        if(res!=null && res.content!=null)
        {
            //Lấy dữ từ api trả về gán vào state
            _lstProduct = res.content.Skip(0).Take(5).ToList();
            //Gọi render lại giao diện
            setStateHasChanged();
        }
    }


    public event Action OnChange;

    public void setStateHasChanged()
    {
        OnChange.Invoke();
    }

    
}