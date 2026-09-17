using System;
using System.Collections.Generic;

namespace Mercado.Entities;

public partial class Item
{
    public int ItemId { get; set; }

    public string? NomeItem { get; set; }

    public int? Quantidade { get; set; }
}
