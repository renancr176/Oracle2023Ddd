using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

public class Address : EntityAutoIncrementId
{
    public string Type { get; set; }
    public DateTime BeginningDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public string Cep { get; set; }
    public string? TypeAddress { get; set; }
    public string StreetName { get; set; }
    public string? Number { get; set; }
    public string? Supplement { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? IbgeCity { get; set; }
    public string UnitFederationCode { get; set; }
    public string? State { get; set; }
    public int? IbgeUf { get; set; }
    public string? Country { get; set; }
    public int? IbgeCountry { get; set; }
    public bool Active {
        get { return ActiveDb.ToUpper() == "S"; }
        set { ActiveDb = value ? "S" : "N"; } 
    }
    public string ActiveDb { get; private set; }
    public int? IdPerson { get; set; }
    public string Origin { get; set; }
    public bool Changed { 
        get { return ChangedDb.ToUpper() == "S"; }
        set { ChangedDb = value ? "S" : "N"; }
    }
    public string ChangedDb { get; private set; }
    public string CountryCode { get; set; }
    public int CityId { get; set; }
    public int? ParentId { get; set; }
    public string? RedispatchDescription { get; set; }
    public DateTime? WindowDeliveryBegin { get; set; }
    public DateTime? WindowDeliveryFinal { get; set; }
    public DateTime? RestrictWindowDeliveryBegin { get; set; }
    public DateTime? RestrictWindowDeliveryFinal { get; set; }

    #region Relationships

    public Person Person { get; set; }

    #endregion
}