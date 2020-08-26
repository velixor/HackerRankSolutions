using NUnit.Framework;

namespace InterviewPreparationKit.Tests
{
    [TestFixture]
    public class BribeCounterTests
    {
        private BribeCounter _bribeCounter;

        [SetUp]
        private void SetUp()
        {
            _bribeCounter = new BribeCounter(2);
        }

        [Test]
        [TestCase(new[] {2, 1, 5, 3, 4}, "3")]
        [TestCase(new[] {2, 5, 1, 3, 4}, "Too chaotic")]
        [TestCase(new[] {5, 1, 2, 3, 7, 8, 6, 4}, "Too chaotic")]
        [TestCase(new[] {1, 2, 5, 3, 7, 8, 6, 4}, "7")]
        public void CountMinimumBribesForQueue(int[] queue, string answer)
        {
            var minBribes = _bribeCounter.CountMinimumBribesForQueue(queue);

            Assert.That(minBribes, Is.EqualTo(answer));
        }
    }
}