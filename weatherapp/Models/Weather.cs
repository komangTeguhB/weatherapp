namespace weatherapp.Models
{
    public class Weather
    {
        public string Location { get; set; }
        public string Time { get; private set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyCondition  { get; set; }
        public string TemperatureC { get; set; }
        public string TemperatureF { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure  { get; set; }

        public Weather()
        {
            DateTime _today = DateTime.Now;
            Time = _today.ToString("MM/dd/yyyy h:mm tt");
        }
    }
}
