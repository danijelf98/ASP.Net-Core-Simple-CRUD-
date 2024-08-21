using ASP.Net_Core_AutoMapper.Models.Base;

namespace ASP.Net_Core_AutoMapper.Models.Binding
{
    public class PersonBinding : PersonBase
    {

    }
    public class PersonUpdateBinding : PersonBase
    {
        public int Id { get; set; }
    }
}
