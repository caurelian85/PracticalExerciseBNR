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

    [HttpGet]
    public List<CustomerDetailsModels> GetCustomerDetails(string customerName)
    {
        return _bankRepo.CustomerDetails(customerName).ToList();
    }

    [HttpPost]
    //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(bool))]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    public IResult MoveCustomerCredit(string customerName, string firstBank, string secondBank, long maxDebit)
    {
        /*bool processingStatus = await _bankRepo.CreditRelocate(customerName, firstBank, secondBank, maxDebit);
        return processingStatus
            ? StatusCode(StatusCodes.Status200OK)
            : StatusCode(StatusCodes.Status422UnprocessableEntity);*/
        var response = _bankRepo.CreditRelocate(customerName, firstBank, secondBank, maxDebit)
            ? Results.Ok(customerName)
            : Results.UnprocessableEntity();
        return response;
    }

}
