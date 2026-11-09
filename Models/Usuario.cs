namespace Biblioteca.Models;

public sealed class Usuario
{
    public int Id { get; private set; }
    public string Documento { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;
    public string Correo { get; private set; } = string.Empty;
    public string Telefono { get; private set; } = string.Empty;
    public bool Activo { get; private set; }

    public Usuario()
    {
        Activo = true;
    }

    public Usuario(int id, string documento, string nombre, string correo, string telefono)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "El ID debe ser mayor que cero.");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(documento);
        ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
        ArgumentException.ThrowIfNullOrWhiteSpace(correo);
        ArgumentException.ThrowIfNullOrWhiteSpace(telefono);

        Id = id;
        Documento = documento.Trim();
        Nombre = nombre.Trim();
        Correo = correo.Trim();
        Telefono = telefono.Trim();
        Activo = true;
    }

    public void Desactivar()
    {
        Activo = false;
    }

    public void Activar()
    {
        Activo = true;
    }

    public string ResumenCorto()
    {
        return $"{Id}. {Nombre} — Documento: {Documento}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\n" +
               $"Documento: {Documento}\n" +
               $"Nombre: {Nombre}\n" +
               $"Correo: {Correo}\n" +
               $"Teléfono: {Telefono}\n" +
               $"Activo: {Activo}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}