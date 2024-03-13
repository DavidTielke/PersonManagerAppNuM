namespace CrossCutting.Proxies.ExceptionMapping;

public class ExceptionDomainMessage : Attribute
{
    public string DomainMessage { get; set; }

    public ExceptionDomainMessage(string domainMessage)
    {
        DomainMessage = domainMessage;
    }
}