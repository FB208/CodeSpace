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
            UserTable user = new UserTable();
            user = vm.GetUserTable(user);
            bool result = userTableService.Add(user);
            if (result)
            {
                TempData["AlertMsg"] = "保存成功";
                TempData["Href"] = "/UserAdmin/Index";
            }
            else
            {
                TempData["AlertMsg"] = "保存失败";
            }
            return View(vm);
        }
        public IActionResult Delete(string id)
        {
            UserTable user = userTableService.GetModels(m => m.Uuid == id).FirstOrDefault();
            if (user != null)
            {
                bool result = userTableService.Delete(user);
                if (result)
                {

                    TempData["AlertMsg"] = "保存成功";
                    return Redirect("/UserAdmin/Index");
                }
                else
                {
                    TempData["AlertMsg"] = "保存成功";
                    return Redirect("/UserAdmin/Index");
                }
                
            }
            TempData["AlertMsg"] = "对象已被删除";
            return Redirect("/UserAdmin/Index");
        }
        public IActionResult Edit(string id)
        {
            UserTable user = userTableService.GetModels(m => m.Uuid == id).FirstOrDefault();
            UserAdminVM vm = new UserAdminVM();
            if (user!=null)
            {
                vm= vm.GetVM(user);
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(string uuid, UserAdminVM vm)
        {
            UserTable user = userTableService.GetModels(m => m.Uuid == uuid).FirstOrDefault();
            vm.GetUserTable(user);
            bool result = userTableService.Update(user);
            if (result)
            {
                TempData["AlertMsg"] = "保存成功";
                TempData["Href"] = "/UserAdmin/Index";
            }
            else
            {
                TempData["AlertMsg"] = "保存失败";
            }
            return View(vm);
        }

        public IActionResult Details(string id)
        {
            UserTable user = userTableService.GetModels(m => m.Uuid == id).FirstOrDefault();
            UserAdminVM vm = new UserAdminVM();
            if (user != null)
            {
                vm = vm.GetVM(user);
            }
            return View(vm);
        }
    }
}