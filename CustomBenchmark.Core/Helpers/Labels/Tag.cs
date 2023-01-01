namespace CustomBenchmark.Core.Helpers.Labels
{

    public static class Tag
    {
        public static Dictionary<TagType, string> Tags = new Dictionary<TagType, string>()
        {
            { TagType.Stop,"[Stop]" },
            { TagType.Start,"[Start]" },
            { TagType.Other,"[Other]" },
        };
    }
    public enum TagType
    {
        Stop,
        Start,
        Other
    }
}
