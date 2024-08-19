using Shared.InterfazUsuario;
using Shared.OpcionesUsuario;
using UserApp.OpcionesUsuario;

namespace UserApp;

public class Program {
    public static void Main(string[] args) {
        Menu menu = new Menu();
        CrearUsuario crearUsuario = new CrearUsuario();
        ListarUsuarios listarUsuarios = new ListarUsuarios();

        bool exit = false;

        while (!exit) {
            menu.Opciones();

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
