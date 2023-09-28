using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public int? TrainerId { get; set; }

    public int? StageId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<SportsmensGroup> SportsmensGroups { get; set; } = new List<SportsmensGroup>();

    public virtual Stage? Stage { get; set; }

    public virtual Person? Trainer { get; set; }
}
