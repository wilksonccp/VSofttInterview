using MongoDbCrudDemo.Services;
using MongoDbCrudDemo.Models;

namespace MongoDbCrudDemo.Controllers;

public class UserOperations
{
    private readonly MongoDbService _mongoService;

    public UserOperations(MongoDbService mongoService)
    {
        _mongoService = mongoService;
    }

    public async Task CreateUserAsync()
    {
        Console.WriteLine("\n--- Criar Novo Usuário ---");
        Console.Write("Nome: ");
        var name = Console.ReadLine();

        Console.Write("Email: ");
        var email = Console.ReadLine();

        Console.Write("Idade: ");
        var ageString = Console.ReadLine();
        int age = int.TryParse(ageString, out var parsedAge) ? parsedAge : 0;

        Console.Write("Possui Biometria? (s/n): ");
        var hasBiometry = Console.ReadLine()?.Trim().ToLower() == "s";

        var fingerprintHash = hasBiometry
            ? Guid.NewGuid().ToString().Replace("-", "") // Gera um hash fake
            : null;

        var newUser = new User
        {
            Name = name,
            Email = email,
            Age = age,
            HasBiometricData = hasBiometry,
            FingerprintHash = fingerprintHash
        };

        await _mongoService.CreateUserAsync(newUser);
        Console.WriteLine("Usuário criado com sucesso! 🎉");
    }

    public async Task ListUsersAsync()
    {
        Console.WriteLine("\n--- Listando Usuários ---");
        var users = await _mongoService.GetAllUsersAsync();

        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Nome: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Idade: {user.Age}");
            Console.WriteLine($"Biometria: {(user.HasBiometricData ? "Sim" : "Não")}");
            Console.WriteLine($"Fingerprint Hash: {user.FingerprintHash}");
            Console.WriteLine(new string('-', 30));
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public async Task UpdateUserAsync()
    {
        Console.WriteLine("\n--- Atualizar Usuário ---");
        Console.Write("ID do usuário: ");
        var idToUpdate = Console.ReadLine();

        var userToUpdate = await _mongoService.GetUserByIdAsync(idToUpdate);

        if (userToUpdate == null)
        {
            Console.WriteLine("Usuário não encontrado. 😢");
            return;
        }

        Console.Write("Novo Nome: ");
        userToUpdate.Name = Console.ReadLine();

        Console.Write("Nova Idade: ");
        var ageStrig = Console.ReadLine();
        userToUpdate.Age = int.TryParse(ageStrig, out var parsedAge) ? parsedAge : 0;

        Console.Write("Atualizar biometria? (s/n): ");
        var updateBio = Console.ReadLine()?.Trim().ToLower() == "s";

        if (updateBio)
        {
            userToUpdate.HasBiometricData = true;
            userToUpdate.FingerprintHash = Guid.NewGuid().ToString().Replace("-", ""); // Gera um novo hash fake
        }

        await _mongoService.UpdateUserAsync(idToUpdate, userToUpdate);
        Console.WriteLine("Usuário atualizado com sucesso! 🛠️");
    }

    public async Task DeleteUserAsync()
    {
        Console.WriteLine("\n--- Deletar Usuário ---");
        Console.Write("ID do Usuário: ");
        var idToDelete = Console.ReadLine();

        await _mongoService.DeleteUserAsync(idToDelete);
        Console.WriteLine("Usuário deletado com sucesso! 🗑️");
    }














































    /*public async Task UpdateUserAsync()
    {
        Console.WriteLine("\nDigite o ID do usuário que você quer atualizar:");
        var idToUpdate = Console.ReadLine();

        Console.WriteLine("Digite o novo nome:");
        var newName = Console.ReadLine();

        Console.WriteLine("Digite a nova idade:");
        var newAgeString = Console.ReadLine();
        int newAge = int.TryParse(newAgeString, out var parsedAge) ? parsedAge : 0;

        var userToUpdate = await _mongoService.GetUserByIdAsync(idToUpdate);

        if (userToUpdate != null)
        {
            userToUpdate.Name = newName;
            userToUpdate.Age = newAge;

            await _mongoService.UpdateUserAsync(idToUpdate, userToUpdate);
            Console.WriteLine("Usuário atualizado com sucesso! 🛠️");
        }
        else
        {
            Console.WriteLine("Usuário não encontrado. 😢");
        }
    }*/
}
