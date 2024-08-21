using ASP.Net_Core.Models.Base;

namespace ASP.Net_Core.Models.Binding
{
    public class PersonBinding : PersonBase
    {

    }
    public class PersonUpdateBinding : PersonBase
    {
        public int Id { get; set; }
    }
}
