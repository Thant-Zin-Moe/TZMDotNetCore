// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using TZMDotNetCore.ConsoleApp.AdoDotNetExamples;
using TZMDotNetCore.ConsoleApp.DapperExamples;
using TZMDotNetCore.ConsoleApp.EFCoreExamples;
using TZMDotNetCore.ConsoleApp.Services;

Console.WriteLine("Hello, World!");


// SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
// stringBuilder.DataSource = "LENOVO-V14\\SQLEXPRESS";
// stringBuilder.InitialCatalog = "TZMDotNetCore";
// stringBuilder.UserID = "sa";
// stringBuilder.Password = "sasa@123";
// SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
// connection.Open();
// Console.WriteLine("Connection opened!");
// string query = "select * from tbl_blog";
// SqlCommand cmd = new SqlCommand(query, connection);
// SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
// DataTable dt = new DataTable();
// sqlDataAdapter.Fill(dt);

// connection.Close();
// Console.WriteLine("Connection closed!");

// foreach (DataRow dr in dt.Rows)
// {
//     Console.WriteLine("Blog Id => " + dr["BlogId"]);
//     Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//     Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
//     Console.WriteLine("Blog Content => " + dr["BlogContent"]);
//     Console.WriteLine("-------------------------");
// }

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(1002, "test title", "test author", "test content");
//adoDotNetExample.Delete(1002);
//adoDotNetExample.Edit(1002);
//adoDotNetExample.Edit(1);
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();
//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();

var connectionString = ConnectionStrings.sqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

//var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
//adoDotNetExample.Read();

var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
dapperExample.Run();



Console.ReadKey();