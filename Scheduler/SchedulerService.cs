using Quartz;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Quartz.Spi;
using Quartz.Impl;
using OnboardingEcomindo.Scheduler.Jobs;
using Quartz.Impl.Matchers;

namespace OnboardingEcomindo.Scheduler
{
    public class SchedulerService : IHostedService
    {
        private readonly IScheduler _scheduler;

        public SchedulerService(IJobFactory quartzJobFactory)
        {
            StdSchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            _scheduler.JobFactory = quartzJobFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            InitiateScheduler();
            await _scheduler.Start(cancellationToken);
        }

        private void InitiateScheduler()
        {
            AddJob<LogTimeJob>();
        }

        private void AddJob<T>() where T : IJob
        {

            string jobName = typeof(T).Name;
            string groupName = jobName + "Group";
            string triggerName = jobName + "Trigger";

            IJobDetail jobDetail = 
                JobBuilder
                .Create<T>()
                .WithIdentity(jobName, groupName)
                .Build();

            ITrigger trigger = 
                TriggerBuilder
                .Create()
                .WithIdentity(triggerName, groupName)
                .WithSimpleSchedule(
                    x => 
                    x.WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            _scheduler.ScheduleJob(jobDetail, trigger);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_scheduler.IsStarted)
            {
                await _scheduler.Standby();
            }

            System.Collections.Generic.IReadOnlyCollection<JobKey> jobKeys = _scheduler
                .GetJobKeys(GroupMatcher<JobKey>.AnyGroup())
                .GetAwaiter()
                .GetResult();

            foreach (JobKey jobKey in jobKeys)
            {
                _ = _scheduler.Interrupt(jobKey);
            }

            _scheduler
                .Shutdown(true)
                .GetAwaiter()
                .GetResult();

        }
    }
}
