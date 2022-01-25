## Docker Certificate Authority Spike

Determining the best way to inject my CA certificate in to a Docker container.  This is the only way to verify https requests.

To accomplish this there will be two containers:

1. Weather forecast API

> This will be the default `webapi` dotnet template that responds to the endpoint `GET /weatherforecast`, and will have a valid certificate.

2. API

> This will expose an endpoint that relays the response from the Weather Forecast API.  This will also have a valid certificate, but also the CA certificate so it can verify the responses from the Weather Forecast API.

### Regular Certificates

Regular certificates are used by the web server (codename: Kestrel) to legitimize responses.

They're of a crt/key format, and are injected into Kestrel via two configuration entries:

|Key|Value|
|-|:-:|
|Kestrel:Certificates:Default:KeyPath|`/path/to/localhost.key`|
|Kestrel:Certificates:Default:Path|`/path/to/localhost.crt`|

### Certificate Authority Certificates

These are used by the OS to verify legitimacy of responses, and are just of .crt format.

They are copied to the directory `/usr/local/share/ca-certificates/` and the command `update-ca-certificates` is run to install them.
