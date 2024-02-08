using System;
using System.Collections.Generic;

namespace Database_First.Models;

public partial class OperationClaim
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
