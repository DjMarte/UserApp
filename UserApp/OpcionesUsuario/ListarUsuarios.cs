using UserApp.DAL;

namespace UserApp.OpcionesUsuario;

public class ListarUsuarios
{
    public void ListUsers() {
        using (var context = new UserContext()) {
            var users = context.Users.ToList();
            Console.WriteLine("Usuarios en la base de datos: \n");
            foreach (var user in users) {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
            }
        }
    }
}
