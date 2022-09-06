using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Context;
using EntityFrameworkCore.Triggered;

namespace Triggers
{
    public class AuthorTrigger : IBeforeSaveTrigger<Author>, IAfterSaveTrigger<Author>
    {
        readonly ApplicationDbContext _applicationContext;
        readonly ILogger<AuthorTrigger> _logger;

        public AuthorTrigger(ApplicationDbContext applicationContext, ILogger<AuthorTrigger> logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
        }

        public Task BeforeSave(ITriggerContext<Author> context, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Before Save Author");
            return Task.CompletedTask;
        }

        public Task AfterSave(ITriggerContext<Author> context, CancellationToken cancellationToken)
        {
            _logger.LogInformation("After Save Author");
            return Task.CompletedTask;
        }
    }
}
