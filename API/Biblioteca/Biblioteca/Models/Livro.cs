using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Livro
{
    public Guid LivroId { get; set; }

    public string? NomeLivro { get; set; }

    public DateTime? DataLivro { get; set; }

    public string? Descricao { get; set; }

    public byte[]? Imagem { get; set; }
}
