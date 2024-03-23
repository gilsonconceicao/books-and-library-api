using System.Reflection;
using Books.Application.Book.Commands;
using Books.Application.Book.DTOs;
using Books.Application.Book.Querys;
using Books.Application.Exceptions;
using Books.Application.Library.Commands;
using Books.Application.Library.DTOs;
using Books.Application.Queries.Library;
using Books.Domain.Entities;

// using Books.Domain.Interfaces;

using Books.Infrastructure.Contexts;
// using Books.Infrastructure.Handlers.Book;
// using Books.Infrastructure.Handlers.Library;
// using Books.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace HealthSystem.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionStringDatabase")!;

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<DbContextPostgres>((options) =>
            {
                options.UseLazyLoadingProxies().UseNpgsql(connectionString);
            });

            // book 
            services.AddTransient<IRequestHandler<CreateBookCommand, BookCreateModel>, CreateBookHandler>();
            services.AddTransient<IRequestHandler<UpdateBookCommand, Guid>, UpdateBookHandler>();
            services.AddTransient<IRequestHandler<DeleteBookCommand, Guid>, DeleteBookHandler>();
            services.AddTransient<IRequestHandler<GetBooksListQuery, List<Books.Domain.Entities.Book>>, GetBooksListQueryHandler>();
            services.AddTransient<IRequestHandler<GetBookByIdQuery, Books.Domain.Entities.Book>, GetBookByIdQueryHandler>();

            // library
            services.AddTransient<IRequestHandler<CreateLibraryCommand, LibraryCreateModel>, CreateLibraryHandler>(); 
            services.AddTransient<IRequestHandler<GetLibraryListQuery, List<Library>>, GetLibraryListQueryHandler>(); 

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Books API",
                    Description = "System with resources for books",
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema de saúde V1");
            });

            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (NotFoundException ex)
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(ex.Message);
                }
                catch (BadRequestException ex)
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    string  responseBody = JsonConvert.SerializeObject(ex.CustomObject);
                    await context.Response.WriteAsync(responseBody);
                }
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}