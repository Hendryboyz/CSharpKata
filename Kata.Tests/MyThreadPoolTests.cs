using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

// https://www.codewars.com/kata/the-supermarket-queue
namespace Kata.Tests
{
    [TestFixture]
    public class MyThreadPoolTests
    {
        private MyThreadPool pool;

        [Test]
        public void CanCreate()
        {
            pool = new MyThreadPool();
            pool.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanCheckQueueTime()
        {
            int times = pool.CheckQueueTime(new int[] { }, 1);
            times.Should().Be(0);
        }

        [Test]
        public void GivenThreeTaskAndOneThread_ThenCheckQueueTime_ThenReturnTimeSummary()
        {
            int times = pool.CheckQueueTime(new int[] { 10, 2, 3 }, 1);
            times.Should().Be(15);
        }

        [TestCase(new int[] { 10, 2 }, 2, 10)]
        [TestCase(new int[] { 2, 3, 10 }, 2, 12)]
        public void GivenTwoThreadAndTwoTasks_ThenCheckQueueTime_ThenReturnTotalTimes(
            int[] taskArray, int threadNumber, int expected)
        {
            int times = pool.CheckQueueTime(taskArray, threadNumber);
            times.Should().Be(expected);
        }

        [Test]
        public void GivenTwoThreadAndOrderedTasks_ThenCheckQueueTime_ThenReturnTotalTimes()
        {
            int times = pool.CheckQueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2);
            times.Should().Be(9);
        }

        [Test]
        public void GivenThreeThreadAndThreeTasks_ThenCheckQueueTime_ThenReturnTotalTimes()
        {
            int times = pool.CheckQueueTime(new int[] { 5, 2, 3 }, 3);
            times.Should().Be(5);
        }
    }
}
