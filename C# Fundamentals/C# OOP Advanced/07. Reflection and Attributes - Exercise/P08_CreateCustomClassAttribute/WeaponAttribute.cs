namespace P08_CreateCustomClassAttribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class WeaponAttribute : Attribute
    {
        private string author;
        private int revision;
        private string description;
        private List<string> reviewers;

        public WeaponAttribute(string author, int revision, string description, params string[] reviewers )
        {
            this.author = author;
            this.revision = revision;
            this.description = description;
            this.reviewers = new List<string>(reviewers.ToList());
        }

        public string PrintInfo(string field)
        {
            string joined = (string.Join(", ", this.reviewers)).ToString();
            string outputResult = (field == "Reviewers") ? ($"Reviewers: {joined}") : string.Empty;

            outputResult = (field == "Description") ? ($"Class description: {this.description}") : outputResult;

            if (outputResult == string.Empty)
            {
                var fieldToTake = typeof(WeaponAttribute).GetFields(BindingFlags.NonPublic| BindingFlags.Instance).FirstOrDefault(p => p.Name == field.ToLower());
                var fieldValue = fieldToTake.GetValue(this);
                outputResult = $"{field}: {fieldValue}";
            }

            return outputResult;
        }
    }
}