namespace PracticalExerciseBNR.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BankqueriesController : ControllerBase
{
    private BankqueriesRepository _bankRepo;
    public BankqueriesController()
    {
        _bankRepo = new BankqueriesRepository();
    }

    [HttpGet]
    public List<BankModels> GetBanksAndDebtors()
    {
        return _bankRepo.GetDebtorCustomers().ToList();
    }

    [HttpGet]
    public List<CustomerDebtorModels> GetDebtorsAtMoreBanks()
    {
        return _bankRepo.GetCustomersWithMoreCredits().ToList();
    }
}
