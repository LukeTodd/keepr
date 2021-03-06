
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeeps
  {
    public int Id { get; set; }
    [Required]
    public int VaultId { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public int KeepId { get; set; }
  }
}