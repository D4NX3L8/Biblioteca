namespace Biblioteca.Models;

public sealed class Libro
{
    public int Id { get; private set; }
    public string Isbn { get; private set; } = string.Empty;
    public string Titulo { get; private set; } = string.Empty;
    public string Autor { get; private set; } = string.Empty;
    public int AnioPublicacion { get; private set; }
    public string Categoria { get; private set; } = string.Empty;
    public bool Disponible { get; private set; }

    public Libro()
    {
        Disponible = true;
    }

    public Libro(
        int id,
        string isbn,
        string titulo,
        string autor,
        int anioPublicacion,
        string categoria)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "El ID debe ser mayor que cero.");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(isbn);
        ArgumentException.ThrowIfNullOrWhiteSpace(titulo);
        ArgumentException.ThrowIfNullOrWhiteSpace(autor);
        ArgumentException.ThrowIfNullOrWhiteSpace(categoria);

        if (anioPublicacion < 1000 || anioPublicacion > DateTime.Today.Year)
        {
            throw new ArgumentOutOfRangeException(
                nameof(anioPublicacion),
                "El año debe estar entre 1000 y el año actual.");
        }

        Id = id;
        Isbn = isbn.Trim();
        Titulo = titulo.Trim();
        Autor = autor.Trim();
        AnioPublicacion = anioPublicacion;
        Categoria = categoria.Trim();
        Disponible = true;
    }

    public void MarcarPrestado()
    {
        if (!Disponible)
        {
            throw new InvalidOperationException("El libro ya está prestado.");
        }

        Disponible = false;
    }

    public void RegistrarDevolucion()
    {
        Disponible = true;
    }

    public string ResumenCorto()
    {
        return $"{Id}. {Titulo} — {Autor} (ISBN: {Isbn})";
    }

    public string DetalleCompleto()
    {
        string estado = Disponible ? "Disponible" : "Prestado";
        return $"ID: {Id}\n" +
               $"ISBN: {Isbn}\n" +
               $"Título: {Titulo}\n" +
               $"Autor: {Autor}\n" +
               $"Año: {AnioPublicacion}\n" +
               $"Categoría: {Categoria}\n" +
               $"Disponible: {Disponible} ({estado})";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}