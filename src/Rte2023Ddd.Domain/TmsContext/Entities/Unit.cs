using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

/// <summary>
/// Unidade [TMS_UNIDAD]
/// </summary>
public class Unit : EntityAutoIncrementId
{
    /// <summary>
    /// Identificador único da unidade [UNI_IDENTI]
    /// </summary>
    //public int Id { get; set; }

    /// <summary>
    /// Identificador único da empresa da unidade [UNI_EMP_IDENTI]
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Descrição da unidade [UNI_DESCRI]
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Código externo da unidade [UNI_CODEXT]
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Sigla da unidade [UNI_SIGLA]
    /// </summary>
    public string Acronym { get; set; }

    /// <summary>
    /// Status de funcionamento - Ativo/Inativo [UNI_ATIVO]
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Tipo de unidade - Conforme parâmetro <TIPUNI> [UNI_TIPUNI]
    /// </summary>
    public string UnitType { get; set; }
}
