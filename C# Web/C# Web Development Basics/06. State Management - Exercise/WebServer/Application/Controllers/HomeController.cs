namespace WebServer.Application.Controllers
{
    using Server.Enums;
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using System;
    using Application.Views;
    using Server.HTTP;

    public class HomeController
    {
        //GET/
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            response.CookieCollection.Add(new HttpCookie("lang", "en"));

            return response;
        }

        public IHttpResponse SessionTest(IHttpRequest req)
        {
            IHttpSession session = req.Session;

            const string sessionDateKey = "saved_date";

            if (session.Get(sessionDateKey) == null)
            {
                session.Add(sessionDateKey, DateTime.UtcNow);
            }
            var response = new ViewResponse(HttpStatusCode.OK, new SessionTestView(session.Get<DateTime>(sessionDateKey)));

            return response;
        }
    }
}
