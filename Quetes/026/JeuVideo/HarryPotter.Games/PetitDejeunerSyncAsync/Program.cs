using PetitDejeunerSyncAsync;

var humain = new Humain();

Task<PetitDejeuner> preparer = humain.PreparerPetitDejeunerAsync();
Console.WriteLine("Coucou, je regarde la télé");

await preparer;

Console.ReadLine();
