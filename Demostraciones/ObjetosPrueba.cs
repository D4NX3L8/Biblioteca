using Biblioteca.Models;

namespace Biblioteca.Demostraciones;

public sealed class ObjetosPrueba
{
    public IReadOnlyList<Libro> Libros { get; }
    public IReadOnlyList<Usuario> Usuarios { get; }
    public Prestamo Prestamo { get; }

    public ObjetosPrueba()
    {
        var libroUno = new Libro(
            1,
            "978-958-00-0001-1",
            "Cien años de soledad",
            "Gabriel García Márquez",
            1967,
            "Novela");

        var libroDos = new Libro(
            2,
            "978-958-00-0002-8",
            "La vorágine",
            "José Eustasio Rivera",
            1924,
            "Literatura colombiana");

        var usuarioUno = new Usuario(
            1,
            "100000001",
            "Ana Torres",
            "ana@example.com",
            "3000000001");

        var usuarioDos = new Usuario(
            2,
            "100000002",
            "Luis Pérez",
            "luis@example.com",
            "3000000002");

        Libros = Array.AsReadOnly([libroUno, libroDos]);
        Usuarios = Array.AsReadOnly([usuarioUno, usuarioDos]);

        Prestamo = new Prestamo(
            1,
            libroUno,
            usuarioUno,
            DateTime.Today.AddDays(-20),
            DateTime.Today.AddDays(-5));
    }
}