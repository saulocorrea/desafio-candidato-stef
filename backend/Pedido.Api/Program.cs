using PedidoApi.Core.Services;
using PedidoApi.Core.Services.Interface;
using PedidoApi.Infrastructure.Data;
using PedidoApi.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();

builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy", policy =>
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DesafioDbContext>();
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IPedidoService, PedidoService>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();

var app = builder.Build();

var serviceProvider = builder.Services.BuildServiceProvider();
var produtoService = serviceProvider.GetRequiredService<IProdutoService>();
produtoService.AdicionarProdutos();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
