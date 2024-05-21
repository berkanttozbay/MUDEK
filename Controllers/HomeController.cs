using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MUDEK.Data;
using MUDEK.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
namespace MUDEK.Controllers;
using System.IO;
public class HomeController : Controller
{
    private readonly MudekDbContext _context;

    public HomeController(MudekDbContext context)
    {
        _context = context;

    }
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(Teacher teacher)
    {
        Teacher teacher1 = new(){
            Name = teacher.Name,
            username = teacher.username,
            password = teacher.password  
        };

        _context.Teachers.Add(teacher1);
        _context.SaveChanges();
        if ( teacher1 != null)
        {
            RedirectToAction("Login","Home");
        }
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(Teacher teacher)
    {
        var user = _context.Teachers.FirstOrDefault(a=>a.username.Equals(teacher.username) && a.password.Equals(teacher.password));
        if(user != null)
        {
            return RedirectToAction("Index","Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Kullanici adi veya sifre yanlis");
            return RedirectToAction("Register","Home");
        }

    }
    
    public IActionResult AddCourse()
    {
        

        return View();
    }
    

    [HttpPost]
    public IActionResult AddCourse(ViewModel model)
    {
        // Önce Course kaydını ekleyin
        _context.Courses.Add(model.Course);
        _context.SaveChanges(); // CourseId'nin oluşturulup veritabanına kaydedildiğinden emin olun

        // CourseId'nin atanmış olduğundan emin olun
        model.Degerlendirme.CourseId = model.Course.CourseId;

        // Sonra Degerlendirme kaydını ekleyin
        _context.Degerlendirmeler.Add(model.Degerlendirme);
        
        _context.SaveChanges(); // Degerlendirme kaydını kaydedin
        
        return RedirectToAction("AddCourse", "Home");
    }


    
    
    public IActionResult DersListesi(string selectedSemester)
    {
        var courses = _context.Courses
            .Where(c => c.CourseSemester == selectedSemester)
            .ToList(); // Doğrudan Course nesnelerini seçiyoruz

        ViewBag.SelectedSemester = selectedSemester;
        return View(courses);
    }

    public IActionResult SelectedCourses(string  selectedCourses)
    {
        var course = _context.Courses.Where(c=>c.CourseName==selectedCourses).ToList();
        
        ViewBag.SelectedCourses = selectedCourses;
        return View(course);
    }

    public IActionResult Degerlendirme(string selectedSemester)
    {
        var courses = _context.Courses
            .Where(c => c.CourseSemester == selectedSemester)
            .ToList(); // Doğrudan Course nesnelerini seçiyoruz

        ViewBag.SelectedSemester = selectedSemester;
        return View(courses);
    }
    public IActionResult DegerlendirmeSayfasi(int courseId)
    {
        var course = _context.Courses
            .Include(c => c.Degerlendirmeler) // Degerlendirmeler ilişkisini dahil edin
            .FirstOrDefault(c => c.CourseId == courseId);

        if (course == null)
        {
            return NotFound();
        }

        ViewBag.CourseName = course.CourseName;

        return View(course); // Course nesnesini View metoduna gönderin
    }


    [HttpPost]
    public IActionResult DegerlendirmeSayfasi(List<Degerlendirme> degerlendirmeler, int courseId)
    {
        if (degerlendirmeler != null && degerlendirmeler.Any())
        {
            foreach (var degerlendirme in degerlendirmeler)
            {
                // CourseId değerini Degerlendirme nesnesine atayın
                var nesne = _context.Degerlendirmeler.Where(c=>c.CourseId == courseId).FirstOrDefault();
                _context.Degerlendirmeler.Add(nesne);
            }
            _context.SaveChanges(); // Değişiklikleri veritabanına kaydet
        }

        return RedirectToAction("Index"); // Başka bir sayfaya yönlendirme yapabilirsiniz
    }



    



    


    
    








    
}

    