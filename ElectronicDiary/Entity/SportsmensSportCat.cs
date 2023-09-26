using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class SportsmensSportCat
{
    public int Id { get; set; }

    public int PersonsId { get; set; }

    public int SportId { get; set; }

    public int? SportCatId { get; set; }

    public DateTime? DateOfAssignmentSc { get; set; }

    public virtual Person Persons { get; set; } = null!;

    public virtual Sport Sport { get; set; } = null!;

    public virtual SportCategory? SportCat { get; set; }
}
