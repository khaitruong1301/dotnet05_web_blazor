var builder = WebApplication.CreateBuilder(args);
//build
builder.Services.AddRazorPages(); // DI thư viện razor web
builder.Services.AddServerSideBlazor(); //DI thư viên server side 

var app = builder.Build();
//use: Sử dụng thư viện
app.UseHttpsRedirection(); //https 


app.MapBlazorHub(); //middleware của blazor để làm file chạy đầu tiên
app.MapFallbackToPage("/_Host"); //File chọn chạy đầu tiên

app.UseStaticFiles();

app.Run(); // web được start

