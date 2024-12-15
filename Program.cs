using Microsoft.EntityFrameworkCore;
using Pedidos.Context;

var builder = WebApplication.CreateBuilder(args);


// Configura a conexão com o banco de dados
builder.Services.AddDbContext<OrganizadorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// Adiciona os controladores à aplicação
builder.Services.AddControllers();

// Adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o Swagger na aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adiciona os controladores e mapeia os endpoints
app.MapControllers(); // Isso garante que os controladores sejam mapeados corretamente para os endpoints

app.UseAuthorization();

app.Run();
