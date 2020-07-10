using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLCRoad.Pages.Statistics
{
    /// <summary>
    /// This class will contain all data of the entire statistic collection.
    /// The separate classes PersonalData etc, all contain a portion of it.
    /// </summary>
    [Serializable]
    public class StatisticsData
    {
        public PersonalData PersonalInfo { get; set; } = new PersonalData();
        public RoadData RoadData { get; set; } = new RoadData();
        public FarmData FarmData { get; set; } = new FarmData();
        public BusinessData BusinessData { get; set; } = new BusinessData();
        public LandData LandData { get; set; } = new LandData();
        public FamilyData FamilyData { get; set; } = new FamilyData();

        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }

    [Serializable]
    public class PersonalData
    {
        public int PersonId { get; set; }
        public string? FullName { get; set; }
	public string? SLCStatus { get; set; }
        public int BoxNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }


        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }

    [Serializable]
    public class RoadData
    {
        public List<Vehicle> Cars { get; set; } = new List<Vehicle>();
        public List<Vehicle> Trucks { get; set; } = new List<Vehicle>();
        public List<Vehicle> Other { get; set; } = new List<Vehicle>();
        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }

    /// <summary>
    /// Base class for all vehicles, truck etc
    /// </summary>
    [Serializable]
    public class Vehicle
    { 

        

    


    public VehicleType VehicleInfo { get; set; } = null!;
        public int? Refund { get; set; }
        
        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }

    [Serializable]
    public class VehicleType
    {
        public string Name { get; set; } = null!;
        public decimal Rate { get; set; }
        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }

    public static class VehicleTypes
    {
        public static VehicleType AtvCycle = new VehicleType { Name = "ATV/cycle", Rate = 30 };
        public static VehicleType CarPickupEtc = new VehicleType { Name = "Car, truck, etc.", Rate = 200 };

        public static VehicleType SingleAxleTruck = new VehicleType { Name = "Single axle truck", Rate = 300 };
        public static VehicleType TandemAxleTruck = new VehicleType { Name = "Tandem axle truck", Rate = 400 };
        public static VehicleType TruckWithTrailer = new VehicleType { Name = "Truck with trailer", Rate = 600 };
        public static VehicleType SemiTruck = new VehicleType { Name = "Semi truck", Rate = 300 };

        public static VehicleType FiveCylandSmaller = new VehicleType { Name = "Tractor - 5 Cylinder & Smaller", Rate = 60 };
        public static VehicleType SixCylandBigger = new VehicleType { Name = "Tractor - 6 Cylinder & Bigger", Rate = 100 };
        public static VehicleType Combines = new VehicleType { Name = "Combine", Rate = 100 };
        public static VehicleType Aircraft = new VehicleType { Name = "Aircraft", Rate = .35M };
    }

    [Serializable]
    public class FarmData
    {
        public int? BeefCattle { get; set; }
        public int? DairyCattle { get; set; }
        public int? Horses { get; set; }
        public int? Hogs { get; set; }
        public int? Sheep { get; set;}
        
        public int? Hens { get; set; }
        public int? Breeders { get; set; }
        public int? Pullets { get; set; }
        public int? Broilers { get; set; }

        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }
    
    [Serializable]
    public class BusinessData
    {
        public decimal? BusinessResellingGross { get; set; }
        public decimal? PavementTaxGross { get; set; }
        public decimal? CustomWorkServicesGross { get; set; }

        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }

    [Serializable]
    public class LandData 
    {
        public decimal? Residential { get; set; }
        public decimal? CropLand { get; set; }
        public decimal? CowPasture { get; set; }
        public decimal? Jungle { get; set; }
        public decimal? Other { get; set; }

        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }

    [Serializable]
    public class FamilyData
    {
        public List<string> PersonName { get; set; } = new List<string>();

	public int? FamilyAmount { get; set; }
	
	public int? IndividualAmount { get; set; }

        public override string? ToString() =>
            JsonSerializer.Serialize(this, GetType());
    }
    
    
}
