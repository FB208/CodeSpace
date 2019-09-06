﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.Model.BBSAdmin;

namespace WebMvc.ViewModel
{
    public class UserAdminVM
    {
        private IUserTableService userTableService = BLLContainer.Container.Resolve<IUserTableService>();
        private IKeywordsService keywordsService = BLLContainer.Container.Resolve<IKeywordsService>();
        private string uuid;
        public string Uuid {
            get {
                return uuid??Guid.NewGuid().ToString();
            }
            set
            {
                uuid = value;
            }
        }
        [Display(Name ="账号")]
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
        public string RoleFlag {
            get {
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
                keywordsService.GetModels(m => m.KeyType == "RoleFlag" && m.KeyWord == roleFlag).FirstOrDefault();
                return keyword?.Content ?? roleFlag;
            }
        }
        public List<SelectListItem> RoleFlags {
            get {
                List<Keywords> keywords =
                keywordsService.GetModels(m => m.KeyType == "RoleFlag" ).ToList();
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


        public List<UserAdminVM> GetVMList(List<UserTable> userList) {
            
            List<UserAdminVM> vmlist = new List<UserAdminVM>();
            UserAdminVM vm;
            foreach (var user in userList)
            {
                vm = new UserAdminVM();
                PropertyInfo[] userPis = user.GetType().GetProperties();
                PropertyInfo[] vmPis = vm.GetType().GetProperties();
                for (int i = 0; i < userPis.Length; i++)
                {
                    if (vmPis[i].Name==userPis[i].Name)
                    {
                        vmPis[i].SetValue(vm, userPis[i].GetValue(user));
                    }
                    
                }
                vmlist.Add(vm);
            }
            return vmlist;
        }

        public UserTable GetUserTable()
        {
            UserAdminVM vm = this;
            UserTable user = new UserTable();
            PropertyInfo[] userPis = user.GetType().GetProperties();
            PropertyInfo[] vmPis = vm.GetType().GetProperties();
            for (int i = 0; i < userPis.Length; i++)
            {
                if (vmPis[i].Name == userPis[i].Name)
                {
                    userPis[i].SetValue(user, vmPis[i].GetValue(vm));
                }
            }
            return user;
        }
    }
}