using System.Threading.Tasks;
using Acme.SimpleTaskApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace Acme.SimpleTaskApp.Web.Tests.Controllers
{
    public class HomeController_Tests: SimpleTaskAppWebTestBase
    {
        [Fact]
        public async System.Threading.Tasks.Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
