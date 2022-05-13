using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Bugtracker.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BugDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "BugTrackerAPI", Description = "Keep track of your tasks", Version = "v1" });
  });
var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
  {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "BugTrackerAPI V1");
  });


//routes
app.MapGet("/", () => "Hello World!");
app.MapGet("/bugs", async(BugDb db)=>await db.Bugs.ToListAsync());
app.MapPost("/bug",async (BugDb db, Bug bug) =>{
    await db.Bugs.AddAsync(bug);
    await db.SaveChangesAsync();
    return Results.Created($"/bug/{bug.Id}",bug);
});
app.MapPut("/bug/{id}", async (BugDb db, Bug updateBug,int id )=>{
  var bug = await db.Bugs.FindAsync(id);
  if(bug == null) return Results.NotFound();
  bug.Title = updateBug.Title;
  bug.Description = updateBug.Description;
  await db.SaveChangesAsync();
  return Results.NoContent();
});
app.MapDelete("/bug/{id}", async (BugDb db, int id)=>{
   var bug = await db.Bugs.FindAsync(id);
   if(bug == null) return Results.NotFound();
   db.Bugs.Remove(bug);
   await db.SaveChangesAsync();
   return Results.Ok();
});

app.Run();
