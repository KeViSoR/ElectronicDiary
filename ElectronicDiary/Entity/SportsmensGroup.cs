using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class SportsmensGroup
{
    public int Id { get; set; }

    public int PersonsId { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Person Persons { get; set; } = null!;
}
