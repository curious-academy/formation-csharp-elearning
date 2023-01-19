// See https://aka.ms/new-console-template for more information
using HarryPotter.Games.Core;
using HarryPotter.Games.Core.Menu;

Console.WriteLine("Hello, World!");

var menu = new Menu();
menu.Add(1, "Test 1");
menu.Add(2, "Test 2");

menu.Afficher(Console.WriteLine);