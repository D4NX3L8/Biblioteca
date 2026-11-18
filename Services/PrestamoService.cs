using Biblioteca.Models;

namespace Biblioteca.Services;

public sealed class PrestamoService
{
    private readonly List<Prestamo> _prestamos = [];

    public IReadOnlyList<Prestamo> ObtenerTodos()
    {
        return _prestamos.AsReadOnly();
    }
}
