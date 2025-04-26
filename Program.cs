using MongoDbCrudDemo.Controllers;
using MongoDbCrudDemo.Services;

var mongoService = new MongoDbService();
var userOperations = new UserOperations(mongoService);

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("\n==============================");
    Console.WriteLine("       MENU PRINCIPAL");
    Console.WriteLine("==============================");
    Console.WriteLine("[1] Criar novo usuário");
    Console.WriteLine("[2] Listar usuários");
    Console.WriteLine("[3] Atualizar usuário");
    Console.WriteLine("[4] Deletar usuário");
    Console.WriteLine("[5] Ressetar banco de dados");
    Console.WriteLine("[6] Sair");
    Console.Write("Escolha uma opção: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            await userOperations.CreateUserAsync();
            break;
        case "2":
            await userOperations.ListUsersAsync();
            break;
        case "3":
            await userOperations.UpdateUserAsync();
            break;
        case "4":
            await userOperations.DeleteUserAsync();
            break;
        case "5":
            await userOperations.DeleteUserAsync();
            Console.WriteLine("Banco de dados resetado com sucesso! 🔄");
            break;
        case "6":
            running = false;
            Console.WriteLine("Saindo... Até mais! 👋");
            break;
        default:
            Console.WriteLine("Opção inválida! 😅 Tente novamente.");
            break;
    }
}
