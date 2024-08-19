using Shared.Models;
using UserApp.DAL;

namespace Shared.OpcionesUsuario;

public class CrearUsuario
{
    public static void CreateUser() {
        Console.Write("Ingrese el nombre del usuario: ");
        var name = Console.ReadLine();
        Console.Write("Ingrese el email del usuaio: ");
        var email = Console.ReadLine();

        using (var context = new UserContext()) { 
            var user = new User { Name = name, Email = email };
            context.Users.Add(user);
            context.SaveChanges();
        }

        Console.WriteLine("Usuario creado correctamente!!!");
    }
}
