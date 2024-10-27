using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentPortal.web.Data;
using studentPortal.web.Models;
using studentPortal.web.Models.Entites;

namespace studentPortal.web.Controllers
{
    public class StudentController : Controller

    {     
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Add(AddStudentModelView s)
        {
            var student = new Student
            {
                Name = s.Name,
                email = s.email,
                Phone = s.Phone,
                subcribed = s.subcribed,
            };
            await dbContext.students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("list","Student");
        }
        [HttpGet]
        public async Task<IActionResult> list() { 
            var students= await dbContext.students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var student= await dbContext.students.FindAsync(Id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student x)
        {
            var student = await dbContext.students.FindAsync(x.Id);
            if(student is not null)
            {
                student.Name = x.Name;
                student.email = x.email;
                student.Phone = x.Phone;
                student.subcribed = x.subcribed;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("list","Student");

        }
        [HttpPost]
        public async Task<IActionResult> delete(Student s)
        {
            var student=await dbContext.students.AsNoTracking().
                FirstOrDefaultAsync(x => x.Id == s.Id);
            if(student is not null)
            {
                dbContext.students.Remove(s);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("list", "Student");
        }
    }
}
