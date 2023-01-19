using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args).Build();

// using var host = Host.CreateApplicationBuilder(args).Build();

var configuration = host.Services.GetRequiredService<IConfiguration>();

/** Votre code */
var chaine = configuration.GetConnectionString("TestConnection");
var donnee = configuration["testargs"];
var connection = configuration["connnection"];

Console.WriteLine(chaine);
Console.WriteLine(donnee);
/** FIN votre code */

host.Run();

