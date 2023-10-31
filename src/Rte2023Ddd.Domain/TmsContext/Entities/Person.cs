using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rte2023Ddd.Domain.Core.DomainObjects;
using Rte2023Ddd.Domain.TmsContext.Enums;
using System.Security.Policy;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

public class Person : EntityAutoIncrementId
{
    public PersonTypeEnum TypePerson { 
        get
        {
            switch (TypePersonDb)
            {
                case "":
                    return PersonTypeEnum.Legal;
                case "":
                    return PersonTypeEnum.Natural;
                case "":
                    return PersonTypeEnum.Foreign;
                default: 
                    return PersonTypeEnum.None;
            }
        } 
        set
        {
            switch (value)
            {
                case PersonTypeEnum.Legal:
                    TypePersonDb = "";
                    break;
                case PersonTypeEnum.Natural:
                    TypePersonDb = "";
                    break;
                case PersonTypeEnum.Foreign:
                    TypePersonDb = "";
                    break;
                default:
                    TypePersonDb = "";
                    break;
            }
        }
    }
    private string TypePersonDb { get; set; }
    public string TaxIdRegistration { get; set; }
    public string StadualIdRegistration { get; set; }
    public string RegionalIdRegistration { get; set; }
    public string Description { get; set; }
    public string ReductedDescription { get; set; }
    public string FictitiousName { get; set; }
    public string Cnae { get; set; }
    public string CnaeDescription { get; set; }
    public string PersonCreatorProgram { get; set; }
    public int PersonCreatorUser { get; set; }
    public DateTime PersonCreationDate { get; set; }
    public string? PersonUpdateProgram { get; set; }
    public int? PersonUpdateUser { get; set; }
    public DateTime? PersonUpdateDate { get; set; }
}
