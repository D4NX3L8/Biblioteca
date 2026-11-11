using Biblioteca.Demostraciones;
using Biblioteca.Models;

namespace Biblioteca.UI;

public sealed class MenuLibros
{
    private readonly ObjetosPrueba _objetos;

    public MenuLibros(ObjetosPrueba objetos)
    {
        ArgumentNullException.ThrowIfNull(objetos);
        _objetos = objetos;
    }

    public void Mostrar()
    {
        Console.WriteLine();
        Console.WriteLine("=== LIBROS: OBJETOS DE PRUEBA ===");

        foreach (Libro libro in _objetos.Libros)
        {
            Console.WriteLine();
            Console.WriteLine($"ResumenCorto(): {libro.ResumenCorto()}");
            Console.WriteLine("DetalleCompleto():");
            Console.WriteLine(libro.DetalleCompleto());
            Console.WriteLine($"ToString(): {libro}");
        }

        Console.WriteLine();
        Console.WriteLine("Validación Disponible:");
        Console.WriteLine($"{_objetos.Libros[0].Titulo}: {_objetos.Libros[0].Disponible}");
        Console.WriteLine($"{_objetos.Libros[1].Titulo}: {_objetos.Libros[1].Disponible}");
        EntradaConsola.Pausar();
    }
}
