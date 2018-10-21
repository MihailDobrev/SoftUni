namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Sessions.Contracts;
    using System;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private IDictionary<string, object> collection;

        public string Id { get; }

        public HttpSession(string id)
        {
            this.Id = id;
            this.collection = new Dictionary<string, object>();
        }

        public void AddParameter(string name, object parameter)
        {
            if (this.ContainsParameter(name))
            {
                throw new ArgumentException();
            }

            collection[name] = parameter;
           
        }

        public void ClearParameters()
        {
            this.collection.Clear();
        }

        public bool ContainsParameter(string name) => this.collection.ContainsKey(name);
      

        public object GetParameter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }

            if (!this.ContainsParameter(name))
            {
                return null;
            }

            return collection[name];
        }
    }
}
