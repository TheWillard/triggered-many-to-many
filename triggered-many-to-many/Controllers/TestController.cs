using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace triggered_many_to_many.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {


        private readonly ILogger<TestController> _logger;
        private readonly ApplicationDbContext _context;

        public TestController(IDbContextFactory<ApplicationDbContext> contextFactory, ILogger<TestController> logger)
        {
            _logger = logger;
            _context = contextFactory.CreateDbContext();
        }

        [HttpGet(Name = "test")]
        public IActionResult Get()
        {
            _context.Authors.Add(new() { Id = 1, Name = "Author Name", Books = new List<Book>() });
            _context.SaveChanges();

            _context.Books.Add(new() { Id = 1, Title = "Book Title", Authors = new List<Author>() });
            _context.SaveChanges();

            var user = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == 1);
            var books = _context.Books.Include(x => x.Authors).FirstOrDefault(x => x.Id == 1);

            user.Books.Add(books);

            _context.SaveChanges();

            return Ok();
        }
    }
}