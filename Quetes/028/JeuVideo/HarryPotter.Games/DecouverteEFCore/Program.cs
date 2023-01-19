using DecouverteEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder(args)
           .ConfigureServices((context, services) =>
           {
               services.AddDbContext<DefaultDbContext>(dbContextOption =>
               {
                   dbContextOption.UseSqlServer(context.Configuration.GetConnectionString("Test"));
               });
           })
           .Build();

//var builder = new DbContextOptionsBuilder<DefaultDbContext>();

//var configuration = new ConfigurationBuilder()
//                        .AddJsonFile("appsettings.json")
//                        .Build();

//builder.UseSqlServer(configuration.GetConnectionString("Test"));

//using var context = new DefaultDbContext(builder.Options);

var context = host.Services.GetService<DefaultDbContext>();

// Aucune requête en base
var query = from enemy in context.Ennemies.Include(item => item.Arme)
            where enemy.Surname.StartsWith("V")
            select enemy;

// Requête en base (donc ouverture et fermeture de la connexion à la base)
var list = query
           .ToList();

foreach (var item in list)
{
    Console.WriteLine(item.Surname);
    Console.WriteLine(item.Arme.Libelle);
}

var single = list.First();


var armes = context.Weapons.ToList();


var arme = new Arme()
{
    Dommages = 50,
    Libelle = "Baguette 3"
};
context.Weapons.Add(arme);

context.SavedChanges += Context_SavedChanges;

void Context_SavedChanges(object? sender, SavedChangesEventArgs e)
{
    Console.WriteLine("Données sauvées");
}

context.SaveChanges();


foreach (var item in armes)
{
    Console.WriteLine(item.Libelle);
}

host.Start();