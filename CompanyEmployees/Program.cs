using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
// builder thuộc type WebApplicationBuilder
/* WebApplicationBuilder
    - Thêm cấu hình cho dự án bằng cách sử dụng thuộc tính builder.Configuration
    - Đăng ký services với builder.Services
    - Cấu hình ghi log với thuộc tính builder.Logging
    - Cấu hình IHostBuilder và IWebHostBuilder
*/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
