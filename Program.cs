using MongoDbCrudDemo.Models;
using MongoDbCrudDemo.Services;

var mongoService = new MongoDbService();

//Criar um novo usuário
var newuser = new User
{
    Name = "Wilkson",
    Email = "wilkson.cc@gmail.com",
    Age = 42,
    HasBiometricData = true,
    FingerprintHash = "hash123", //Simula um has de biometria
};

await mongoService.CreateUserAsync(newuser);
Console.WriteLine("Usuário criado com sucesso!");

//Ler todos os usuários
var users = await mongoService.GetAllUsersAsync();
Console.WriteLine("\nLista de usuários:");
foreach (var user in users)
{
    Console.WriteLine($"Id: {user.Id}, Nome: {user.Name}, Email: {user.Email}, Idade: {user.Age}, Tem dados biométricos: {user.HasBiometricData}");
}