using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

/// <summary>
/// Romaneio [TAR_ROMANE]
/// </summary>
public partial class PackingList : EntityAutoIncrementId
{
    /// <summary>
    /// Identificador único do romaneio [ROM_IDENTI]
    /// </summary>
    //public int Id { get; set; }

    /// <summary>
    /// Número do romaneio [ROM_ROMNRO]
    /// </summary>
    public int PLNumber { get; set; }

    /// <summary>
    /// Número de série do romaneio [ROM_ROMSRE]
    /// </summary>
    public int PLDigit { get; set; }

    /// <summary>
    /// Detalhes da Escala
    /// </summary>
    public TrafficScheduleDetail TrafficScheduleDetail { get; set; }

    /// <summary>
    /// Identificador unico do detalhe dos CT-e 
    /// </summary>
    public List<PackingListDetail> PackingListDetails { get; set; }
}