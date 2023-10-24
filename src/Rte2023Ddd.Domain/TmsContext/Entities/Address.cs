using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

/// <summary>
/// Endereço [TMS_ENDERE]
/// </summary>
public class Address : EntityAutoIncrementId
{
    /// <summary>
    /// Identificador do endereço [EDE_IDENTI]
    /// </summary>
    //public int Id { get; set; }

    /// <summary>
    /// Tipo de Logradouro [EDE_TIPLOG]
    /// </summary>
    public string TypeAddress { get; set; }

    /// <summary>
    /// Endereco [EDE_ENDERE]
    /// </summary>
    public string StreetName { get; set; }

    /// <summary>
    /// Numero [EDE_NUMERO]
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Complemento [EDE_COMPLE]
    /// </summary>
    public string Supplement { get; set; }

    /// <summary>
    /// Bairro [EDE_BAIRRO]
    /// </summary>
    public string District { get; set; }

    /// <summary>
    /// Unidade da Federação [EDE_UNF_UNIFED]
    /// </summary>
    public string UnitFederationCode { get; set; }

    /// <summary>
    /// Cidade [EDE_CIDADE]
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Codigo de enderecamento postal CEP [EDE_CEP]
    /// </summary>
    public string Cep { get; set; }

    /// <summary>
    /// Pessoa do endereço [EDE_PES_IDENTI]
    /// </summary>
    public int PersonId { get; set; }

    #region Relationships

    public Person Person { get; set; }

    #endregion
}