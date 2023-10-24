using Rte2023Ddd.Domain.Core.DomainObjects;
using System.Runtime;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

/// <summary>
/// Detalhe da Escala [TTF_ESCDET]
/// </summary>
public class TrafficScheduleDetail : EntityAutoIncrementId
{
    /// <summary>
    /// Identificador unico do detalhe da escala [ESD_IDENTI]
    /// </summary>
    //public int Id { get; set; }

    /// <summary>
    /// Sequencia de escala [ESD_SEQUEN]
    /// </summary>
    public long Sequence { get; set; }

    /// <summary>
    /// Data e hora de Chegada [ESD_CHEGAD]
    /// </summary>
    public DateTime CheckIn { get; set; }

    /// <summary>
    /// Data e hora da saída [ESD_SAIDA]
    /// </summary>
    public DateTime CheckOut { get; set; }

    /// <summary>
    /// Tempo de parada [ESD_PARADA]
    /// </summary>
    public TimeSpan TimeStop { get; set; }

    /// <summary>
    /// KM percorridos [ESD_KM]
    /// </summary>
    public decimal Km { get; set; }

    /// <summary>
    /// Distância em KM entre unidades ou setores operacionais. [ESD_DISTAN]
    /// </summary>
    public int Distance { get; set; }

    /// <summary>
    /// Tempo de viagem [ESD_TEMPO]
    /// </summary>
    public TimeSpan Time { get; set; }

    /// <summary>
    /// Identificador da Unidade [ESD_UNI_IDENTI]
    /// </summary>
    public Unit Unit { get; set; }

    /// <summary>
    /// Identificador único do motorista [ESD_MOT_IDENTI]
    /// </summary>
    public Person Driver { get; set; }

    /// <summary>
    /// Identificador do veículo [ESD_VEI_IDENTI_VEICUL]
    /// </summary>
    public Vehicle Vehicle { get; set; }

    /// <summary>
    /// Identificador da carreta [ESD_VEI_IDENTI_CARRET]
    /// </summary>
    public Vehicle Trailer { get; set; }
}