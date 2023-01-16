// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;


var json = JsonConvert.SerializeObject(new
{
    Title = "Harry",
    Power = new
    {
        Libelle = "Wizard"
    }
});

System.IO.File.WriteAllText(@"F:\Tmps\Tests\HarryPotter\stat.json", json);

Console.WriteLine(json);

