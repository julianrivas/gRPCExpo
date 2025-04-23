using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Items.API.Configs;

public static class KestrelConfig
{
    public static void AddKestrelConfig(this IWebHostBuilder builder)
    {
        builder.UseKestrel(options =>
        {
            options.ListenAnyIP(8080, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1;
            });

            options.ListenAnyIP(8081, listenOptions =>
            {
                listenOptions.UseHttps();
                listenOptions.Protocols = HttpProtocols.Http2;
            });
        });
    }
}