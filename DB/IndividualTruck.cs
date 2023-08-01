using System;
using System.Collections.Generic;

namespace ProjectPaniukova.DB;

public partial class IndividualTruck
{
    public int TruckId { get; set; }

    public string Colour { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public DateTime WofexpiryDate { get; set; }

    public DateTime RegistrationExpiryDate { get; set; }

    public DateTime DateImported { get; set; }

    public int ManufactureYear { get; set; }

    public string Status { get; set; } = null!;

    public string FuelType { get; set; } = null!;

    public string Transmission { get; set; } = null!;

    public decimal DailyRentalPrice { get; set; }

    public decimal AdvanceDepositRequired { get; set; }

    public int TruckModelId { get; set; }

    public virtual TruckModel TruckModel { get; set; } = null!;

    public virtual ICollection<TruckRental> TruckRentals { get; set; } = new List<TruckRental>();

    public virtual ICollection<TruckFeature> Features { get; set; } = new List<TruckFeature>();
}
