using ChaveAutenticidadeSelos.Services;
using Polly;
using Polly.Contrib.WaitAndRetry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient("ConsultaAutenticidadeTjApi", client =>
    { 
        client.BaseAddress = new Uri("https://www.tjrs.jus.br/servicos/selo/consulta_selo_chave.php");
    })
    .AddTransientHttpErrorPolicy(policyBuider =>
        policyBuider.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1),5)));        

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
