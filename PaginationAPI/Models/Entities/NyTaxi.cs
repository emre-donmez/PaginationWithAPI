using System;
using System.Collections.Generic;

namespace PaginationAPI.Models.Entities;

public partial class NyTaxi
{
    public string Medallion { get; set; } = null!;

    public string HackLicense { get; set; } = null!;

    public string? VendorId { get; set; }

    public string? RateCode { get; set; }

    public string? StoreAndFwdFlag { get; set; }

    public DateTime PickupDatetime { get; set; }

    public DateTime? DropoffDatetime { get; set; }

    public int? PassengerCount { get; set; }

    public long? TripTimeInSecs { get; set; }

    public double? TripDistance { get; set; }

    public string? PickupLongitude { get; set; }

    public string? PickupLatitude { get; set; }

    public string? DropoffLongitude { get; set; }

    public string? DropoffLatitude { get; set; }

    public string? PaymentType { get; set; }

    public double? FareAmount { get; set; }

    public double? Surcharge { get; set; }

    public double? MtaTax { get; set; }

    public double? TollsAmount { get; set; }

    public double? TotalAmount { get; set; }

    public double? TipAmount { get; set; }

    public int? Tipped { get; set; }

    public int? TipClass { get; set; }
}
