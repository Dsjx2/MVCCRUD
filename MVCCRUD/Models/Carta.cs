using System;
using System.Collections.Generic;

namespace MVCCRUD.Models;

public partial class Carta
{
    public int IdCarta { get; set; }

    public string? TipoCarta { get; set; }

    public string? NombreCarta { get; set; }

    public int? PoderAtaque { get; set; }

    public int? PoderDefensa { get; set; }
}
