namespace DIContainer_Demo
{
    public class Time : IDateTime
    {
        private readonly string _time;

        public Time()
        {
            _time = DateTime.Now.ToString();
        }

        public string GetDate()
        {
            return _time;
        }
    }
}
