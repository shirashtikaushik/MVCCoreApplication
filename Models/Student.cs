using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MVCCoreApplication.Models
{
    public class Student
    {

        public int ID { get; set; }
        private List<Student> students = new List<Student>();
       
        // Check if the ID is non-repeatable
        public bool IsIDUnique(int ID)
        {
            return !students.Any(s => s.ID == ID);
        }

        // Add a new student with ID validation
        public void AddStudent(Student student)
        {
            if (IsIDUnique(student.ID))
            {
                students.Add(student);
            }
            else
            {
                // Handle the case where the ID is not unique, e.g., throw an exception or set a validation error.
                throw new ArgumentException("ID must be unique");
            }
        }
    

    [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Name should only contain alphabets and spaces")]
        public string? Name { get; set; }

        [Required(ErrorMessage="DOB is Required")]
        [DOBValid]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Batch is required")]
        [RegularExpression("^B[0-9]{3}$", ErrorMessage = "Batch should start with 'B' followed by three digits")]
        public string? Batch { get; set; }
       
    }

}