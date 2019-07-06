using SIS.HTTP.Common;

namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));
            CoreValidator.ThrowIfNull(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; }
        public string Value { get; }

        public override string ToString() => $"{Key}: {Value}";
    }
}
