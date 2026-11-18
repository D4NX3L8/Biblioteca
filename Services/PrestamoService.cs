using Biblioteca.Models;

namespace Biblioteca.Services;

public sealed class PrestamoService
{
    private readonly List<Prestamo> _prestamos = [];

    public void AgregarPrestamo(Prestamo prestamo)
    {
        ArgumentNullException.ThrowIfNull(prestamo);

        if (_prestamos.Exists(actual => actual.Id == prestamo.Id))
        {
            throw new InvalidOperationException($"Ya existe un préstamo con el ID {prestamo.Id}.");
        }

        _prestamos.Add(prestamo);
    }

    public bool EliminarPrestamo(int id)
    {
        Prestamo? prestamo = _prestamos.Find(actual => actual.Id == id);

        if (prestamo is null)
        {
            return false;
        }

        if (prestamo.Estado != EstadoPrestamo.Devuelto)
        {
            throw new InvalidOperationException("Solo se pueden eliminar préstamos devueltos.");
        }

        return _prestamos.Remove(prestamo);
    }

    public IReadOnlyList<Prestamo> ObtenerTodos()
    {
        return _prestamos.AsReadOnly();
    }

    public Prestamo? BuscarPorId(int id)
    {
        return _prestamos.Find(actual => actual.Id == id);
    }

    public IReadOnlyList<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        ActualizarEstados();
        return _prestamos.Where(actual => actual.Estado == estado).ToArray();
    }

    public IReadOnlyList<Prestamo> ObtenerOrdenadosPorFechaLimite()
    {
        return _prestamos
            .OrderBy(actual => actual.FechaDevolucionPrevista)
            .ToArray();
    }

    public int ObtenerTotalPrestamos()
    {
        return _prestamos.Count;
    }

    public int ObtenerPrestamosActivos()
    {
        ActualizarEstados();
        return _prestamos.Count(actual => actual.Estado == EstadoPrestamo.Activo);
    }

    public int ObtenerPrestamosVencidos()
    {
        ActualizarEstados();
        return _prestamos.Count(actual => actual.Estado == EstadoPrestamo.Vencido);
    }

    public int ObtenerPrestamosDevueltos()
    {
        return _prestamos.Count(actual => actual.Estado == EstadoPrestamo.Devuelto);
    }

    public double ObtenerPromedioDiasPrestamo()
    {
        return _prestamos.Count == 0
            ? 0
            : _prestamos.Average(actual => actual.DiasTranscurridos());
    }

    private void ActualizarEstados()
    {
        foreach (Prestamo prestamo in _prestamos)
        {
            prestamo.ActualizarEstado();
        }
    }
}
