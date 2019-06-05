using System;
using System.Diagnostics;
using System.Threading.Tasks;
using global::NUnit.Framework;
using global::NUnit.Framework.Interfaces;
using global::NUnit.Framework.Internal;
using global::NUnit.Framework.Internal.Commands;

namespace Kata.Tests
{
    /// <summary>
    /// A simple timeout attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TimeoutAttribute : NUnitAttribute, IWrapTestMethod
    {
        private readonly TimeSpan timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeoutAttribute"/> class.
        /// </summary>
        /// <param name="milliseconds">timeout in milliseconds</param>
        public TimeoutAttribute(int milliseconds)
        {
            this.timeout = TimeSpan.FromMilliseconds(milliseconds);
        }

        /// <inheritdoc/>
        public TestCommand Wrap(TestCommand command)
        {
            return new TimeoutCommand(command, this.timeout);
        }

        private class TimeoutCommand : DelegatingTestCommand
        {
            private readonly TimeSpan timeout;

            public TimeoutCommand(TestCommand innerCommand, TimeSpan timeout)
                : base(innerCommand)
            {
                this.timeout = timeout;
            }

            public override TestResult Execute(TestExecutionContext context)
            {
                var t = Task.Run(() => innerCommand.Execute(context));

                try
                {
                    if (!Debugger.IsAttached)
                    {
                        t.TimeoutAfter(timeout).Wait();
                    }

                    return t.Result;
                }
                catch (AggregateException ae)
                {
                    throw ae.InnerException;
                }
            }
        }
    }

    /// <summary>
    /// Task Extension methods
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Timeout a task after a timeout
        /// </summary>
        /// <remarks>https://blogs.msdn.microsoft.com/pfxteam/2011/11/10/crafting-a-task-timeoutafter-method/</remarks>
        /// <param name="task">wrapped task</param>
        /// <param name="timeout">timeout value</param>
        /// <returns>awaitable task</returns>
        public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
        {
            if (task == await Task.WhenAny(task, Task.Delay(timeout)).ConfigureAwait(false))
            {
                await task.ConfigureAwait(false);
            }
            else
            {
                throw new TimeoutException();
            }
        }
    }
}