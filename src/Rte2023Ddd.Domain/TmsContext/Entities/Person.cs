using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rte2023Ddd.Domain.Core.DomainObjects;
using Rte2023Ddd.Domain.Core.Extensions;
using Rte2023Ddd.Domain.TmsContext.Enums;
using System.Security.Policy;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

public class Person : EntityAutoIncrementId
{
    public PersonTypeEnum TypePerson { 
        get
        {
            return TypePersonDb.DbValueToEnum<PersonTypeEnum>();
        } 
        set
        {
            TypePersonDb = value.ToDbValue();
        }
    }
    public string TypePersonDb { get; private set; }
    public string TaxIdRegistration { get; set; }
    public string StadualIdRegistration { get; set; }
    public string RegionalIdRegistration { get; set; }
    public string Description { get; set; }
    public string ReductedDescription { get; set; }
    public string FictitiousName { get; set; }
    public string IdCnae { get; set; }
    public string CnaeDescription { get; set; }

    #region Relationships

    public Cnae Cnae { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Customer> Customers { get; set; }

    #endregion

    public Person()
    {
    }

    public Person(string typePersonDb, string taxIdRegistration, string stadualIdRegistration,
        string regionalIdRegistration, string description, string reductedDescription, string fictitiousName,
        string idCnae, string cnaeDescription)
    {
        TypePersonDb = typePersonDb;
        TaxIdRegistration = taxIdRegistration;
        StadualIdRegistration = stadualIdRegistration;
        RegionalIdRegistration = regionalIdRegistration;
        Description = description;
        ReductedDescription = reductedDescription;
        FictitiousName = fictitiousName;
        IdCnae = idCnae;
        CnaeDescription = cnaeDescription;
    }
}
