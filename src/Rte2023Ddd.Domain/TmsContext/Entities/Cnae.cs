using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Domain.TmsContext.Entities;

public class Cnae : EntityStringId
{
    public string? CodeParent  { get; set; }
    public string Description  { get; set; } 
    public string? SubClass  { get; set; }
    public string? Group  { get; set; }
    public string? Division  { get; set; }
    public string? IdActivity { get; set; }
    public string? ChapterNcm  { get; set; }
    public string? Section  { get; set; }
    public string Class  { get; set; }

    #region Relationships

    public ICollection<Person> People { get; set; }

    #endregion

    public Cnae(string id) : base(id)
    {
    }
}