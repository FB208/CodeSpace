using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Standard;
using Common.Standard.AutoMapper9;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMvc.DemoClass.AutoMapperDemo;
using WebMvc.IBLL.BBSAdmin;
//using WebMvc.BLLContainer;
using WebMvc.Model.BBSAdmin;
using WebMvc.ViewModel;
using Common.Standard.EFCore;

namespace WebMvc.Controllers
{
    public class UserAdminController : BaseController
    {
        private IMapper Mapper { get; }
        private readonly IUserTableService userTableService;
        private readonly IKeywordsService keywordsService;
        public UserAdminController(IUserTableService iUserTableService, IKeywordsService iKeywordsService,IMapper mapper)
        {
            userTableService = iUserTableService;
            keywordsService = iKeywordsService;
            Mapper = mapper;
        }
        
        //private IUserTableService userTableService = BLLContainer.Container.Resolve<IUserTableService>();
        public IActionResult Index(int pageSize=5,int pageIndex=1)
        {
            int total = 0 ;
            List<UserTable> userList = userTableService.GetModelsByPage(pageSize,pageIndex,true,m=>m.Uuid,n=>true,out total).ToList();
            List<UserAdminVM> list = new List<UserAdminVM>();
            string sql =keywordsService.GetModels(m => true).ToSql();
            List<Keywords> keywords = keywordsService.GetModels(m => true).ToList();
            UserAdminVM vm;
            foreach (var user in userList)
            {
                vm = new UserAdminVM();
                Mapper.Map<UserTable, UserAdminVM>(user, vm);
                vm.SetKeywords(keywords);
                list.Add(vm);
            }
            ViewData["PageIndex"] = pageIndex;
            ViewData["PageSize"] = pageSize;
            ViewData["Total"] = total;
            return View(list);
        }

        public IActionResult Create()
        {
            List<Keywords> keywords = keywordsService.GetModels(m => true).ToList();
            UserAdminVM vm = new UserAdminVM();
            vm.SetKeywords(keywords);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(UserAdminVM vm)
        {
            UserTable user = new UserTable();
            Mapper.Map(vm, user);
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
            if (user != null)
            {
                Mapper.Map(user, vm);
                List<Keywords> keywords = keywordsService.GetModels(m => true).ToList();
                vm.SetKeywords(keywords);
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(string uuid, UserAdminVM vm)
        {
            UserTable user = userTableService.GetModels(m => m.Uuid == uuid).FirstOrDefault();
            Mapper.Map(vm, user);
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
                List<Keywords> keywords = keywordsService.GetModels(m => true).ToList();
                vm.SetKeywords(keywords);
            }
            return View(vm);
        }
    }
}