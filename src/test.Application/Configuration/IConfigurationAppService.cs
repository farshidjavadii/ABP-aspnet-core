using System.Threading.Tasks;
using test.Configuration.Dto;

namespace test.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
