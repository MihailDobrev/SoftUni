namespace Logger.Layouts
{
    using System;
    using System.Globalization;

    public class XmlLayout : ILayout
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private string Layout= "<log>" + Environment.NewLine +
                               "\t<date>{0}</date>" + Environment.NewLine +
                               "\t<level>{1}</level>" + Environment.NewLine +
                               "\t<message>{2}</message>" + Environment.NewLine +
                               "</log>";
      
        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Layout, dateString, error.Level.ToString(), error.Message);
            return formattedError;
        }
    }
}
