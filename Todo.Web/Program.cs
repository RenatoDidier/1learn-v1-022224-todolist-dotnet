using Todo.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
var stringConexao = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlConnection(stringConexao);
builder.Services.AddRepositories();
builder.Services.AddHandlers();

// Configuração do CORS para acesso a qualquer tipo de chamada externa.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

// Ativação da configuração do cors acima
app.UseCors();

app.MapControllers();

app.Run();
