using System.Linq;

// https://www.hackerrank.com/challenges/new-year-chaos/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

namespace InterviewPreparationKit
{
    public class BribeCounter
    {
        private const string TooChaotic = "Too chaotic";

        private readonly int _maxBribeCountForPerson;

        private int _bribeCount;
        private int _pointer;
        private Person[] _queue;

        public BribeCounter(int maxBribeCountForPerson)
        {
            _maxBribeCountForPerson = maxBribeCountForPerson;
        }

        public string CountMinimumBribesForQueue(int[] q)
        {
            Initialize(q);

            return GetMinimumBribeCountOrTooChaotic();
        }

        private void Initialize(int[] q)
        {
            _queue = BuildQueue(q);
            _bribeCount = 0;
            _pointer = 0;
        }

        private static Person[] BuildQueue(int[] q)
        {
            return q.Select((x, i) => new Person
            {
                PlaceNumber = i + 1,
                TicketNumber = q[i]
            }).ToArray();
        }

        private string GetMinimumBribeCountOrTooChaotic()
        {
            if (_queue.Any(x => x.Distance < -_maxBribeCountForPerson)) return TooChaotic;

            while (true)
            {
                var queueStatus = UndoBribeInQueue();
                if (queueStatus == QueueStatus.Sorted) break;
            }

            return _bribeCount.ToString();
        }

        private QueueStatus UndoBribeInQueue()
        {
            while (_pointer < _queue.Length && _queue[_pointer].Distance <= 0) _pointer++;

            if (_pointer == _queue.Length) return QueueStatus.Sorted;

            var person1 = _queue[_pointer];
            var person2 = _queue[_pointer - 1];

            SwapPersons(person1, person2);

            _pointer--;
            _bribeCount++;

            return QueueStatus.Unsorted;
        }

        private static void SwapPersons(Person person1, Person person2)
        {
            var t = person1.TicketNumber;
            person1.TicketNumber = person2.TicketNumber;
            person2.TicketNumber = t;
        }

        private enum QueueStatus
        {
            Sorted,
            Unsorted
        }

        private class Person
        {
            public int TicketNumber { get; set; }
            public int PlaceNumber { get; set; }

            public int Distance => PlaceNumber - TicketNumber;
        }
    }
}