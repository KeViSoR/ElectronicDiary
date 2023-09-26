using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class Trainer
{
    public int Id { get; set; }

    public int PersonsId { get; set; }

    public string TrainerLogin { get; set; } = null!;

    public string TrainerPassword { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual Person Persons { get; set; } = null!;
}
