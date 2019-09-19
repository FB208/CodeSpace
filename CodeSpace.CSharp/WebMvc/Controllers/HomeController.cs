using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Emit;
using WebMvc.Filter;
using WebMvc.ViewModel;
using WebMvc.Model.BBSAdmin;
using Common.Standard.EFCore;

namespace WebMvc.Controllers
{
    public class HomeController : BaseController
    {

        //构造函数注入上下文
        private readonly BBSAdminContext _context;
        public HomeController(BBSAdminContext Context)
        {
            _context = Context;
        }
        [Action]
        public async Task<IActionResult> Index()
        {
            List<UserTable> model = _context.UserTable.ToList();
            var ss = _context.UserTable.Where(m => m.UserName == "admin");
            string sql = ss.ToSql();

            //new PersonEmit().Do();


            //

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
