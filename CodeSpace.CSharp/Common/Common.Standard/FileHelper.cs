using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Standard
{
    public class FileHelper
    {
        public FileHelper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取文件详情
        /// </summary>
        /// <param name="Path"></param>
        public static void fileinfo(string Path)
        {
            FileInfo file = new FileInfo(Path);//实例该路径文件信息
            var length = file.Length;//文件大小,字节
            var name = file.Name;//文件名
            var fullname = file.FullName;//文件路径
            var extension = file.Extension;//文件后缀名
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void NewFile(string filePath)
        {
            string newfilepath = filePath;
            if (System.IO.File.Exists(newfilepath))
            {
                //判断新建的文件是否已经存在
                throw new Exception("文件已经存在");
            }

            System.IO.File.Create(newfilepath);//创建
        }
        /// <summary>
        /// 复制文件，带重命名
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="targetPath"></param>
        public static void Copy(string Path, string targetPath)
        {
            //Path = HttpContext.Current.Server.MapPath(Path);//原文件的物理路径
            //targetPath = HttpContext.Current.Server.MapPath(targetPath);//复制到的新位置物理路径
            //判断到的新地址是否存在重命名文件
            if (System.IO.File.Exists(targetPath))
            {
                throw new Exception("存在同名文件");//抛出异常
            }
            System.IO.File.Copy(Path, targetPath);//复制到新位置,不允许覆盖现有文件
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void CreateDirectory(string path)
        {
            if (!System.IO.Directory.Exists(path))//如果不存在就创建file文件夹
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        public static bool ExistsFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
