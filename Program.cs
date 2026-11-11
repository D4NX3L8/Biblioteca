using System.Text;
using Biblioteca.UI;

namespace Biblioteca;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var menu = new MenuPrincipal();
        menu.Ejecutar();
    }
}
