using System.Threading.Tasks;
using Abp.Application.Services;
using test.Authorization.Accounts.Dto;

namespace test.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
