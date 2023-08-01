using System;
using System.Collections.Generic;

namespace ProjectPaniukova.DB;

public partial class TruckFeature
{
    public int FeatureId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<IndividualTruck> Trucks { get; set; } = new List<IndividualTruck>();
}
