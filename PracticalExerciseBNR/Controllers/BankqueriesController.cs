namespace PracticalExerciseBNR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankqueriesController : ControllerBase
{
    private readonly TestscursnetcoreContext _context;
        public BankqueriesController(TestscursnetcoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
    {
        if(_context.Banks != null)
        {
            return await _context.Banks.ToListAsync();  
        }
        return NotFound();
    }
}
