using Biblioteca.Demostraciones;

namespace Biblioteca.UI;

public sealed class MenuPrincipal
{
    public void Ejecutar()
    {
        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("=== SISTEMA DE BIBLIOTECA — EV07 ===");
            Console.WriteLine("1. Ver objetos Libro");
            Console.WriteLine("2. Ver objetos Usuario");
            Console.WriteLine("3. Ver objeto Préstamo y validar métodos");
            Console.WriteLine("0. Salir");

            opcion = EntradaConsola.LeerOpcion("Selecciona una opción (0-3): ", 0, 3);

            switch (opcion)
            {
                case 1:
                    new MenuLibros(new ObjetosPrueba()).Mostrar();
                    break;
                case 2:
                    new MenuUsuarios(new ObjetosPrueba()).Mostrar();
                    break;
                case 3:
                    new MenuPrestamos(new ObjetosPrueba()).Mostrar();
                    break;
                case 0:
                    Console.WriteLine("Demostración finalizada.");
                    break;
            }
        }
        while (opcion != 0);
    }
}
