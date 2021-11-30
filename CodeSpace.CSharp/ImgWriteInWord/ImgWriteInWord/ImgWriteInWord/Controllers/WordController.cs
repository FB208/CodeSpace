using Common.Standard;
using ImgWriteInWord.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImgWriteInWord.Controllers
{
    public class WordController : Controller
    {
        public IActionResult Index()
        {
            List<WordModel> list = new List<WordModel>();
            string basePath = @"D:\CodeSpace\Git\CodeSpace.CSharp\ImgWriteInWord\ImgWriteInWord\ImgWriteInWord\wwwroot\Asset";
            DirectoryInfo dir = new DirectoryInfo(basePath);
            
            foreach (var df in dir.GetDirectories())
            {
                WordModel model = new WordModel();
                model.dirName = df.Name;
                model.fileList = new List<string>();
                DirectoryInfo fdir = new DirectoryInfo(basePath + @"\" + df.Name);
                foreach (var file in fdir.GetFiles())
                {
                    model.fileList.Add(file.Name);
                }
                list.Add(model);
                
            }
            return View(list);
        }
    }
}
