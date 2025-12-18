var builder = WebApplication.CreateBuilder(args);
//build
builder.Services.AddRazorPages(); // DI thư viện razor web
builder.Services.AddServerSideBlazor(); //DI thư viên server side 

var app = builder.Build();
//use: Sử dụng thư viện
app.UseHttpsRedirection(); //https 


app.MapBlazorHub(); //middleware của blazor để làm file chạy đầu tiên
app.MapFallbackToPage("/_Host"); //File chọn chạy đầu tiên

app.UseStaticFiles(); // middleware để sử dụng file tĩnh như css, js, img

// Ví dụ : localhost:5000/products/black-car.jpg

app.Run(); // web được start

