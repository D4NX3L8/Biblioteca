using Biblioteca.Models;

namespace Biblioteca.Services;

public sealed class UsuarioService
{
    private readonly List<Usuario> _usuarios = [];

    public void AgregarUsuario(Usuario usuario)
    {
        ArgumentNullException.ThrowIfNull(usuario);

        if (_usuarios.Exists(actual => actual.Id == usuario.Id))
        {
            throw new InvalidOperationException($"Ya existe un usuario con el ID {usuario.Id}.");
        }

        if (_usuarios.Exists(actual =>
                string.Equals(
                    actual.Documento,
                    usuario.Documento,
                    StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException(
                $"Ya existe un usuario con el documento {usuario.Documento}.");
        }

        _usuarios.Add(usuario);
    }

    public bool EliminarUsuario(int id)
    {
        Usuario? usuario = _usuarios.Find(actual => actual.Id == id);
        return usuario is not null && _usuarios.Remove(usuario);
    }

    public IReadOnlyList<Usuario> ObtenerTodos()
    {
        return _usuarios.AsReadOnly();
    }

    public Usuario? BuscarPorDocumento(string documento)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(documento);
        string documentoNormalizado = documento.Trim();

        return _usuarios.Find(actual =>
            string.Equals(
                actual.Documento,
                documentoNormalizado,
                StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<Usuario> BuscarPorNombre(string nombre)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nombre);

        return _usuarios
            .Where(actual => actual.Nombre.Contains(nombre.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }

    public IReadOnlyList<Usuario> ObtenerOrdenadosPorNombre()
    {
        return _usuarios
            .OrderBy(actual => actual.Nombre, StringComparer.CurrentCultureIgnoreCase)
            .ToArray();
    }

    public int ObtenerTotalUsuarios()
    {
        return _usuarios.Count;
    }

    public int ObtenerUsuariosActivos()
    {
        return _usuarios.Count(actual => actual.Activo);
    }

    public int ObtenerUsuariosInactivos()
    {
        return _usuarios.Count(actual => !actual.Activo);
    }
}
