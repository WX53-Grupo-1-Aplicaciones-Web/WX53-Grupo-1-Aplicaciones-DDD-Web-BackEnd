using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Publishing.Models.Entities;

public class ModelBase
{
    public int Id { get; set; }
    public int CreatedUserId { get; set; }
    public int? UpdatedUserId { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreateDate { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdateDate { get; set; } = DateTime.Now;
    
    [DefaultValue(true)] 
    public Boolean IsActive { get; set; }
    
}