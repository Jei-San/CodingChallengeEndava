using CodingChallengeEndava.Core.IServices;
using Quartz;

namespace CodingChallengeEndava.Core.Jobs
{
    public class InitialJob : IJob
    {
        private readonly IStoryService storyService;

        public InitialJob(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await storyService.SyncStoriesAsync();
        }
    }
}
