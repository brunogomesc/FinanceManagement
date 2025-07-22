using System.Text;
using System.Text.RegularExpressions;

namespace WebApi.Transformers
{
    public class SlugParametersTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object? value)
        {

            StringBuilder transform = new StringBuilder();

            transform.Append(Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLowerInvariant());

            return transform.ToString();

        }
    }
}
