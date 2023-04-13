namespace DIContainer_Demo
{
    public class ShortDate : IDate
    {
        private readonly string _date;
        public ShortDate()
        {
            _date = DateTime.Now.ToShortDateString();
        }

        public string GetDate()
        {
            return _date;
        }
    }
}
