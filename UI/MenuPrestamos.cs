using Biblioteca.Demostraciones;
using Biblioteca.Models;

namespace Biblioteca.UI;

public sealed class MenuPrestamos
{
    private readonly ObjetosPrueba _objetos;

    public MenuPrestamos(ObjetosPrueba objetos)
    {
        ArgumentNullException.ThrowIfNull(objetos);
        _objetos = objetos;
    }

    public void Mostrar()
    {
        Prestamo prestamo = _objetos.Prestamo;

        Console.WriteLine();
        Console.WriteLine("=== PRÉSTAMO: OBJETO DE PRUEBA ===");
        Console.WriteLine($"Estado inicial: {prestamo.Estado}");
        Console.WriteLine($"FechaDevolucion inicialmente null: {prestamo.FechaDevolucion is null}");
        Console.WriteLine();
        Console.WriteLine($"ResumenCorto(): {prestamo.ResumenCorto()}");
        Console.WriteLine("DetalleCompleto():");
        Console.WriteLine(prestamo.DetalleCompleto());
        Console.WriteLine($"ToString(): {prestamo}");
        Console.WriteLine();

        bool estaVencido = prestamo.EstaVencido();
        Console.WriteLine($"EstaVencido(): {estaVencido}");
        prestamo.ActualizarEstado();
        Console.WriteLine($"Estado después de actualizar: {prestamo.Estado}");
        Console.WriteLine($"DiasTranscurridos(): {prestamo.DiasTranscurridos()}");
        Console.WriteLine(
            $"Disponible el libro prestado: {prestamo.Libro?.Disponible}");
        EntradaConsola.Pausar();
    }
}
