namespace CustomBenchmark.Helper
{

    public static class Tag
    {
        public static Dictionary<TagType, string> Tags = new Dictionary<TagType, string>()
        {
            { TagType.Stop,"[Stop]" },
            { TagType.Start,"[Start]" },
        };
    }
    public enum TagType
    {
        Stop,
        Start
    }
}
