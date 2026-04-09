var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable serving static files
app.UseStaticFiles();

app.UseAuthorization();

// Redirect root to frontend UI
app.MapGet("/", async context =>
{
    context.Response.Redirect("/ui/Login.html");
});

app.MapControllers();

app.Run();