using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
        (valor, campo) => $"El valor '{valor}' no es válido para {campo}.");
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        campo => $"El campo {campo} debe ser un número.");
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        campo => $"El campo {campo} es obligatorio.");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
        valor => $"El valor '{valor}' no es válido.");
    options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(
        campo => $"El valor ingresado no es válido para {campo}.");
})
    .AddDataAnnotationsLocalization();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();