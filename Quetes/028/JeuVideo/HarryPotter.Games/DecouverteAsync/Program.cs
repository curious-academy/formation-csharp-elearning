
Console.WriteLine("0");
//Task execution = Execute(10);

await Execute(10);

Console.WriteLine("3");

//await execution;

Console.ReadLine();

async Task Execute(int duration = 10)
{
    Console.WriteLine("1");
    await Task.Delay(TimeSpan.FromSeconds(duration));
    Console.WriteLine("2");
}
