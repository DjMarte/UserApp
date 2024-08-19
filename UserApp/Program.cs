using Microsoft.EntityFrameworkCore;

namespace UserApp;

public class Program {
    public static void Main(string[] args) {
        CrearUsuario crearUsuario = new CrearUsuario();
        ListarUsuarios listarUsuarios = new ListarUsuarios();

        bool exit = false;

        while (!exit) {
            Console.WriteLine("Seleccione una opción: \n");
            Console.WriteLine("1. Crear usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Salir\n");
            Console.Write("Opción: ");

            var option = Console.ReadLine();

            switch (option) {
                case "1":
                    crearUsuario.CreateUser();
                    break;
                case "2":
                    listarUsuarios.ListUsers();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
            Console.WriteLine();
        }

    }
}


public class User {
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
}

public class UserContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseInMemoryDatabase("UserDatabase");
    }

    public DbSet<User> Users { get; set; }
}

public class CrearUsuario{
    public void CreateUser() {
        Console.Write("Ingrese el nombre del usuario: ");
        var name = Console.ReadLine();
        Console.Write("Ingrese el email del usuario: ");
        var email = Console.ReadLine();

        using (var context = new UserContext()) {
            var user = new User { Name = name, Email = email };
            context.Users.Add(user);
            context.SaveChanges();
        }

        Console.WriteLine("Usuario creado exitosamente.");
    }
}

public class ListarUsuarios {
    public void ListUsers() {
        using (var context = new UserContext()) {
            var users = context.Users.ToList();
            Console.WriteLine("Usuarios en la base de datos:");
            foreach (var user in users) {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
            }
        }
    }
}
