using Biblioteca.Models;

namespace Biblioteca.Services;

public sealed class LibroService
{
    private readonly List<Libro> _libros = [];

    public IReadOnlyList<Libro> ObtenerTodos()
    {
        return _libros.AsReadOnly();
    }
}
