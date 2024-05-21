namespace MUDEK.Models;
public class Course
{
    public int CourseId { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public string CourseSemester { get; set; }
    public List<string> KeyWords { get; set; }
    public List<string> Descriptions { get; set; }
    public List<Degerlendirme> Degerlendirmeler { get; set; }
    
}