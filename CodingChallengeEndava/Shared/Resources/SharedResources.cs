namespace CodingChallengeEndava.Shared.SharedResources
{
    public static class SharedResources
    {
        public const string NewStoriesUrl = "v0/newstories.json";
        public const string StoryUrl = "v0/item/{0}.json?print=pretty";
        public const string StoryCacheKey = "storyCacheKey";
        public const string FailedToRetrieveStoriesErrorMessage = "Failed to retrieve stories";
        public const string HackerNewsApiUrl = "HackerNewsApi:Url";
        public const string CodingChallengeEndavaConnection = "CodingChallengeEndavaConnection";
        public const string UpdateStoriesJob = "UpdateStoriesJob";
        public const string UpdateStoriesJobTrigger = "UpdateStoriesJob-trigger";
        public const string InitialJob = "InitialJob";
        public const string InitialJobTrigger = "InitialJob-trigger";
        public const string CronExpression = "0 0/5 * 1/1 * ? *";
    }
}
