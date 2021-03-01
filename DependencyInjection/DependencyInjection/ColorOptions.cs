namespace Microsoft.Extensions.DependencyInjection
{
    public class ColorOptions
    {
        public static string Color => nameof(Color);

        public string Red { get; set; }
    }
}