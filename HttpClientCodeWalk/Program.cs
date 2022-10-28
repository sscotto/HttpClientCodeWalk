using HttpClientCodeWalk.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient("catFactClient", client =>
{
    client.BaseAddress = new Uri("https://catfact.ninja");
});

builder.Services.AddHttpClient<ICatFactHttpClientService, CatFactHttpClientService>(client =>
{
    client.BaseAddress = new Uri("https://catfact.ninja");
});

builder.Services.AddScoped<ISlowService, SlowService>();
builder.Services.AddScoped<FireAndForgetHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
