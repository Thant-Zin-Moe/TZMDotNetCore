using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TZMDotNetCore.RestApi.Db;
using TZMDotNetCore.RestApi.Models;
using TZMDotNetCore.Shared;

namespace TZMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly service _adoDotNetService = new service(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        [HttpGet]
        public IActionResult GetBlogs()
        {

            string query = "select * from tbl_blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";
            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var item = _adoDotNetService.Query<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            //SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //Console.WriteLine("Connection opened!");
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BLogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            if (item is null)
            {
                return NotFound("No data found!");
            }

            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            int result = _adoDotNetService.Execute(query,
                        new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                        new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                        new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                    );
            string message = result > 0 ? "Saving successful." : "Saving failed";

            return Ok(message);

            //return StatusCode(500, message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            int result = _adoDotNetService.Execute(query,
                        new AdoDotNetParameter("@BlogId", id),
                        new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                        new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                        new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                    );
            string message = result > 0 ? "Updating successful." : "Updating failed";

            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if (conditions.Length == 0)
            {
                return NotFound("No data to update!");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);

            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {conditions}
 WHERE BlogId = @BlogId";
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating successful." : "Updating failed";

            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Deleting successful." : "Deleting failed";
            return Ok(message);
        }
    }
}
