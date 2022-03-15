using System.Threading.Tasks;
using test.Models.TokenAuth;
using test.Web.Controllers;
using Shouldly;
using Xunit;

namespace test.Web.Tests.Controllers
{
    public class HomeController_Tests: testWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}