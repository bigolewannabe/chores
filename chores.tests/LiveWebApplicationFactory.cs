//inspired by good ideas that I stole from https://www.hanselman.com/blog/RealBrowserIntegrationTestingWithSeleniumStandaloneChromeAndASPNETCore21.aspx
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.TestHost;
using System;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System.Linq;

public class LiveWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    public string RootUri { get; set; } //Save this use by tests
 
    IWebHost _host;
 
    public LiveWebApplicationFactory()
    {
        ClientOptions.BaseAddress = new Uri("http://localhost"); //will follow redirects by default
    }
 
    protected override TestServer CreateServer(IWebHostBuilder builder)
    {
        //Real TCP port
        _host = builder.Build();
        _host.Start();
        RootUri = _host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.LastOrDefault(); //Last is https://localhost:5001!
 
        //Fake Server we won't use...this is lame. Should be cleaner, or a utility class
        return new TestServer(new WebHostBuilder().UseStartup<TStartup>());
    }
 
    protected override void Dispose(bool disposing) 
    {
        base.Dispose(disposing);
        if (disposing) {
            _host.Dispose();
        }
    }
}