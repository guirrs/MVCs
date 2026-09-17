using System;
using System.Collections.Generic;

namespace Mercado.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Email { get; set; }

    public byte[]? Senha { get; set; }
}
