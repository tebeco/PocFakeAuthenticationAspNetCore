using System;

namespace LogAsCode
{
    public class CircuitBreakerConfiguration
    {
        public int ErrorNumberBeforeSwitchOff { get; set; } = 3;

        public TimeSpan DelayBeforeRetry { get; set; } = TimeSpan.FromSeconds(15);

    }
}
