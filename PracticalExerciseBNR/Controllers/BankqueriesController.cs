namespace PracticalExerciseBNR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankqueriesController : ControllerBase
{
    private BankqueriesRepository _bankRepo;
    public BankqueriesController()
    {
        _bankRepo = new BankqueriesRepository();
    }

    [HttpGet]
    public List<BankModels> GetBanks()
    {
        var result = _bankRepo.GetAllCustomers().ToList();

        return result;
    }
}
