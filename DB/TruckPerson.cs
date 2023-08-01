using System;
using System.Collections.Generic;

namespace ProjectPaniukova.DB;

public partial class TruckPerson
{
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual TruckCustomer? TruckCustomer { get; set; }

    public virtual TruckEmployee? TruckEmployee { get; set; }
}
