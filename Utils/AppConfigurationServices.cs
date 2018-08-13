using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Utils
{
    public class AppConfigurationServices
    {
        private readonly IOptions<ApplicationConfiguration> _appConfiguration;

        public AppConfigurationServices(IOptions<ApplicationConfiguration> appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public ApplicationConfiguration AppConfigurations
        {
            get { return _appConfiguration.Value; }
        }
    }
}
