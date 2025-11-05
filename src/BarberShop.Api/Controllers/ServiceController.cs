using Asp.Versioning;
using BarberShop.Api.Controllers.Base;
using BarberShop.Application.DTO;
using BarberShop.Application.Request;
using BarberShop.Application.Request.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers;

[Route("api/v{version:apiVersion}/service")]
[ApiVersion("1.0")]
public class ServiceController(IMediator mediator)
    : BaseController(mediator)
{
    [HttpPost("create")]
    public async Task<ActionResult> CreateService([FromBody] CreateServiceRequest request)
        => await SendCommand(request, 201);

    [HttpGet]
    public async Task<ActionResult<List<ServiceDto>>> ListServices()
        => await SendCommand(new ListServicesRequest());

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteService([FromHeader] Guid id)
        => await SendCommand(new DeleteServiceRequest(id));

    [HttpPut("update")]
    public async Task<ActionResult> UpdateService([FromBody] UpdateServiceRequest request)
        => await SendCommand(request);
}