using Biblioteca.Models;

namespace Biblioteca.Services;

public sealed class LibroService
{
    private readonly List<Libro> _libros = [];

    public void AgregarLibro(Libro libro)
    {
        ArgumentNullException.ThrowIfNull(libro);

        if (_libros.Exists(actual => actual.Id == libro.Id))
        {
            throw new InvalidOperationException($"Ya existe un libro con el ID {libro.Id}.");
        }

        if (_libros.Exists(actual =>
                string.Equals(actual.Isbn, libro.Isbn, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Ya existe un libro con el ISBN {libro.Isbn}.");
        }

        _libros.Add(libro);
    }

    public bool EliminarLibro(int id)
    {
        Libro? libro = _libros.Find(actual => actual.Id == id);

        if (libro is null)
        {
            return false;
        }

        if (!libro.Disponible)
        {
            throw new InvalidOperationException("No se puede eliminar un libro prestado.");
        }

        return _libros.Remove(libro);
    }

    public IReadOnlyList<Libro> ObtenerTodos()
    {
        return _libros.AsReadOnly();
    }

    public Libro? BuscarPorIsbn(string isbn)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(isbn);
        string isbnNormalizado = isbn.Trim();

        return _libros.Find(actual =>
            string.Equals(actual.Isbn, isbnNormalizado, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<Libro> BuscarPorTitulo(string titulo)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(titulo);

        return _libros
            .Where(actual => actual.Titulo.Contains(titulo.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }

    public IReadOnlyList<Libro> BuscarPorAutor(string autor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(autor);

        return _libros
            .Where(actual => actual.Autor.Contains(autor.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }

    public IReadOnlyList<Libro> ObtenerOrdenadosPorTitulo()
    {
        return _libros
            .OrderBy(actual => actual.Titulo, StringComparer.CurrentCultureIgnoreCase)
            .ToArray();
    }
}
