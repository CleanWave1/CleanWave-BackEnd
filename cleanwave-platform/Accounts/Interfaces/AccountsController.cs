using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace cleanwave_platform.Accounts.Interfaces;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AccountsController(IAccountCommandService accountCommandService, IAccountQueryService accountQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountResource createAccountResource)
    {
        var createAccountCommand =
            CreateAccountCommandFromResourceAssembler.ToCommandFromResource(createAccountResource);
        var account = await accountCommandService.Handle(createAccountCommand);
        if (account is null) return BadRequest();
        var resource = AccountResourceFromEntityAssembler.ToResourceFromEntity(account);
        return CreatedAtAction(nameof(GetAccountId), new { acoountId = resource.Id }, resource);
    }

    [HttpGet("{accountId:int}")]
    public async Task<IActionResult> GetAccountId([FromRoute] int tutorialId)
    {
        var getAllAccountsQuery = new GetAllAccountsQuery();
        var accounts = await accountQueryService.Handle(getAllAccountsQuery);
        var resources = accounts.Select(AccountResourceFromEntityAssembler
            .ToResourceFromEntity);
        return Ok(resources);
    }
}