using Shared.Models;
using UserApp.DAL;

namespace Shared.OpcionesUsuario;

public class CrearUsuario
{
    public void CreateUser() {
        Console.Write("\nIngrese el nombre del usuario: ");
        var name = Console.ReadLine();
        Console.Write("\nIngrese el email del usuaio: ");
        var email = Console.ReadLine();

        using (var context = new UserContext()) { 
            var user = new User { Name = name, Email = email };
            context.Users.Add(user);
            context.SaveChanges();
        }

        Console.WriteLine("\nUsuario creado correctamente!!!");
        Task.Delay(2000).Wait();
        Console.Clear();

    }
}
