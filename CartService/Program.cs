using CartService;

var builder = WebApplication.CreateBuilder(args);

// Register the Publisher as a singleton, so it is only instantiated once
builder.Services.AddSingleton<Publisher>();

// Add controller services to the container
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Services.GetRequiredService<Publisher>();

// Enable Swagger middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Use MapControllers() to handle controller routes (like CartController)
app.MapControllers();

app.Run();
