// See https://aka.ms/new-console-template for more information
using rabbitmqClient;

Console.WriteLine("Hello, World!");
Client cli= new Client();
cli.Start();
Console.WriteLine("Bye");
