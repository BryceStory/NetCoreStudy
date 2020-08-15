using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsulServiceStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ConsulServiceStudent.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        List<Student> list = new List<Student>() {
        new Student(){ ID = "001", StudentName = "学生1", StudentAge = 16 },
        new Student(){ ID = "002", StudentName = "学生2", StudentAge = 18 },
        new Student(){ ID = "003", StudentName = "学生3", StudentAge = 17 }
        };

        /// <summary>
        /// 健康检查接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Check()
        {
            return "1";
        }

        [HttpGet]
        public List<Student> GetList()
        {
            Console.WriteLine(DateTime.Now.ToString());

            return list;
        }

        [HttpGet]
        public Student GetModel()
        {
            Console.WriteLine(DateTime.Now.ToString());

            return list.Find(t=>t.ID=="001");
        }
    }
}
