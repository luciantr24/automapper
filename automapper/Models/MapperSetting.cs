using System;

namespace automapper.Models
{
    public class MapperSetting
    {
        public string From { get; private set; }
        public string To { get; private set; }
        
        public void Add<T, TD>()
        {
            From = typeof(T).Name;
            To = typeof(TD).Name;
        }

        public void CheckMapperSettings()
        {
            if (string.IsNullOrWhiteSpace(From) && string.IsNullOrWhiteSpace(To))
            {
                throw new Exception("Source and Destionation can't be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(From))
            {
                throw new Exception("Source can't be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(To))
            {
                throw new Exception("Destionation can't be null or empty");
            }
        }
    }
}