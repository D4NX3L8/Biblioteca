namespace Biblioteca.Models;

public sealed class Prestamo
{
    public int Id { get; private set; }
    public Libro? Libro { get; private set; }
    public Usuario? Usuario { get; private set; }
    public DateTime FechaPrestamo { get; private set; }
    public DateTime FechaDevolucionPrevista { get; private set; }
    public DateTime? FechaDevolucion { get; private set; }
    public EstadoPrestamo Estado { get; private set; }

    public Prestamo()
    {
        FechaPrestamo = DateTime.Now;
        FechaDevolucionPrevista = DateTime.Now.AddDays(15);
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    public Prestamo(
        int id,
        Libro libro,
        Usuario usuario,
        DateTime fechaPrestamo,
        DateTime fechaDevolucionPrevista)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "El ID debe ser mayor que cero.");
        }

        ArgumentNullException.ThrowIfNull(libro);
        ArgumentNullException.ThrowIfNull(usuario);

        if (fechaDevolucionPrevista <= fechaPrestamo)
        {
            throw new ArgumentException(
                "La fecha prevista debe ser posterior a la fecha del préstamo.");
        }

        if (!usuario.Activo)
        {
            throw new InvalidOperationException("No se puede prestar a un usuario inactivo.");
        }

        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaDevolucionPrevista = fechaDevolucionPrevista;
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;

        libro.MarcarPrestado();
    }

    public bool EstaVencido()
    {
        return Estado != EstadoPrestamo.Devuelto &&
               DateTime.Now.Date > FechaDevolucionPrevista.Date;
    }

    public int DiasTranscurridos()
    {
        DateTime fechaFinal = FechaDevolucion ?? DateTime.Now;
        return Math.Max(0, (fechaFinal.Date - FechaPrestamo.Date).Days);
    }

    public void ActualizarEstado()
    {
        if (Estado != EstadoPrestamo.Devuelto && EstaVencido())
        {
            Estado = EstadoPrestamo.Vencido;
        }
    }

    public void RegistrarDevolucion(DateTime fechaDevolucion)
    {
        if (Estado == EstadoPrestamo.Devuelto)
        {
            throw new InvalidOperationException("Este préstamo ya fue devuelto.");
        }

        if (fechaDevolucion.Date < FechaPrestamo.Date)
        {
            throw new ArgumentException(
                "La fecha de devolución no puede ser anterior a la fecha del préstamo.",
                nameof(fechaDevolucion));
        }

        Libro?.RegistrarDevolucion();
        FechaDevolucion = fechaDevolucion;
        Estado = EstadoPrestamo.Devuelto;
    }

    public string ResumenCorto()
    {
        string titulo = Libro?.Titulo ?? "Sin libro asignado";
        string nombre = Usuario?.Nombre ?? "Sin usuario asignado";
        return $"Préstamo {Id}: {titulo} para {nombre} — Estado: {Estado}";
    }

    public string DetalleCompleto()
    {
        string libro = Libro?.ResumenCorto() ?? "Sin libro asignado";
        string usuario = Usuario?.ResumenCorto() ?? "Sin usuario asignado";
        string fechaDevolucion = FechaDevolucion?.ToString("dd/MM/yyyy") ?? "null";

        return $"ID: {Id}\n" +
               $"Libro: {libro}\n" +
               $"Usuario: {usuario}\n" +
               $"Fecha del préstamo: {FechaPrestamo:dd/MM/yyyy}\n" +
               $"Fecha prevista: {FechaDevolucionPrevista:dd/MM/yyyy}\n" +
               $"Fecha de devolución: {fechaDevolucion}\n" +
               $"Estado: {Estado}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}