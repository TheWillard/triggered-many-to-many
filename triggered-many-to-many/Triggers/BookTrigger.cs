using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Context;
using EntityFrameworkCore.Triggered;

namespace Triggers
{
    public class BookTrigger : IBeforeSaveTrigger<Book>, IAfterSaveTrigger<Book>
    {
        readonly ApplicationDbContext _applicationContext;
        readonly ILogger<BookTrigger> _logger;

        public BookTrigger(ApplicationDbContext applicationContext, ILogger<BookTrigger> logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
        }

        public Task BeforeSave(ITriggerContext<Book> context, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Before Save Book");
            return Task.CompletedTask;
        }

        public Task AfterSave(ITriggerContext<Book> context, CancellationToken cancellationToken)
        {
            _logger.LogInformation("After Save Book");
            return Task.CompletedTask;
        }
    }
}
