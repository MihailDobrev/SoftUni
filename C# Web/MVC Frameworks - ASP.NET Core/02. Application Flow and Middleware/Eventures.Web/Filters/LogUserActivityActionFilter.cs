using Eventures.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Eventures.Web.Filters
{
    public class LogUserActivityActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;
        private readonly IEventsService eventService;

        public LogUserActivityActionFilter(ILoggerFactory loggerFactory, IEventsService eventService)
        {
            this.logger = loggerFactory.CreateLogger<LogUserActivityActionFilter>();
            this.eventService = eventService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            var dateNow = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm");
            var adminName = context.HttpContext.User.Identity.Name;
            var eventureEvent = eventService.All().LastOrDefault();
            var eventName = eventureEvent.Name;
            var eventStart = eventureEvent.Start.ToString("dd/MM/yyyy HH:mm");
            var eventEnd = eventureEvent.End.ToString("dd/MM/yyyy HH:mm");

            this.logger.LogInformation($"[{dateNow}] Administrator {adminName} create event {eventName} ({eventStart} / {eventEnd}).");

        }
    }
}
