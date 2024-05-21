using MUDEK.Models;
namespace MUDEK.Models;
public class ViewModel
{
    public Course Course { get; set; }
    public Degerlendirme Degerlendirme { get; set; }
    public List<Course> Courses { get; set; }
    public List<Degerlendirme> Degerlendirmeler { get; set; }
}
