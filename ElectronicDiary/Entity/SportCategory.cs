using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class SportCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Validity { get; set; }

    public virtual ICollection<SportsmensSportCat> SportsmensSportCats { get; set; } = new List<SportsmensSportCat>();
}
