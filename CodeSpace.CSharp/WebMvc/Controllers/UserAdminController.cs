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

            //User tuser = new User()
            //{
            //    ID = 1,
            //    Name = "张三"
            //};
            //Head head = new Head()
            //{
            //    Eye = "眼"
            //};

            ////UserDto nuser = new UserDto();
            ////nuser = tuser.MapTo<UserDto>();
            //UserDto nuser = Mapper.Map<UserDto>(tuser);
            //UserDto nuser2 = Mapper.Map(head, nuser);
            //.MapPart(head);
            PhysicalAttribute physical = new PhysicalAttribute() { Eye = "双眼皮", Mouth = "红润" };
            SocialAttribute social = new SocialAttribute() { Name = "张三", IsMarried = false, Age = 18 };
            PeopleDto output = new DtoHelper().GetDto(physical, social);
            string json = JsonConvert.SerializeObject(output);
            new UserDtoHelper().GetDto();
            /*
             
              Mapper.CreateMap<Source, Target>()
        .ConstructUsing(
            f =>
                new Target
                    {
                        PropVal1 = f.PropVal1,
                        PropObj2 = Map<PropObj2Class>(f.PropObj2),
                        PropVal4 = f.PropVal4
                    })
        .ForAllMembers(a => a.Ignore());
             */
            int total = 0 ;
            List<UserTable> userList = userTableService.GetModelsByPage(pageSize,pageIndex,true,m=>m.Uuid,n=>true,out total).ToList();
            List<UserAdminVM> list = new List<UserAdminVM>();
            UserAdminVM vm;
            foreach (var user in userList)
            {
                vm = new UserAdminVM();
                //vm = user.MapTo<UserAdminVM>();
                ReflectionHelper.CopyValue(user, vm);
                list.Add(vm);
            }
            ViewData["PageIndex"] = pageIndex;
            ViewData["PageSize"] = pageSize;
            ViewData["Total"] = total;
            return View(list);
        }

        //public IActionResult Create()
        //{
        //    UserAdminVM vm = new UserAdminVM(userTableService, keywordsService);
        //    return View(vm);
        //}
        //[HttpPost]
        //public IActionResult Create(UserAdminVM vm)
        //{
        //    UserTable user = new UserTable();
        //    user = vm.GetUserTable(user);
        //    bool result = userTableService.Add(user);
        //    if (result)
        //    {
        //        TempData["AlertMsg"] = "保存成功";
        //        TempData["Href"] = "/UserAdmin/Index";
        //    }
        //    else
        //    {
        //        TempData["AlertMsg"] = "保存失败";
        //    }
        //    return View(vm);
        //}
        //public IActionResult Delete(string id)
        //{
        //    UserTable user = userTableService.GetModels(m => m.Uuid == id).FirstOrDefault();
        //    if (user != null)
        //    {
        //        bool result = userTableService.Delete(user);
        //        if (result)
        //        {

        //            TempData["AlertMsg"] = "保存成功";
        //            return Redirect("/UserAdmin/Index");
        //        }
        //        else
        //        {
        //            TempData["AlertMsg"] = "保存成功";
        //            return Redirect("/UserAdmin/Index");
        //        }
                
        //    }
        //    TempData["AlertMsg"] = "对象已被删除";
        //    return Redirect("/UserAdmin/Index");
        //}
        //public IActionResult Edit(string id)
        //{
        //    UserTable user = userTableService.GetModels(m => m.Uuid == id).FirstOrDefault();
        //    UserAdminVM vm = new UserAdminVM(userTableService, keywordsService);
        //    if (user!=null)
        //    {
        //        vm= vm.GetVM(user);
        //    }
        //    return View(vm);
        //}
        //[HttpPost]
        //public IActionResult Edit(string uuid, UserAdminVM vm)
        //{
        //    UserTable user = userTableService.GetModels(m => m.Uuid == uuid).FirstOrDefault();
        //    vm.GetUserTable(user);
        //    bool result = userTableService.Update(user);
        //    if (result)
        //    {
        //        TempData["AlertMsg"] = "保存成功";
        //        TempData["Href"] = "/UserAdmin/Index";
        //    }
        //    else
        //    {
        //        TempData["AlertMsg"] = "保存失败";
        //    }
        //    return View(vm);
        //}

        //public IActionResult Details(string id)
        //{
        //    UserTable user = userTableService.GetModels(m => m.Uuid == id).FirstOrDefault();
        //    UserAdminVM vm = new UserAdminVM(userTableService, keywordsService);
        //    if (user != null)
        //    {
        //        vm = vm.GetVM(user);
        //    }
        //    return View(vm);
        //}
    }
}