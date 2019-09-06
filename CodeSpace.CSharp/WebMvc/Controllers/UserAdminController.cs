using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.BLLContainer;
using WebMvc.Model.BBSAdmin;
using WebMvc.ViewModel;

namespace WebMvc.Controllers
{
    public class UserAdminController : BaseController
    {

        //private readonly IUserTableService _userTableService;
        //public UserAdminController(IUserTableService Context)
        //{
        //    _userTableService = Context;
        //}
        private IUserTableService userTableService = BLLContainer.Container.Resolve<IUserTableService>();
        public IActionResult Index()
        {
            List<UserTable> userList = userTableService.GetModels(m => true).ToList();
            List<UserAdminVM> list = new UserAdminVM().GetVMList(userList);
            return View(list);
        }

        public IActionResult Create()
        {
            UserAdminVM vm = new UserAdminVM();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(UserAdminVM vm)
        {
            UserTable user = vm.GetUserTable();
            bool result = userTableService.Add(user);
            if (result)
            {
                ViewData["AlertMsg"] = "保存成功";
                ViewData["Href"] = "/UserAdmin/Index";
            }
            else
            {
                ViewData["AlertMsg"] = "保存失败"; 
            }
            return View(vm);
        }
    }
}