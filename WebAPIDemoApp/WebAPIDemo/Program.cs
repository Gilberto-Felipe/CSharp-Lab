var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Name", (string firstName, string lastName) =>
{
    string output = $"{firstName} {lastName}";
    return output;
})
.WithName("GetName")
.WithOpenApi();


app.MapPost("/Person", (PersonModel person) => 
{ 
    return person;
})
.WithName("PostPerson")
.WithOpenApi();


app.MapPost("/Address", (AddressModel address) =>
{
    return address;
})
.WithName("PostAddress")
.WithOpenApi();

app.Run();