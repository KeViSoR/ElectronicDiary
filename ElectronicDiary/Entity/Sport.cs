using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class Sport
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<SportsmensSportCat> SportsmensSportCats { get; set; } = new List<SportsmensSportCat>();
}
