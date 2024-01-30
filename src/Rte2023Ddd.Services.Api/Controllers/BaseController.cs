﻿using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oracle2023Ddd.Domain.Core.Messages.CommonMessages.Notifications;
using Oracle2023Ddd.Services.Api.Models.Responses;

namespace Oracle2023Ddd.Services.Api.Controllers;

public abstract class BaseController : Controller
{
    private readonly DomainNotificationHandler _notifications;
    private readonly IMediator _mediator;

    protected Guid ClienteId;

    public BaseController(INotificationHandler<DomainNotification> notifications,
        IMediator mediator,
        IHttpContextAccessor httpContextAccessor)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _mediator = mediator;

        if (!httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) return;

        var claim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        ClienteId = Guid.Parse(claim.Value);
    }

    protected bool ValidOperation()
    {
        return !_notifications.HasNotification();
    }

    protected List<BaseResponseError> GetErrorMessages()
    {
        return _notifications.GetNotifications().Select(c => new BaseResponseError()
        {
            ErrorCode = c.Key,
            Message = c.Value
        })
        .ToList();
    }

    protected void NotificarErro(string errorCode, string errorMessage)
    {
        _mediator.Publish(new DomainNotification(errorCode, errorMessage));
    }

    protected new IActionResult Response(object? result = null)
    {
        if (ValidOperation())
        {
            return Ok(new BaseResponse<object?>()
            {
                Data = result
            });
        }

        return BadRequest(new BaseResponse<object>()
        {
            Errors = GetErrorMessages()
        });
    }

    protected IActionResult InvalidModelResponse()
    {
        return BadRequest(new BaseResponse()
        {
            Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => new BaseResponseError()
            {
                ErrorCode = "ModelError",
                Message = e.ErrorMessage
            }).ToList()
        });
    }
}
