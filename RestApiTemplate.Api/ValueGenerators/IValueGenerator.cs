namespace RestApiTemplate.Api.ValueGenerators
{
    public interface IValueGenerator<T>
    {
        T GenerateValue();
    }

    public interface IDateOnlyValue : IValueGenerator<DateOnly> { }

    public interface IDateTimeValue : IValueGenerator<DateTime> { }






















}
