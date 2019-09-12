using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.Model.BBSAdmin;
using Common.Standard;

namespace WebMvc.ViewModel
{
    public class UserAdminVM
    {
        //private IUserTableService userTableService = BLLContainer.Container.Resolve<IUserTableService>();
        //private IKeywordsService keywordsService = BLLContainer.Container.Resolve<IKeywordsService>();
        private IUserTableService userTableService;
        private IKeywordsService keywordsService;
        public UserAdminVM(IUserTableService iUserTableService, IKeywordsService iKeywordsService)
        {
            userTableService = iUserTableService;
            keywordsService = iKeywordsService;
            keywords = keywordsService.GetModels(m => m.KeyType == "RoleFlag").ToList();
        }
        List<Keywords> keywords;
        //public UserAdminVM(){
        //    keywords = keywordsService.GetModels(m => m.KeyType == "RoleFlag").ToList();
        //}
        
        private string uuid;
        public string Uuid
        {
            get
            {
                return uuid ?? Guid.NewGuid().ToString();
            }
            set
            {
                uuid = value;
            }
        }
        [Display(Name = "账号")]
        public string UserName { get; set; }
        [Display(Name = "昵称")]
        public string NickName { get; set; }
        public string Pwd { get; set; }
        [Display(Name = "个性签名")]
        public string Introduction { get; set; }
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        private string roleFlag;
        [Display(Name = "角色")]
        public string RoleFlag
        {
            get
            {
                return roleFlag;
            }
            set { roleFlag = value; }
        }
        [Display(Name = "角色")]
        public string RoleFlagName
        {
            get
            {
                Keywords keyword =
                keywords.FirstOrDefault(m => m.KeyType == "RoleFlag" && m.KeyWord == roleFlag);
                return keyword?.Content ?? roleFlag;
            }
        }
        public List<SelectListItem> RoleFlags
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem item;
                foreach (var keyword in keywords)
                {
                    item = new SelectListItem();
                    item.Value = keyword.KeyWord;
                    item.Text = keyword.Content;
                    list.Add(item);
                }
                return list;
            }
        }
        [Display(Name = "主页")]
        public string HomePage { get; set; }
        [Display(Name = "电话")]
        public string Tel { get; set; }

        public UserAdminVM GetVM(UserTable user)
        {
            
            ReflectionHelper.CopyValue<UserTable, UserAdminVM>(user, this);
            return this;
        }
        public List<UserAdminVM> GetVMList(List<UserTable> userList)
        {
            List<UserAdminVM> vmlist = new List<UserAdminVM>();
            UserAdminVM vm;
            foreach (var user in userList)
            {
                vm = new UserAdminVM(userTableService, keywordsService);
                ReflectionHelper.CopyValue(user, vm);
                vmlist.Add(vm);
            }
            return vmlist;
        }

        public UserTable GetUserTable(UserTable user)
        {
            UserAdminVM vm = this;
            ReflectionHelper.CopyValue(vm, user);
            return user;
        }
    }
}
