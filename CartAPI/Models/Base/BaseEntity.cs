using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartAPI.Models;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
}