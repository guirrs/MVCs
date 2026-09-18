using System;
using System.Collections.Generic;

namespace Cafeteria.Entities;

public partial class Item
{
    public int ItemId { get; set; }

    public string? NomeItem { get; set; }

    public decimal? Preco { get; set; }

    public byte[]? Imagem { get; set; }

    public string? Descricao { get; set; }
}
