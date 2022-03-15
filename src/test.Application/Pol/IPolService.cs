using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Pol.Dto;

namespace test.Pol
{
    public interface IPolService : IApplicationService
    {
       int getPol();
    }
}
