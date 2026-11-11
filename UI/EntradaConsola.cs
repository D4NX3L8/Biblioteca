namespace Biblioteca.UI;

internal static class EntradaConsola
{
    public static int LeerOpcion(string mensaje, int minimo, int maximo)
    {
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(entrada, out int opcion) &&
                opcion >= minimo &&
                opcion <= maximo)
            {
                return opcion;
            }

            Console.WriteLine($"Opción inválida. Escribe un número entre {minimo} y {maximo}.");
        }
    }

    public static void Pausar()
    {
        Console.WriteLine();
        Console.Write("Presiona ENTER para volver al menú...");
        Console.ReadLine();
    }
}
