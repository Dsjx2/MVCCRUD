using System;
using System.Collections.Generic;

namespace MVCCRUD.Models;

public partial class Mazo
{
    public int IdMazo { get; set; }

    public string MazoNombre { get; set; } = null!;
}
