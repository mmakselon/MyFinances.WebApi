using System;
using System.Collections.Generic;

namespace MyFinances.WebApi.Models.Domains;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Operations> Operations { get; set; } = new List<Operations>();
}
