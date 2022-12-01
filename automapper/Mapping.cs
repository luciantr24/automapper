using System;

namespace automapper
{
    public sealed class Mapping
    {
        public string From { get; private set; }
        public string To { get; private set; }

        public void Add<T, D>()
        {
            ValidateMapping(typeof(T).Name, typeof(D).Name);

            From = typeof(T).Name;
            To = typeof(D).Name;
        }

        private void ValidateMapping(string from, string to)
        {
            if (string.IsNullOrWhiteSpace(from) && string.IsNullOrWhiteSpace(to))
            {
                throw new Exception("Source and Destionation can't be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(from))
            {
                throw new Exception("Source can't be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(to))
            {
                throw new Exception("Destionation can't be null or empty");
            }
        }
    }
}