using Biblioteca.Demostraciones;
using Biblioteca.Models;

namespace Biblioteca.UI;

public sealed class MenuUsuarios
{
    private readonly ObjetosPrueba _objetos;

    public MenuUsuarios(ObjetosPrueba objetos)
    {
        ArgumentNullException.ThrowIfNull(objetos);
        _objetos = objetos;
    }

    public void Mostrar()
    {
        Console.WriteLine();
        Console.WriteLine("=== USUARIOS: OBJETOS DE PRUEBA ===");

        foreach (Usuario usuario in _objetos.Usuarios)
        {
            Console.WriteLine();
            Console.WriteLine($"ResumenCorto(): {usuario.ResumenCorto()}");
            Console.WriteLine("DetalleCompleto():");
            Console.WriteLine(usuario.DetalleCompleto());
            Console.WriteLine($"ToString(): {usuario}");
            Console.WriteLine($"Validación Activo: {usuario.Activo}");
        }

        EntradaConsola.Pausar();
    }
}
