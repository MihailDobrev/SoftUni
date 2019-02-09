using System;
using System.Collections.Generic;
using System.Linq;

namespace TextEditor
{
    public class TextEditor : ITextEditor
    {
        private Trie<Stack<string>> trie;
        private List<string> loggedUsers;
        private List<string> allUsers;

        public TextEditor()
        {
            this.trie = new Trie<Stack<string>>();
            this.loggedUsers = new List<string>();
            this.allUsers = new List<string>();
        }


        public void Login(string username)
        {
            if (!this.allUsers.Contains(username))
            {
                this.trie.Insert(username, new Stack<string>());
                this.trie.GetValue(username).Push(String.Empty);
                this.allUsers.Add(username);
            }

            if (!this.loggedUsers.Contains(username))
            {
                this.loggedUsers.Add(username);
            }
            else
            {
                this.trie.Insert(username, new Stack<string>());
                this.trie.GetValue(username).Push(String.Empty);
            }
        }

        public void Logout(string username)
        {
            this.loggedUsers.Remove(username);
            this.trie.GetValue(username).Push(String.Empty);

        }

        public void Prepend(string username, string str)
        {
            if (this.loggedUsers.Contains(username))
            {
                str = str.Substring(1, str.Length - 2);
                var oldValue = this.trie.GetValue(username).Peek();
                this.trie.GetValue(username).Push(str + oldValue);
            }
        }

        public void Insert(string username, int index, string str)
        {
            if (this.loggedUsers.Contains(username))
            {
                var oldValue = this.trie.GetValue(username).Peek();

                if (oldValue.Length >= index)
                {
                    str = str.Substring(1, str.Length - 2);
                    var newValue = oldValue.Insert(index, str);
                    this.trie.GetValue(username).Push(newValue);
                }
            }
        }

        public void Substring(string username, int startIndex, int length)
        {
            if (this.loggedUsers.Contains(username))
            {
                string oldValue = this.trie.GetValue(username).Peek();
                if (oldValue.Length > startIndex + length)
                {
                    this.trie.GetValue(username).Push(oldValue.Substring(startIndex, length));
                }
            }
        }

        public void Delete(string username, int startIndex, int length)
        {
            if (this.loggedUsers.Contains(username))
            {
                var oldValue = this.trie.GetValue(username).Peek();

                if (oldValue.Length >= startIndex + length)
                {
                    var newValue = oldValue.Substring(0, startIndex) + oldValue.Substring(startIndex + length);
                    this.trie.GetValue(username).Push(newValue);
                }
            }
        }

        public void Clear(string username)
        {
            if (this.loggedUsers.Contains(username))
            {
                this.trie.GetValue(username).Push(String.Empty);
            }
        }

        public int Length(string username)
        {
            if (this.loggedUsers.Contains(username))
            {
                return this.trie.GetValue(username).Peek().Length;
            }

            return 0;
        }

        public string Print(string username)
        {
            if (this.loggedUsers.Contains(username))
            {
                return this.trie.GetValue(username).Peek();
            }

            return null;
        }

        public void Undo(string username)
        {
            if (this.loggedUsers.Contains(username))
            {
                if (this.trie.GetValue(username).Count > 1)
                {
                    this.trie.GetValue(username).Pop();
                }
            }
        }

        public IEnumerable<string> Users(string prefix = "")
        {
            return this.trie.GetByPrefix(prefix)
                       .Where(this.loggedUsers.Contains)
                       .OrderBy(this.loggedUsers.IndexOf);
        }

        public IEnumerable<string> GetLoggedUsers()
        {
            return this.loggedUsers;
        }
    }
}

