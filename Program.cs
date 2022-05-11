using Microsoft.OpenApi.Models;
using Bugtracker.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
  });
var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
  {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
  });


//routes
app.MapGet("/", () => "Hello World!");

app.MapGet("/bug/{id}",(int id) => BugDB.GetBug(id));
app.MapGet("/bugs",()=>BugDB.GetBugs());
app.MapPost("/bugs",(Bug bug) => BugDB.CreateBug(bug));
app.MapPut("/bugs",(Bug bug) => BugDB.UpdateBug(bug));
app.MapDelete("/bugs/{id}",(int id)=> BugDB.RemoveBug(id));


app.Run();
