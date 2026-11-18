using Biblioteca.Demostraciones;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.UI;

public sealed class MenuServicios
{
    public void Mostrar()
    {
        ObjetosPrueba objetos = new();
        LibroService libros = new();
        UsuarioService usuarios = new();
        PrestamoService prestamos = new();

        foreach (Libro libro in objetos.Libros)
        {
            libros.AgregarLibro(libro);
        }

        foreach (Usuario usuario in objetos.Usuarios)
        {
            usuarios.AgregarUsuario(usuario);
        }

        prestamos.AgregarPrestamo(objetos.Prestamo);

        Console.WriteLine();
        Console.WriteLine("=== SERVICIOS Y COLECCIONES: EV08 ===");
        MostrarComparacionArrayYList();
        MostrarOperacionesDeEliminacion(libros, usuarios, prestamos);

        Console.WriteLine();
        Console.WriteLine("Búsquedas:");
        Console.WriteLine(
            $"Libro por ISBN: {libros.BuscarPorIsbn("978-958-00-0001-1")?.ResumenCorto() ?? "No encontrado"}");
        MostrarElementos("Libros cuyo título contiene 'la':", libros.BuscarPorTitulo("la"));
        MostrarElementos("Libros cuyo autor contiene 'rivera':", libros.BuscarPorAutor("rivera"));
        Console.WriteLine(
            $"Usuario por documento: {usuarios.BuscarPorDocumento("100000001")?.ResumenCorto() ?? "No encontrado"}");
        MostrarElementos("Usuarios cuyo nombre contiene 'ana':", usuarios.BuscarPorNombre("ana"));
        Console.WriteLine(
            $"Préstamo por ID: {prestamos.BuscarPorId(1)?.ResumenCorto() ?? "No encontrado"}");
        MostrarElementos(
            "Préstamos vencidos:",
            prestamos.BuscarPorEstado(EstadoPrestamo.Vencido));

        Console.WriteLine();
        Console.WriteLine("Ordenaciones:");
        MostrarElementos("Libros por título:", libros.ObtenerOrdenadosPorTitulo());
        MostrarElementos("Usuarios por nombre:", usuarios.ObtenerOrdenadosPorNombre());
        MostrarElementos(
            "Préstamos por fecha límite:",
            prestamos.ObtenerOrdenadosPorFechaLimite());

        Console.WriteLine();
        Console.WriteLine("KPIs:");
        Console.WriteLine(
            $"Libros: total={libros.ObtenerTotalLibros()}, disponibles={libros.ObtenerLibrosDisponibles()}, prestados={libros.ObtenerLibrosPrestados()}");
        Console.WriteLine(
            $"Usuarios: total={usuarios.ObtenerTotalUsuarios()}, activos={usuarios.ObtenerUsuariosActivos()}, inactivos={usuarios.ObtenerUsuariosInactivos()}");
        Console.WriteLine(
            $"Préstamos: total={prestamos.ObtenerTotalPrestamos()}, activos={prestamos.ObtenerPrestamosActivos()}, vencidos={prestamos.ObtenerPrestamosVencidos()}, devueltos={prestamos.ObtenerPrestamosDevueltos()}, promedio de días={prestamos.ObtenerPromedioDiasPrestamo():F1}");

        EntradaConsola.Pausar();
    }

    private static void MostrarComparacionArrayYList()
    {
        string[] titulosArray = ["Cien años de soledad", "La vorágine"];
        var titulosLista = new List<string>(titulosArray);

        Console.WriteLine();
        Console.WriteLine("Comparación Array vs List<T>:");
        Console.WriteLine($"Array: {string.Join(", ", titulosArray)} (Length = {titulosArray.Length}, tamaño fijo).");
        titulosLista.Add("El principito");
        Console.WriteLine(
            $"List<T>: {string.Join(", ", titulosLista)} (Count = {titulosLista.Count}, tamaño dinámico con Add).");
    }

    private static void MostrarOperacionesDeEliminacion(
        LibroService libros,
        UsuarioService usuarios,
        PrestamoService prestamos)
    {
        var libroTemporal = new Libro(
            3,
            "978-958-00-0003-5",
            "Libro temporal",
            "Autor temporal",
            2020,
            "Prueba");
        libros.AgregarLibro(libroTemporal);
        Console.WriteLine($"Agregar y eliminar libro temporal: {libros.EliminarLibro(libroTemporal.Id)}");

        var usuarioTemporal = new Usuario(
            3,
            "100000003",
            "Usuario temporal",
            "temporal@example.com",
            "3000000003");
        usuarios.AgregarUsuario(usuarioTemporal);
        Console.WriteLine(
            $"Agregar y eliminar usuario temporal: {usuarios.EliminarUsuario(usuarioTemporal.Id)}");

        var prestamoTemporal = new Prestamo(
            2,
            new Libro(3, "978-958-00-0004-2", "Prueba", "Autor", 2021, "Prueba"),
            new Usuario(3, "100000004", "Prueba", "prueba@example.com", "3000000004"),
            DateTime.Today.AddDays(-1),
            DateTime.Today.AddDays(10));
        prestamoTemporal.RegistrarDevolucion(DateTime.Today);
        prestamos.AgregarPrestamo(prestamoTemporal);
        Console.WriteLine(
            $"Agregar y eliminar préstamo devuelto: {prestamos.EliminarPrestamo(prestamoTemporal.Id)}");
    }

    private static void MostrarElementos<T>(string titulo, IEnumerable<T> elementos)
    {
        Console.WriteLine(titulo);

        foreach (T elemento in elementos)
        {
            Console.WriteLine($"  {elemento}");
        }
    }
}
