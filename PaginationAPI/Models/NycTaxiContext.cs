using Microsoft.EntityFrameworkCore;
using PaginationAPI.Models.Entities;

namespace PaginationAPI.Models;

public partial class NycTaxiContext : DbContext
{
    public NycTaxiContext()
    {
    }

    public NycTaxiContext(DbContextOptions<NycTaxiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NyTaxi> NyTaxis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<NyTaxi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nyctaxi_sample");

            entity.Property(e => e.DropoffDatetime)
                .HasColumnType("datetime")
                .HasColumnName("dropoff_datetime");
            entity.Property(e => e.DropoffLatitude)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dropoff_latitude");
            entity.Property(e => e.DropoffLongitude)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dropoff_longitude");
            entity.Property(e => e.FareAmount).HasColumnName("fare_amount");
            entity.Property(e => e.HackLicense)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hack_license");
            entity.Property(e => e.Medallion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("medallion");
            entity.Property(e => e.MtaTax).HasColumnName("mta_tax");
            entity.Property(e => e.PassengerCount).HasColumnName("passenger_count");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("payment_type");
            entity.Property(e => e.PickupDatetime)
                .HasColumnType("datetime")
                .HasColumnName("pickup_datetime");
            entity.Property(e => e.PickupLatitude)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pickup_latitude");
            entity.Property(e => e.PickupLongitude)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pickup_longitude");
            entity.Property(e => e.RateCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rate_code");
            entity.Property(e => e.StoreAndFwdFlag)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("store_and_fwd_flag");
            entity.Property(e => e.Surcharge).HasColumnName("surcharge");
            entity.Property(e => e.TipAmount).HasColumnName("tip_amount");
            entity.Property(e => e.TipClass).HasColumnName("tip_class");
            entity.Property(e => e.Tipped).HasColumnName("tipped");
            entity.Property(e => e.TollsAmount).HasColumnName("tolls_amount");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.TripDistance).HasColumnName("trip_distance");
            entity.Property(e => e.TripTimeInSecs).HasColumnName("trip_time_in_secs");
            entity.Property(e => e.VendorId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vendor_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}