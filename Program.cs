var builder = WebApplication.CreateBuilder(args);
//build
builder.Services.AddRazorPages(); // DI thư viện razor web
builder.Services.AddServerSideBlazor(); //DI thư viên server side 

//DI service http : dùng để gọi từ server blazor đến server khác để lấy dữ liệu
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("apiStore",client=>
{
    client.BaseAddress = new Uri("https://apistore.cybersoft.edu.vn");
    client.Timeout = TimeSpan.FromSeconds(30); //30s 
    //Thiết lập header chung cho tất cả các request gửi đi là application/json dành cho Post Put
    client.DefaultRequestHeaders.Add("Accept","application/json");
});





//DI service number
builder.Services.AddScoped<NumberService>();
//Addtransient: mỗi lần gọi đến service thì tạo mới
//Addscoped: trong 1 phiên làm việc (1 lần load trang) thì dùng chung 1 service, nếu load lại trang thì tạo mới
//Addsingleton: suốt vòng đời ứng dụng chỉ tạo 1 service duy nhất (logger, config)

// Transient: dùng xong bỏ
// Scoped: theo request (1 lần load trang) thì dùng chung 1 service, nếu load lại trang thì tạo mới
// Singleton: dùng chung toàn hệ thống (Dùng cho các nghiệp vụ như logging, caching, configuration)

//DI service giỏ hàng
builder.Services.AddScoped<GioHangService>();

//DI DTO
builder.Services.AddScoped<BurgerDTO>();

//DI Service
builder.Services.AddScoped<BurgerService>();


builder.Services.AddScoped<ProductManagementService>();
builder.Services.AddScoped<ProductDTO>();
builder.Services.AddScoped<List<ProductDTO>>();


//DI signalR
builder.Services.AddSignalR();



var app = builder.Build();
//use: Sử dụng thư viện
app.UseHttpsRedirection(); //https 


app.MapBlazorHub(); //middleware của blazor để làm file chạy đầu tiên


app.MapHub<RoomHub>("/roomHub"); //middleware của signalR để làm file chạy đầu tiên



app.MapFallbackToPage("/_Host"); //File chọn chạy đầu tiên

app.UseStaticFiles(); // middleware để sử dụng file tĩnh như css, js, img

// Ví dụ : localhost:5000/products/black-car.jpg

app.Run(); // web được start

