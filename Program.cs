using System.Security.Claims;
using System.Text;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
//build
builder.Services.AddRazorPages(); // DI thư viện razor web
builder.Services.AddServerSideBlazor(); //DI thư viên server side 

//DI service http : dùng để gọi từ server blazor đến server khác để lấy dữ liệu
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("apiStore", client =>
{
    client.BaseAddress = new Uri("https://apistore.cybersoft.edu.vn");
    client.Timeout = TimeSpan.FromSeconds(30); //30s 
    //Thiết lập header chung cho tất cả các request gửi đi là application/json dành cho Post Put
    client.DefaultRequestHeaders.Add("Accept", "application/json");
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



//DI JwtAuthService
builder.Services.AddScoped<JwtAuthService>();

//DI localstorage 
builder.Services.AddBlazoredLocalStorage();

//DI đè phương thức xác thực của Blazor
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

//Bật cổng kết nối cho tất cả client ngoài origin có thể kết nối
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient",
        policy =>
        {
            policy
                .WithOrigins("http://127.0.0.1:5500") // origin web của bạn
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});


// Cấu hình accesstoken jwt
var key = builder.Configuration["Jwt:Key"];           // Khóa bí mật để ký token
var issuer = builder.Configuration["Jwt:Issuer"];     // Issuer (bên phát hành token)
var audience = builder.Configuration["Jwt:Audience"]; // Audience (người nhận token)
// 2. Cấu hình Authentication sử dụng JWT Bearer
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {

        ValidateIssuerSigningKey = true, // Xác thực key bí mật của token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateIssuer = true,// Xác thực Issuer 
        ValidIssuer = issuer, // Phải khớp với Issuer trong token
        ValidateAudience = true,    // Xác thực Audience
        ValidAudience = audience, // Phải khớp với Audience trong token
        ValidateLifetime = true, // Xác thực thời gian hết hạn của token
        ClockSkew = TimeSpan.Zero, // Bỏ qua độ trễ thời gian giữa server và client (ngăn lỗi thời gian)
        RoleClaimType = ClaimTypes.Role, // Ánh xạ claim role
        NameClaimType = "UserName",
    };
});
// 3. Cấu hình Authorization (Phân quyền theo Role)
builder.Services.AddAuthorization(options =>
{
    // Chính sách chỉ cho phép Admin truy cập
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    // Chính sách chỉ cho phép User truy cập
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});
// 4. Thêm AuthorizationCore để sử dụng trong Blazor Components (Phần view)
builder.Services.AddAuthorizationCore();





















var app = builder.Build();

app.UseCors("AllowClient"); //sử dụng cors




//use: Sử dụng thư viện
app.UseHttpsRedirection(); //https 
app.UseAuthentication(); //Xác thực
app.UseAuthorization(); //Phân quyền


app.MapBlazorHub(); //middleware của blazor để làm file chạy đầu tiên
app.MapHub<RoomHub>("/roomHub"); //middleware của signalR để làm file chạy đầu tiên





app.MapFallbackToPage("/_Host"); //File chọn chạy đầu tiên

app.UseStaticFiles(); // middleware để sử dụng file tĩnh như css, js, img

// Ví dụ : localhost:5000/products/black-car.jpg

app.Run(); // web được start

