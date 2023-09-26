using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? SportId { get; set; }

    public int? ChiefId { get; set; }

    public byte[]? Logo { get; set; }

    public virtual Person? Chief { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual Sport? Sport { get; set; }
}
