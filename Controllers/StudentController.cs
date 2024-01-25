using Microsoft.AspNetCore.Mvc;
using MVCCoreApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCCoreApplication.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                
                if (students.Any(s => s.ID == student.ID))
                {
                    ModelState.AddModelError("ID", "ID must be unique");
                    return View(student);
                }

                students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Edit(int id)
        {
            Student student = students.FirstOrDefault(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                Student existingStudent = students.FirstOrDefault(s => s.ID == student.ID);

                if (existingStudent == null)
                {
                    return NotFound();
                }

               
                existingStudent.Name = student.Name;
                existingStudent.DOB = student.DOB;
                existingStudent.Address = student.Address;
                existingStudent.Batch = student.Batch;

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Details(int id)
        {
            Student student = students.FirstOrDefault(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            Student student = students.FirstOrDefault(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Student student = students.FirstOrDefault(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
