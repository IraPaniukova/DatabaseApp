using System;
using System.Collections.Generic;

namespace ProjectPaniukova.DB;

public partial class TruckCustomer
{
    public int CustomerId { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public int Age { get; set; }

    public DateTime LicenseExpiryDate { get; set; }

    public virtual TruckPerson Customer { get; set; } = null!;

    public virtual ICollection<TruckRental> TruckRentals { get; set; } = new List<TruckRental>();
}
