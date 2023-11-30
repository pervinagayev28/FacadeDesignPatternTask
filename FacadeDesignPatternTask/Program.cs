
using System.Threading.Channels;



abstract class ConnectingWebSite
{
    public string WebSite { get; set; }

    protected ConnectingWebSite(string webSite)
    {
        WebSite = webSite;
    }
}
class CheckWebSite : ConnectingWebSite
{
    public CheckWebSite(string website) : base(website) { }

    //some checking on WebSite property
    public bool Check() => WebSite != null;
}

class SendRequest : ConnectingWebSite
{

    public SendRequest(string website) : base(website) { }


    //sneding a request to website
    public bool Send() => true;
}

class GetHtml : ConnectingWebSite
{
    public GetHtml(string website) : base(website) { }

    public void Get() => Console.WriteLine($"Welcome to {WebSite}");
}


class GetWebSiteFacade
{
    private CheckWebSite? checkConnection;
    private SendRequest? sendRequest;
    private GetHtml? getHtml;

    public GetWebSiteFacade(string website)
    {
        checkConnection = new(website);
        sendRequest = new(website);
        getHtml = new(website);
    }


    public void GetWebsite()
    {
        if (checkConnection!.Check())
            if (sendRequest!.Send())
                getHtml!.Get();

    }



}

//**************************************************

class Program
{
    static void Main(string[] args)
    {
        GetWebSiteFacade google = new("google");
        google.GetWebsite();
    }
}

