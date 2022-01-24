using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService studentService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            this.studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = await studentService.GetStudents();
            return View(students);
        }

        public JsonResult AddStudent(string name, int age)
        {
            Student student = new Student();
            student.Name = name;
            student.Age = age;

            studentService.AddStudents(student);
            return Json("Successful!");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MultiplyByReflection(int a, int b)
        {
            string Source = @"C:\Users\BS761\source\repos\StudentMVConion\ClassLibraryA\bin\Debug\netcoreapp3.1";
            string File = Directory.GetFiles(Source, "*.dll", SearchOption.AllDirectories).FirstOrDefault();
            if (File == null)
                return Json("Error");

            Assembly assembly = Assembly.LoadFrom(File);
            Type type = assembly.GetType("ClassLibraryA.ClassMultiply");
            MethodInfo method = type.GetMethod("MultiplyNums", new Type[] {typeof(int), typeof(int)});
            if (method == null)
                return Json("Error");

            var ctor = Activator.CreateInstance(type);
            object[] mParam = new object[] { a, b };
            var res = method.Invoke(ctor, mParam);

            return Json(res);
        }

        [HttpGet]
        public JsonResult AddByReflection(int a, int b)
        {
            string Source = @"C:\Users\BS761\source\repos\StudentMVConion\ClassLibraryB\bin\Debug\netcoreapp3.1";
            string File = Directory.GetFiles(Source, "*.dll", SearchOption.AllDirectories).FirstOrDefault();
            if (File == null)
                return Json("Error");

            Assembly assembly = Assembly.LoadFrom(File);
            Type type = assembly.GetType("ClassLibraryB.ClassAdd");
            MethodInfo method = type.GetMethod("AddNums", new Type[] { typeof(int), typeof(int) });
            if (method == null)
                return Json("Error");

            var ctor = Activator.CreateInstance(type);
            object[] mParam = new object[] { a, b };
            var res = method.Invoke(ctor, mParam);

            return Json(res);
        }

        [HttpGet]
        public JsonResult SubstractByReflection(int a, int b)
        {
            string Source = @"C:\Users\BS761\source\repos\StudentMVConion\ClassLibraryC\bin\Debug\netcoreapp3.1";
            string File = Directory.GetFiles(Source, "*.dll", SearchOption.AllDirectories).FirstOrDefault();
            if (File == null)
                return Json("Error");

            Assembly assembly = Assembly.LoadFrom(File);
            Type type = assembly.GetType("ClassLibraryC.ClassSubstraction");
            MethodInfo method = type.GetMethod("SubstractNums", new Type[] { typeof(int), typeof(int) });
            if (method == null)
                return Json("Error");

            var ctor = Activator.CreateInstance(type);
            object[] mParam = new object[] { a, b };
            var res = method.Invoke(ctor, mParam);

            return Json(res);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
