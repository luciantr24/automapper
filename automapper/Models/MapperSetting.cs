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
    }
}