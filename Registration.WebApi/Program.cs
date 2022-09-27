using Microsoft.EntityFrameworkCore;
using Registration.Data.Context;
using Registration.Data.Contracts.Account;
using Registration.Data.Repositories.Account;
using Registration.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("POSTGRESQLCONNSTR_PostgreSQL")
        ));

builder.Services.AddMvcCore().AddAuthorization().AddDataAnnotations();
builder.Services.AddMemoryCache();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<MapperProfile>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

app.UseDeveloperExceptionPage();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
