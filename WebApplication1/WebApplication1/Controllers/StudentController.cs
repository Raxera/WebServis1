using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        #region Ornek Metodlar

        [HttpGet]
        [Route("[controller]/[action]")]
        public string Test()
        {
            return "Hello World";
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public string Today() 
        { 
            return DateTime.Now.ToLongDateString();
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public List<int> RandomNumber()
        {
            Random r = new Random();
            List<int> sayilar = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                int sayi = r.Next(1, 50);
                sayilar.Add(sayi);
            }
            return sayilar;
        }
        #endregion
        
        [HttpGet]
        [Route("[controller]/[action]")]
        public Student GetStudent()
        {
            Student ogrenci = new Student();
            ogrenci.Id = 1;
            ogrenci.FirstName = "Ali";
            ogrenci.LastName = "Mehmet";
            ogrenci.StudentNumber = "2016";

            return ogrenci;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, FirstName = "a", LastName = "b" , StudentNumber = "11"});
            students.Add(new Student { Id = 2, FirstName = "c", LastName = "d", StudentNumber = "22" });
            students.Add(new Student { Id = 3, FirstName = "e", LastName = "f", StudentNumber = "33" });

            return students;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public List<Student> GetStudents2()
        {
            List<Student> students = StudentList();
            return students;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public Student GetStudentById(int id) {
            List<Student> students = StudentList();
            Student student = students
                .Where( x => x.Id == id )
                .First();
            return student;
        }


        [HttpPost]
        [Route("[controller]/[action]")]
        public List<Student> AddStudent([FromBody] Student newStudent)
        {
            List<Student> students = StudentList();
            students.Add(newStudent);
            return students;
        }

        [HttpPatch]
        [Route("[controller]/[action]")]
        public IActionResult UpdateStudent([FromBody] Student student) {
            Student? s = StudentList()
                .Where(x => x.Id == student.Id)
                .FirstOrDefault();

            if (s == null)
                return Ok("Öğrenci bulunamadı");

            s.StudentNumber = student.StudentNumber;
            return Ok(s);
        }




        private static List<Student> StudentList()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, FirstName = "Cengiz", LastName = "Fazıl", StudentNumber = "11" });
            students.Add(new Student { Id = 2, FirstName = "Tuğçe", LastName = "Kandemir", StudentNumber = "22" });
            students.Add(new Student { Id = 3, FirstName = "Seval", LastName = "Pide", StudentNumber = "33" });
            students.Add(new Student { Id = 4, FirstName = "Osman", LastName = "Kasap", StudentNumber = "44" });
            students.Add(new Student { Id = 5, FirstName = "Kazım", LastName = "Karabekir", StudentNumber = "55" });
            return students;
        }

    }
}
