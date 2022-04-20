using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using YuChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
//加入SingnalR
builder.Services.AddSignalR();

//DB
builder.Services.AddDbContext<ChatRoomContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChatConnection")));

//DI
builder.Services.AddTransient<IRepository<User>, GenericRepository<User>>();
builder.Services.AddTransient<IRepository<Chat>, GenericRepository<Chat>>();
builder.Services.AddTransient<IRepository<ChatUser>, GenericRepository<ChatUser>>();
builder.Services.AddTransient<IRepository<MsgDatum>, GenericRepository<MsgDatum>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChatUserService, ChatUserService>();
builder.Services.AddTransient<IChatService, ChatService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/myChatHub");

app.Run();
