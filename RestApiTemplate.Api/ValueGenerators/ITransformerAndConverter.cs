namespace RestApiTemplate.Api.ValueGenerators
{
    public interface ITransformerAndConverter
    {
        //string Convert(Guid value);
        //Guid Convert(string value);
        //Guid Converts(Guid value);
        (Guid, bool) GuidChecker(Guid guid);
    }


    public interface INullableGuidConverter : ITransformerAndConverter
    { 
        
    }

    public class NullableGuidConverter : INullableGuidConverter
    {
        public string Convert(Guid value)
        {
            Guid _value = value;
            string guidString = _value.ToString();
            return guidString;



            //Guid? nullableGuid = value;
            //string guidString = nullableGuid.Value.ToString();
            //Guid guid = Guid.Parse(guidString);
            //return guid;
        }

        public Guid Convert(string value)
        {
            Guid guid = Guid.Parse(value);
            return guid;
        }

        public Guid Converts(Guid? value)
        {
            Guid? nullableGuid = value;
            string guidString = nullableGuid.Value.ToString();
            Guid guid = Guid.Parse(guidString);
            return guid;
        }

        public Guid Converts(Guid value)
        {
            throw new NotImplementedException();
        }

        public (Guid,bool) GuidChecker(Guid guid)
        {
            try
            {
                Guid? nullableGuid = guid;
                string guidString = nullableGuid.Value.ToString();
                Guid _guid = Guid.Parse(guidString);
                return (_guid, true);
            }
            catch { return (guid, false); }
        }
    }
}
