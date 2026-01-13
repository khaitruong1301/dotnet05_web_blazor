
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
            _lstProduct = res.content.ToList();
            //Gọi render lại giao diện
            setStateHasChanged();
        }
    }

    public async void deleteProduct(int id)
    {

        var response = await _httpClient.DeleteAsync($"/api/Product/{id}");
        if(response.IsSuccessStatusCode)
        {
            //Xóa thành công gọi load lại danh sách
            await GetAllProduct();
        }
    }

    public async Task GetAllProductByKeyword(string keyword)
    {
        
        ResponseData<List<ProductDTO>>? res = await _httpClient.GetFromJsonAsync<ResponseData<List<ProductDTO>>>(@$"/api/Product?keyword={keyword}");
        if(res!=null && res.content!=null)
        {
            //Lấy dữ từ api trả về gán vào state
            _lstProduct = res.content.ToList();
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