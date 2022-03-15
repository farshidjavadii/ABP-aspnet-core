using System.Threading.Tasks;
using Abp.Application.Services;
using test.Sessions.Dto;

namespace test.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
        void getSetion();
    }
}
