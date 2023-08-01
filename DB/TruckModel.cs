using System;
using System.Collections.Generic;

namespace ProjectPaniukova.DB;

public partial class TruckModel
{
    public int ModelId { get; set; }

    public string Model { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string Size { get; set; } = null!;

    public int Seats { get; set; }

    public int Doors { get; set; }

    public virtual ICollection<IndividualTruck> IndividualTrucks { get; set; } = new List<IndividualTruck>();
}
