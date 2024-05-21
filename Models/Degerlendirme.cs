using System.ComponentModel.DataAnnotations.Schema;

namespace MUDEK.Models;
public class Degerlendirme
{
    public int DegerlendirmeId { get; set; }
    public List<string>?  DegerlendirmeName{ get; set; }
    public List<decimal>? DegerlendirmeYuzde { get; set; }
    public List<string>? DegerlendirmeAltBaslik { get; set; } 
    [ForeignKey("CourseId")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
   
}
