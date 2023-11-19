using System;
using System.Collections.Generic;

namespace CA_Barbut.Models;

public partial class Balance
{
    public int Id { get; set; }

    public int Point { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
