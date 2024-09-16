using CodingChallengeEndava.Core.IServices;
using Quartz;

namespace CodingChallengeEndava.Core.Jobs
{
    public class UpdateStoriesJob : IJob
    {
        private readonly IStoryService storyService;

        public UpdateStoriesJob(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await storyService.SyncStoriesAsync();
        }
    }
}
