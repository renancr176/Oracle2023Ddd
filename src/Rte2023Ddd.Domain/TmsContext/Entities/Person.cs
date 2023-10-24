using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

/// <summary>
/// Pessoa [TMS_PESSOA]
/// </summary>
public class Person : EntityAutoIncrementId
{
    /// <summary>
    /// Identificador de pessoa [PES_IDENTI]
    /// </summary>
    //public int Id { get; set; }

    /// <summary>
    /// CPF / CNPJ [PES_CPFCNP]
    /// </summary>
    public string TaxIdRegistration { get; set; }

    /// <summary>
    /// Razao Social / Nome da pessoa [PES_DESCRI]
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Tipo pessoa [PES_TIPPES]
    /// </summary>
    public string PersonType { get; set; }

    #region Relationships

    /// <summary>
    /// Endereço
    /// </summary>
    public ICollection<Address> Addresses { get; set; }

    #endregion
}
