using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Utils
{
    /// <summary>
    /// 配置类，读取appsettings.json配置文件的ApplicationConfiguration配置节
    /// </summary>
    public class ApplicationConfiguration
    {
        /// <summary>
        /// 文件上传路径
        /// </summary>
        public string FileUpPath { get; set; }

        /// <summary>
        /// 是否启用单用户登录
        /// </summary>
        public bool IsSingleLogin { get; set; }

        /// <summary>
        /// 允许上传的文件格式
        /// </summary>
        public string AttachExtension { get; set; }

        /// <summary>
        /// 图片上传最大KB
        /// </summary>
        public int AttachImagesize { get; set; }
    }
}
