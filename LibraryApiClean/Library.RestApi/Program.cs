using Library.Persistence.EF;
using Library.Persistence.EF.Books;
using Library.Persistence.EF.Members;
using Library.Persistence.EF.Shelfs;
using Library.Persistence.EF.Writers;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using Library.Services.Members;
using Library.Services.Members.Contracts;
using Library.Services.Shelfs;
using Library.Services.Shelfs.Contracts;
using Library.Services.Writers;
using Library.Services.Writers.Contracts;
using Tavv.Constract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BookService, BookAppService>();
builder.Services.AddScoped<BookRepozitory,EFBookRepozitory>();
builder.Services.AddScoped<WriterRepozitory,EFWriterRepozitory>();
builder.Services.AddScoped<WriterService,WriterAppService>();
builder.Services.AddScoped<ShelfService,ShelfAppService>();
builder.Services.AddScoped<ShelfRepozotory,EFShelfRepozitory>();
builder.Services.AddScoped<MemberService,MemberAppService>();
builder.Services.AddScoped<MemberRepozitory,EFMemberRepozitory>();
builder.Services.AddScoped<UnitOfWork,EFUnitOfWork>();



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
