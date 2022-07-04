# OutResp
OutResp is a response wrapper. It provides a response pattern concentrating notifications and validations to use in your workflow.

Package |  Version | Downloads |
| ------- | ----- | ----- |
| `OutResp` | [![NuGet](https://img.shields.io/nuget/v/OutResp.svg)](https://nuget.org/packages/OutResp) | [![Nuget](https://img.shields.io/nuget/dt/OutResp.svg)](https://nuget.org/packages/OutResp) |

### Dependencies
.NET Core 6
 
### Instalation
This package is available through Nuget Packages: https://www.nuget.org/packages/OutResp

**Nuget**
```
Install-Package OutResp
```

**.NET CLI**
```
dotnet add package OutResp
```

## How to use
```csharp
public IOutResp ValidateName(string name)
{
    if(string.IsNullOrEmpty(name))
        return OutRespContract
            .Failure<dynamic>()
            .AddStatusCode(HttpStatusCode.BadRequest)
            .AddMessage("Invalid name.");


    return OutRespContract
        .Success<dynamic>()
        .AddStatusCode(HttpStatusCode.OK)
        .AddMessage("Valid name.")
        .AddValue(
            new
            {
                Data = ...
            });
}
```

Check out our [Getting started guide](https://github.com/LuizFelipeA/OutResp/wiki/Getting-started) of how to use OutResp in your application and get the most out of it!

OutResp is Copyright © 2022 Luiz Felipe, and other contributors under the MIT license.
