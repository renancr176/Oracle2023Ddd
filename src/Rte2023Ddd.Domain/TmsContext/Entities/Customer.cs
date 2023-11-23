using Rte2023Ddd.Domain.Core.DomainObjects;
using Rte2023Ddd.Domain.TmsContext.Enums;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

public class Customer : EntityAutoIncrementId
{
    public int IdCompany { get; set; }
    public string CommercialClassification { get; set; }
    public string TaxpayerType { get; set; }
    public string EstablishmentType { get; set; }
    public string TaxpayerClassificationSystem { get; set; }
    public DateTime InsertDate { get; set; }
    public string FiscalStatus { get; set; }
    public bool Active
    {
        get { return ActiveDb == "S"; }
        set { ActiveDb = value ? "S" : "N"; }
    }
    public string ActiveDb { get; private set; }
    public int IdPerson { get; set; }
    public bool? SituationWS
    {
        get
        {
            return !string.IsNullOrEmpty(SituationWSDb) 
                ? (SituationWSDb == "S") 
                : null;
        } 
        set 
        { 
            SituationWSDb = value.HasValue
                ? (value.Value ? "S" : "N")
                : null;
        }
    }
    public string? SituationWSDb { get; private set; }
    public DateTime SearchDateWS { get; set; }
    public string SituationDescriptionWS { get; set; }
    public string CustomerClassification { get; set; }
    public int IdUnitLinked { get; set; }
    public int IdTaxZone { get; set; }
    public int AddressIdMain { get; set; }
    public string ExternalCode { get; set; }
    public int IdUnit { get; set; }
    public int SectorLogisticId { get; set; }
    public CustomerRegisterSourceEnum RegisterSource { get; set; }
    public string PersonFilter { get; set; }

    #region Relationships

    public Person Person { get; set; }

    #endregion
}