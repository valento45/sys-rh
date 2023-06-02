using RH.Auva.Application.Configurations.DependenciasInjection;


var builder = WebApplication.CreateBuilder(args);


///Adicionando inje��es de depend�ncia
builder.Services.AddInjecaoDependencias(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
