namespace Microsoft.Extensions.DependencyInjection
{
    public class PositionOptions
    {
        public static string Position => nameof(Position);

        public float X { get; set; }
        public float Y { get; set; }
    }
}