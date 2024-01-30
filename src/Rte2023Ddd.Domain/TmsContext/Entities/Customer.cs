using Oracle2023Ddd.Domain.Core.DomainObjects;
using Oracle2023Ddd.Domain.Core.Extensions;
using Oracle2023Ddd.Domain.TmsContext.Enums;

namespace Oracle2023Ddd.Domain.TmsContext.Entities;

public class Customer : EntityAutoIncrementId
{
    public int IdCompany { get; set; }
    public string? CommercialClassification { get; set; }
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
    public DateTime? SearchDateWS { get; set; }
    public string SituationDescriptionWS { get; set; }
    public string CustomerClassification { get; set; }
    public int? IdUnitLinked { get; set; }
    public int IdTaxZone { get; set; }
    public int? AddressIdMain { get; set; }
    public string? ExternalCode { get; set; }
    public int? IdUnit { get; set; }
    public int? SectorLogisticId { get; set; }
    public CustomerRegisterSourceEnum RegisterSource
    {
        get
        {
            return RegisterSourceDb.DbValueToEnum<CustomerRegisterSourceEnum>();
        }
        set
        {
            RegisterSourceDb = value.ToDbValue();
        }
    }

    public string RegisterSourceDb { get; private set; } = CustomerRegisterSourceEnum.TMS.ToDbValue();

    #region Relationships

    public Person Person { get; set; }

    #endregion

    public Customer()
    {
    }

    public Customer(int idCompany, string commercialClassification, string taxpayerType, string establishmentType,
        string taxpayerClassificationSystem, DateTime insertDate, string fiscalStatus, string activeDb, int idPerson,
        string? situationWsDb, DateTime searchDateWs, string situationDescriptionWs, string customerClassification,
        int idUnitLinked, int idTaxZone, int addressIdMain, string externalCode, int idUnit, int sectorLogisticId,
        CustomerRegisterSourceEnum registerSource)
    {
        IdCompany = idCompany;
        CommercialClassification = commercialClassification;
        TaxpayerType = taxpayerType;
        EstablishmentType = establishmentType;
        TaxpayerClassificationSystem = taxpayerClassificationSystem;
        InsertDate = insertDate;
        FiscalStatus = fiscalStatus;
        ActiveDb = activeDb;
        IdPerson = idPerson;
        SituationWSDb = situationWsDb;
        SearchDateWS = searchDateWs;
        SituationDescriptionWS = situationDescriptionWs;
        CustomerClassification = customerClassification;
        IdUnitLinked = idUnitLinked;
        IdTaxZone = idTaxZone;
        AddressIdMain = addressIdMain;
        ExternalCode = externalCode;
        IdUnit = idUnit;
        SectorLogisticId = sectorLogisticId;
        RegisterSource = registerSource;
    }
}