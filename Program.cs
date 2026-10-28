using System;

class Program
{
    static void Main()
    {
        Console.Title = "Biblioteca - Proyecto Sintaxis en C# Parte 1";
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ShowMainMenu();
    }
    // =====================================================================
    // MENÚS Y NAVEGACIÓN
    // =====================================================================

    static void ShowMainMenu()
    {
        bool salir = false;

        while (!salir)
        {
            ShowSectionTitle("SISTEMA DE BIBLIOTECA - MENÚ PRINCIPAL");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.WriteLine("----------------------------------------------");

            int opcion = ReadOption("Seleccione una opción (1-6): ", 1, 6);

            switch (opcion)
            {
                case 1:
                    ShowBooksMenu();
                    break;
                case 2:
                    ShowUsersMenu();
                    break;
                case 3:
                    ShowLoansMenu();
                    break;
                case 4:
                    ShowSearchReportsMenu();
                    break;
                case 5:
                    ShowPersistenceMenu();
                    break;
                case 6:
                    salir = ConfirmExitAndSave();
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Sesión finalizada. ¡Hasta pronto!");
    }

    // Stubs temporales: se reemplazan en cada rama feature de módulo.

    static void ShowBooksMenu()
    {
        ShowActionMessage("LIBROS", "Módulo en construcción", "Se implementará en la rama feature/books-menu.");
    }

    static void ShowUsersMenu()
    {
        ShowActionMessage("USUARIOS", "Módulo en construcción", "Se implementará en la rama feature/users-menu.");
    }

    static void ShowLoansMenu()
    {
        ShowActionMessage("PRÉSTAMOS", "Módulo en construcción", "Se implementará en la rama feature/loans-menu.");
    }

    static void ShowSearchReportsMenu()
    {
        ShowActionMessage("BÚSQUEDAS Y REPORTES", "Módulo en construcción", "Se implementará en la rama feature/search-reports-menu.");
    }

    static void ShowPersistenceMenu()
    {
        ShowActionMessage("DATOS", "Módulo en construcción", "Se implementará en la rama feature/persistence-menu.");
    }

    static bool ConfirmExitAndSave()
    {
        ShowSectionTitle("CONFIRMAR SALIDA");
        bool guardar = ReadYesNo("¿Desea guardar antes de salir?");
        Console.WriteLine();

        if (guardar)
        {
            ShowActionMessage("DATOS > GUARDAR", "Guardar datos", "Pendiente: se implementará en feature/persistence-menu.");
        }

        bool confirmar = ReadYesNo("¿Confirma que desea salir del sistema?");
        Console.WriteLine();

        if (!confirmar)
        {
            Console.WriteLine("Salida cancelada. Regresando al menú principal.");
            Pause();
        }

        return confirmar;
    }

    // =====================================================================
    // UTILIDADES DE ENTRADA Y SALIDA
    // =====================================================================

    static int ReadOption(string message, int min, int max)
    {
        while (true)
        {
            Console.Write(message);
            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out int opcion) && opcion >= min && opcion <= max)
            {
                return opcion;
            }

            Console.WriteLine($"Entrada no válida. Debe ingresar un número entre {min} y {max}.");
        }
    }

    static string ReadText(string message)
    {
        while (true)
        {
            Console.Write(message);
            string texto = (Console.ReadLine() ?? "").Trim();

            if (texto.Length > 0)
            {
                return texto;
            }

            Console.WriteLine("El valor no puede estar vacío. Intente de nuevo.");
        }
    }

    static bool ReadYesNo(string message)
    {
        while (true)
        {
            Console.Write($"{message} (S/N): ");
            string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (respuesta == "S")
            {
                return true;
            }

            if (respuesta == "N")
            {
                return false;
            }

            Console.WriteLine("Respuesta no válida. Escriba S para sí o N para no.");
        }
    }

    static void ShowSectionTitle(string title)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine($"   {title}");
        Console.WriteLine("==============================================");
    }

    static void ShowActionMessage(string title, string action, string detail)
    {
        ShowSectionTitle(title);
        Console.WriteLine($"Acción: {action}");
        Console.WriteLine($"Detalle: {detail}");
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.Write("Presione ENTER para continuar...");
        Console.ReadLine();
    }
}