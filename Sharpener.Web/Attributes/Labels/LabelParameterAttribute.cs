using System;

namespace Sharpener.Web.Attributes.Labels
{
    public abstract class LabelParameterAttribute : Attribute
    {
        private readonly string _value;

        protected LabelParameterAttribute(string value)
        {
            _value = value;
        }

        public abstract string GetHtmlName();
        public string GetValue() { return _value; }
    }
}