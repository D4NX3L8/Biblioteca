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
        bool volver = false;

        while (!volver)
        {
            ShowSectionTitle("LIBROS");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle (por ID/ISBN)");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("----------------------------------------------");

            int opcion = ReadOption("Seleccione una opción (0-5): ", 0, 5);

            switch (opcion)
            {
                case 1:
                    RegisterBook();
                    break;
                case 2:
                    ListBooksMenu();
                    break;
                case 3:
                    ViewBookDetail();
                    break;
                case 4:
                    UpdateBookMenu();
                    break;
                case 5:
                    DeleteBook();
                    break;
                case 0:
                    volver = true;
                    break;
            }
        }
    }

    static void RegisterBook()
    {
        ShowSectionTitle("LIBROS > REGISTRAR LIBRO");
        string titulo = ReadText("Título del libro: ");
        string autor = ReadText("Autor: ");
        string isbn = ReadText("ISBN: ");
        int anio = ReadOption("Año de publicación (1900-2100): ", 1900, 2100);
        string categoria = ReadText("Categoría: ");

        Console.WriteLine();
        Console.WriteLine("Solicitud de registro recibida correctamente (simulación):");
        Console.WriteLine($"  Título......: {titulo}");
        Console.WriteLine($"  Autor.......: {autor}");
        Console.WriteLine($"  ISBN........: {isbn}");
        Console.WriteLine($"  Año.........: {anio}");
        Console.WriteLine($"  Categoría...: {categoria}");
        Console.WriteLine("  Estado......: Disponible");
        Console.WriteLine("Nota: no se almacena información real en esta versión.");
        Pause();
    }

    static void ListBooksMenu()
    {
        bool volver = false;

        while (!volver)
        {
            ShowSectionTitle("LIBROS > LISTAR LIBROS");
            Console.WriteLine("1. Listar todos");
            Console.WriteLine("2. Listar disponibles");
            Console.WriteLine("3. Listar prestados");
            Console.WriteLine("0. Volver al menú de libros");
            Console.WriteLine("----------------------------------------------");

            int opcion = ReadOption("Seleccione una opción (0-3): ", 0, 3);

            switch (opcion)
            {
                case 1:
                    ListBooksAll();
                    break;
                case 2:
                    ListBooksAvailable();
                    break;
                case 3:
                    ListBooksBorrowed();
                    break;
                case 0:
                    volver = true;
                    break;
            }
        }
    }

    static void ListBooksAll()
    {
        ShowActionMessage(
            "LIBROS > LISTAR TODOS",
            "Listar todos los libros",
            "Se mostraría el listado completo de libros registrados (simulación sin colecciones).");
    }

    static void ListBooksAvailable()
    {
        ShowActionMessage(
            "LIBROS > LISTAR DISPONIBLES",
            "Listar libros disponibles",
            "Se mostrarían únicamente los libros con estado Disponible (simulación).");
    }

    static void ListBooksBorrowed()
    {
        ShowActionMessage(
            "LIBROS > LISTAR PRESTADOS",
            "Listar libros prestados",
            "Se mostrarían únicamente los libros con estado Prestado (simulación).");
    }

    static void ViewBookDetail()
    {
        ShowSectionTitle("LIBROS > VER DETALLE");
        string id = ReadText("Ingrese el ID o ISBN del libro: ");

        Console.WriteLine();
        Console.WriteLine($"Buscando libro con identificador: {id}");
        Console.WriteLine("Se mostraría: título, autor, año, categoría, ISBN y estado.");
        Console.WriteLine("Simulación: no hay datos persistidos para consultar.");
        Pause();
    }

    static void UpdateBookMenu()
    {
        bool volver = false;

        while (!volver)
        {
            ShowSectionTitle("LIBROS > ACTUALIZAR LIBRO");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("0. Volver al menú de libros");
            Console.WriteLine("----------------------------------------------");

            int opcion = ReadOption("Seleccione una opción (0-3): ", 0, 3);

            switch (opcion)
            {
                case 1:
                    EditBookTitle();
                    break;
                case 2:
                    EditBookAuthor();
                    break;
                case 3:
                    EditBookYearCategory();
                    break;
                case 0:
                    volver = true;
                    break;
            }
        }
    }

    static void EditBookTitle()
    {
        ShowSectionTitle("LIBROS > EDITAR TÍTULO");
        string id = ReadText("ID o ISBN del libro: ");
        string nuevoTitulo = ReadText("Nuevo título: ");

        Console.WriteLine();
        Console.WriteLine($"Solicitud recibida: actualizar el título del libro {id} a \"{nuevoTitulo}\".");
        Console.WriteLine("Simulación: el cambio no se guarda realmente.");
        Pause();
    }

    static void EditBookAuthor()
    {
        ShowSectionTitle("LIBROS > EDITAR AUTOR");
        string id = ReadText("ID o ISBN del libro: ");
        string nuevoAutor = ReadText("Nuevo autor: ");

        Console.WriteLine();
        Console.WriteLine($"Solicitud recibida: actualizar el autor del libro {id} a \"{nuevoAutor}\".");
        Console.WriteLine("Simulación: el cambio no se guarda realmente.");
        Pause();
    }

    static void EditBookYearCategory()
    {
        ShowSectionTitle("LIBROS > EDITAR AÑO / CATEGORÍA");
        string id = ReadText("ID o ISBN del libro: ");
        int nuevoAnio = ReadOption("Nuevo año de publicación (1900-2100): ", 1900, 2100);
        string nuevaCategoria = ReadText("Nueva categoría: ");

        Console.WriteLine();
        Console.WriteLine($"Solicitud recibida para el libro {id}:");
        Console.WriteLine($"  Nuevo año......: {nuevoAnio}");
        Console.WriteLine($"  Nueva categoría: {nuevaCategoria}");
        Console.WriteLine("Simulación: el cambio no se guarda realmente.");
        Pause();
    }

    static void DeleteBook()
    {
        ShowSectionTitle("LIBROS > ELIMINAR LIBRO");
        string id = ReadText("ID o ISBN del libro a eliminar: ");

        Console.WriteLine();
        Console.WriteLine("Validación solicitada: no permitir eliminar un libro si está prestado.");
        Console.WriteLine($"Libro seleccionado: {id}");
        Console.WriteLine("Simulación: el libro no se elimina realmente.");
        Pause();
    }

   static void ShowUsersMenu()
    {
        bool volver = false;

        while (!volver)
        {
            ShowSectionTitle("USUARIOS");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle (por ID/documento)");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("----------------------------------------------");

            int opcion = ReadOption("Seleccione una opción (0-5): ", 0, 5);

            switch (opcion)
            {
                case 1:
                    RegisterUser();
                    break;
                case 2:
                    ListUsers();
                    break;
                case 3:
                    ViewUserDetail();
                    break;
                case 4:
                    UpdateUserMenu();
                    break;
                case 5:
                    DeleteUser();
                    break;
                case 0:
                    volver = true;
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        ShowSectionTitle("USUARIOS > REGISTRAR USUARIO");
        string documento = ReadText("Documento de identidad: ");
        string nombre = ReadText("Nombre completo: ");
        string correo = ReadText("Correo electrónico: ");
        string telefono = ReadText("Teléfono de contacto: ");

        Console.WriteLine();
        Console.WriteLine("Solicitud de registro recibida correctamente (simulación):");
        Console.WriteLine($"  Documento..: {documento}");
        Console.WriteLine($"  Nombre.....: {nombre}");
        Console.WriteLine($"  Correo.....: {correo}");
        Console.WriteLine($"  Teléfono...: {telefono}");
        Console.WriteLine("  Estado.....: Activo");
        Console.WriteLine("Nota: no se almacena información real en esta versión.");
        Pause();
    }

    static void ListUsers()
    {
        ShowActionMessage(
            "USUARIOS > LISTAR USUARIOS",
            "Listar usuarios",
            "Se mostraría el listado completo de usuarios registrados (simulación sin colecciones).");
    }

    static void ViewUserDetail()
    {
        ShowSectionTitle("USUARIOS > VER DETALLE");
        string id = ReadText("Ingrese el ID o documento del usuario: ");

        Console.WriteLine();
        Console.WriteLine($"Buscando usuario con identificador: {id}");
        Console.WriteLine("Se mostraría: documento, nombre, contacto, estado y préstamos activos.");
        Console.WriteLine("Simulación: no hay datos persistidos para consultar.");
        Pause();
    }

    static void UpdateUserMenu()
    {
        bool volver = false;

        while (!volver)
        {
            ShowSectionTitle("USUARIOS > ACTUALIZAR USUARIO");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar");
            Console.WriteLine("0. Volver al menú de usuarios");
            Console.WriteLine("----------------------------------------------");

            int opcion = ReadOption("Seleccione una opción (0-3): ", 0, 3);

            switch (opcion)
            {
                case 1:
                    EditUserName();
                    break;
                case 2:
                    EditUserContact();
                    break;
                case 3:
                    ToggleUserActiveStatus();
                    break;
                case 0:
                    volver = true;
                    break;
            }
        }
    }

    static void EditUserName()
    {
        ShowSectionTitle("USUARIOS > EDITAR NOMBRE");
        string id = ReadText("ID o documento del usuario: ");
        string nuevoNombre = ReadText("Nuevo nombre completo: ");

        Console.WriteLine();
        Console.WriteLine($"Solicitud recibida: actualizar el nombre del usuario {id} a \"{nuevoNombre}\".");
        Console.WriteLine("Simulación: el cambio no se guarda realmente.");
        Pause();
    }

    static void EditUserContact()
    {
        ShowSectionTitle("USUARIOS > EDITAR CONTACTO");
        string id = ReadText("ID o documento del usuario: ");
        string nuevoCorreo = ReadText("Nuevo correo electrónico: ");
        string nuevoTelefono = ReadText("Nuevo teléfono: ");

        Console.WriteLine();
        Console.WriteLine($"Solicitud recibida para el usuario {id}:");
        Console.WriteLine($"  Nuevo correo..: {nuevoCorreo}");
        Console.WriteLine($"  Nuevo teléfono: {nuevoTelefono}");
        Console.WriteLine("Simulación: el cambio no se guarda realmente.");
        Pause();
    }

    static void ToggleUserActiveStatus()
    {
        ShowSectionTitle("USUARIOS > ACTIVAR / DESACTIVAR");
        string id = ReadText("ID o documento del usuario: ");
        bool activar = ReadYesNo("¿Desea activar el usuario? (S = activar, N = desactivar)");

        Console.WriteLine();
        Console.WriteLine(activar
            ? $"Solicitud recibida: activar al usuario {id}."
            : $"Solicitud recibida: desactivar al usuario {id}.");
        Console.WriteLine("Simulación: el estado no se guarda realmente.");
        Pause();
    }

    static void DeleteUser()
    {
        ShowSectionTitle("USUARIOS > ELIMINAR USUARIO");
        string id = ReadText("ID o documento del usuario a eliminar: ");

        Console.WriteLine();
        Console.WriteLine("Validación solicitada: no permitir eliminar un usuario si tiene préstamos activos.");
        Console.WriteLine($"Usuario seleccionado: {id}");
        Console.WriteLine("Simulación: el usuario no se elimina realmente.");
        Pause();
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