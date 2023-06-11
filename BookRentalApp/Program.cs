using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Sinks.PostgreSQL;
using NpgsqlTypes;
using Npgsql.EntityFrameworkCore.PostgreSQL.Internal;

namespace BookRentalApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });
    }

    /*public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
            
            var connectionString = "User ID=postgres;Password=admin3307;Server=localhost;Port=5432;Database=xxx;Integrated Security=true;Pooling=true;";
            var tableName = "Logs";

            IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
            {
                {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
                {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
                {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
                {"raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
                {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
                {"properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
                {"props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
                {"machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
            };

            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove("Properties");



            var sinkOpts = new NpgsqlSinkOptions
            {
                TableName = "Logs",
                AutoCreateSqlTable = true,
            };



            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.PostgreSQL(connectionString, tableName)
                .CreateLogger();

            //try
            //{
            //    Log.Information("Application Starting");
            //    CreateHostBuilder(args).Build().Run();
            //}
            //catch (Exception ex)
            //{

            //    Log.Fatal(ex, "The applicationfailed to start");
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}

        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
                {
                    var connectionString = hostingContext.Configuration.GetConnectionString("Default");

                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.MSSqlServer(connectionString, new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true })
                        .CreateLogger();


                    //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //logging.AddConsole();
                    //logging.AddDebug();
                    //logging.AddSerilog(dispose: true);
            }).ConfigureWebHostDefaults(webBuilder =>
                {
                     webBuilder.UseStartup<Startup>();
                }).UseDefaultServiceProvider(options => options.ValidateScopes = false);
    }*/
}
