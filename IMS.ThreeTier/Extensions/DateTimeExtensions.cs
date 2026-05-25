namespace IMS.WEB.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToUiDate(
            this DateTime date)
        {
            return date.ToString(
                "dd/MM/yyyy HH:mm");
        }

        public static string ToUiDate(
            this DateTime? date)
        {
            if (!date.HasValue)
                return "-";

            return date.Value.ToString(
                "dd/MM/yyyy HH:mm");
        }
    }
}