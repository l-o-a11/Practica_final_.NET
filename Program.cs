
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Data;
using PracticaFinal.Interfaces;
using PracticaFinal.Repositories;

=======
>>>>>>> 1d3d461e5a031d97463806b2aa9b4037c578fc43
namespace PracticaFinal
{
    public class Program
    {
<<<<<<< HEAD


=======
>>>>>>> 1d3d461e5a031d97463806b2aa9b4037c578fc43
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
<<<<<<< HEAD
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
=======

>>>>>>> 1d3d461e5a031d97463806b2aa9b4037c578fc43
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
<<<<<<< HEAD

    }
}
=======
    }
}
>>>>>>> 1d3d461e5a031d97463806b2aa9b4037c578fc43
