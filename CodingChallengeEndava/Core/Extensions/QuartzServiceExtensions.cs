using CodingChallengeEndava.Core.Jobs;
using CodingChallengeEndava.Shared.SharedResources;
using Quartz;

namespace CodingChallengeEndava.Core.Extensions
{
    public static class QuartzServiceExtensions
    {
        public static void ConfigureQuartz(this IServiceCollection services)
        {
            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
                var initialJobKey = new JobKey(SharedResources.InitialJob);
                options.AddJob<InitialJob>(opt => opt.WithIdentity(initialJobKey));
                options.AddTrigger(opt =>
                {
                    opt.ForJob(initialJobKey)
                        .WithIdentity(SharedResources.InitialJobTrigger)
                        .StartNow();
                });

                var updateStoriesJobKey = new JobKey(SharedResources.UpdateStoriesJob);
                options.AddJob<UpdateStoriesJob>(opt => opt.WithIdentity(updateStoriesJobKey));
                options.AddTrigger(opt =>
                {
                    opt.ForJob(updateStoriesJobKey)
                        .WithIdentity(SharedResources.UpdateStoriesJobTrigger)
                        .WithCronSchedule(SharedResources.CronExpression)
                        .StartNow();
                });
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }
    }
}
