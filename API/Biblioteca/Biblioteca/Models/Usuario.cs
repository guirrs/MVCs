using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Usuario
{
    public Guid UsuarioId { get; set; }

    public string? Email { get; set; }

    public byte[] Senha { get; set; } = null!;
}
