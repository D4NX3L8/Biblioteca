using Biblioteca.Models;

namespace Biblioteca.Services;

public sealed class UsuarioService
{
    private readonly List<Usuario> _usuarios = [];

    public IReadOnlyList<Usuario> ObtenerTodos()
    {
        return _usuarios.AsReadOnly();
    }
}
