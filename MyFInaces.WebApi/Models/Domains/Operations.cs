using System;
using System.Collections.Generic;

namespace MyFinances.WebApi.Models.Domains;

public partial class Operations
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Value { get; set; }

    public DateTime Date{ get; set; }

    public int CategoryId { get; set; }


    public virtual Category Category { get; set; } = null!;
}
