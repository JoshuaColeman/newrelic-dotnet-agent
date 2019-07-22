﻿using System;
using NewRelic.Agent.Core.DataTransport;
using NewRelic.Agent.Core.Events;
using NewRelic.Agent.Core.Time;
using NewRelic.Agent.Core.Utilities;
using NewRelic.SystemInterfaces;

namespace NewRelic.Agent.Core.Aggregators
{
	public abstract class AbstractAggregator<T> : ConfigurationBasedService
	{
		protected readonly IDataTransportService DataTransportService;
		private readonly IScheduler _scheduler;
		private readonly IProcessStatic _processStatic;
		private readonly TimeSpan _harvestCycle = TimeSpan.FromMinutes(1);

		protected AbstractAggregator(IDataTransportService dataTransportService, IScheduler scheduler, IProcessStatic processStatic)
		{
			DataTransportService = dataTransportService;
			_scheduler = scheduler;
			_processStatic = processStatic;

			_scheduler.ExecuteEvery(Harvest, _harvestCycle);

			_subscriptions.Add<PreCleanShutdownEvent>(OnPreCleanShutdown);
		}

		public abstract void Collect(T wireModel);

		protected abstract void Harvest();

		private void OnPreCleanShutdown(PreCleanShutdownEvent obj)
		{
			_scheduler.StopExecuting(Harvest, TimeSpan.FromSeconds(2));

			if (!_configuration.CollectorSendDataOnExit)
				return;

			var uptime = DateTime.Now - _processStatic.GetCurrentProcess().StartTime;
			if (!(uptime.TotalMilliseconds > _configuration.CollectorSendDataOnExitThreshold))
				return;

			Harvest();
		}

		public override void Dispose()
		{
			base.Dispose();
			_scheduler.StopExecuting(Harvest);
		}
	}
}
