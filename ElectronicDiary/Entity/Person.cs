using System;
using System.Collections.Generic;

namespace ElectronicDiary.Entity;

public partial class Person
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public DateTime ReceiptDate { get; set; }

    public string? PlaceOfStudyOrWork { get; set; }

    public string? TelNumber { get; set; }

    public string? Adress { get; set; }

    public string? Email { get; set; }

    public byte[]? Photo { get; set; }

    public string? AdditionalInfo { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<SportsmensGroup> SportsmensGroups { get; set; } = new List<SportsmensGroup>();

    public virtual ICollection<SportsmensSportCat> SportsmensSportCats { get; set; } = new List<SportsmensSportCat>();

    public virtual Trainer? Trainer { get; set; }
}
