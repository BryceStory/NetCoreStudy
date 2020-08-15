using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsulServiceTeacher.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsulServiceTeacher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        List<Teacher> list = new List<Teacher>() {
        new Teacher(){ ID = "004", TeacherName = "老师1", TeacherAge = 36 },
        new Teacher(){ ID = "005", TeacherName = "老师2", TeacherAge = 38 },
        new Teacher(){ ID = "006", TeacherName = "老师3", TeacherAge = 37 }
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
        public List<Teacher> GetList()
        {
            Console.WriteLine(DateTime.Now.ToString());

            return list;
        }

        [HttpGet]
        public Teacher GetModel(string id)
        {
            Console.WriteLine(DateTime.Now.ToString());

            return list.Find(t => t.ID == id);
        }
    }
}
