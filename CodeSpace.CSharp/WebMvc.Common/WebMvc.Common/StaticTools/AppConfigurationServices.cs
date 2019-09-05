using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebMvc.Common.StaticTools
{
    public class AppConfigurationServices
    {
        private IConfiguration Configuration { get; set; }

        public void  AppConfigurtaionServices()
        {

        }

        public IConfiguration GetConfiguration() {
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
            //ReloadOnChange = true 当appsettings.json被修改时重新加载   
            return Configuration;
        }
    }
}
