using SIS.Framework.Api;
using SIS.Framework.Services;
using Torshia.Services;

namespace Torshia
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IUserService, UserService>();
            dependencyContainer.RegisterDependency<ITaskService, TaskService>();
            dependencyContainer.RegisterDependency<IReportService, ReportService>();
        }
    }
}
