namespace LR3
{
    public class TimeService
    {
        public string GetDayTime() 
        {
            if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 18) return $"Time: {DateTime.Now.ToShortTimeString()}, it's DAY";
            else if (DateTime.Now.Hour > 18 && DateTime.Now.Hour <= 23) return $"Time: {DateTime.Now.ToShortTimeString()}, it's EVENING";
            else if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 6) return $"Time: {DateTime.Now.ToShortTimeString()}, it's NIGHT";
            else if (DateTime.Now.Hour > 6 && DateTime.Now.Hour <= 12) return $"Time: {DateTime.Now.ToShortTimeString()}, it's MORNING";
            return "";
        }
    }
}
