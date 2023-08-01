using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectPaniukova.DB;

public partial class TruckEmployee
{
    public int EmployeeId { get; set; }

    public string OfficeAddress { get; set; } = null!;

    private string PhoneExt;
    public string PhoneExtensionNumber
    {
        get { return PhoneExt; }
        set
        {
            if (value.All(Char.IsDigit) == true)
            { PhoneExt = value; }
            else
            {
                throw new Exception("Phone extenshion can contain only digits");
            }
        }
    }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual TruckPerson Employee { get; set; } = null!;
}
