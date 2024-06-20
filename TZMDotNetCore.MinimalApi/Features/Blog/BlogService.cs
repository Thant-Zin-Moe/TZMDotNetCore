using Microsoft.EntityFrameworkCore;
using TZMDotNetCore.MinimalApi.Db;
using TZMDotNetCore.MinimalApi.Models;

namespace TZMDotNetCore.MinimalApi.Features.Blog
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder MapBlogs(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/blog", async (AppDbContext db) =>
            {

                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapPost("/api/blog/", async (AppDbContext db, BlogModel blog) =>
            {
                await db.Blogs.AddAsync(blog);
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Saving successful." : "Saving failed.";
                return Results.Ok(message);
            });

            app.MapPut("/api/blog/{id}", async (int id, AppDbContext db, BlogModel blog) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found!");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Updating successful." : "Updating failed.";
                return Results.Ok(message);
            });

            app.MapDelete("/api/blog/{id}", async (int id, AppDbContext db) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found!");
                }

                db.Blogs.Remove(item);
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Deleting successful." : "Deleting failed.";
                return Results.Ok(message);
            });

            return app;
        }
    }
}
