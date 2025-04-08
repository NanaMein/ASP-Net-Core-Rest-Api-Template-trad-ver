
namespace RestApiTemplate.Api.ValueGenerators
{
    //public class ValueGenerator
    //{
    //}

    public class DateOnlyValue : IDateOnlyValue
    {
        public DateOnly GenerateValue()
        {
            DateOnly value = DateOnly.FromDateTime(DateTime.UtcNow);
            return value;
        }
    }

    public class DateTimeValue : IDateTimeValue
    {
        public DateTime GenerateValue()
        {
            return DateTime.UtcNow;
        }
    }
}
