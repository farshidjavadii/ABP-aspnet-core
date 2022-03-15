using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Pol.Dto;

namespace test.Pol
{
    public class PolService : testAppServiceBase, IPolService
    {
        public int getPol()
        {
            return 1;
        }
    }
}
