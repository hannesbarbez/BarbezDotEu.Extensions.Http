# BarbezDotEu.Extensions.Http

Misc. extensions to `Microsoft.Extensions.Http`.

## Purpose and use

This package introduces a variant of `ConfigurePrimaryHttpMessageHandler` which allows for its use in conjunction with <u>unnamed</u> `HttpClient`s, like so:

```cs
services.AddHttpClient()
    .ConfigurePrimaryHttpMessageHandler(() => 
        new HttpClientHandler 
        { 
            UseCookies = true, 
            CookieContainer = new CookieContainer() 
        });
```

This is different from the *original* variant of `ConfigurePrimaryHttpMessageHandler` from `Microsoft.Extensions.Http`, which only allows for its use in conjunction with <u>named</u> `HttpClient`s, for example:

```cs
services.AddHttpClient("NamedClient")
    .ConfigurePrimaryHttpMessageHandler(() => 
        new HttpClientHandler 
        { 
            UseCookies = true, 
            CookieContainer = new CookieContainer() 
        });
```


