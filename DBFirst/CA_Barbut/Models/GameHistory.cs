using System;
using System.Collections.Generic;

namespace CA_Barbut.Models;

public partial class GameHistory
{
    public int GameId { get; set; }

    public int UserId { get; set; }

    public short UserDice { get; set; }

    public short Pcdice { get; set; }

    public int PointInvested { get; set; }

    public int TotalPointInvested { get; set; }

    public DateTime GameDate { get; set; }

    public virtual User User { get; set; } = null!;
}
