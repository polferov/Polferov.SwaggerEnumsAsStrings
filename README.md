# Polferov.SwaggerEnumsAsStrings

A simple library to convert/display enums as strings in Swagger UI.

## Installation

Install the NuGet package:

```bash
# e.g. using dotnet CLI
dotnet add package Polferov.SwaggerEnumsAsStrings
```

or visit
the [Polferov.SwaggerEnumsAsStrings NuGet page](https://www.nuget.org/packages/Polferov.SwaggerEnumsAsStrings/).

## Usage

```csharp
using Polferov.SwaggerEnumsAsStrings;

builder.Services.AddSwaggerGen(c =>
{
    //...
    
    // basic registration
    c.AddEnumsAsStringsFilter();
    
    // or with custom options
    c.AddEnumsAsStringsFilter(new EnumsAsStringsFilterOptions
    {
        //...
    });
});
```

Please refer to [EnumsAsStringsFilterOptions](./Polferov.SwaggerEnumsAsStrings/EnumsAsStringsFilterOptions.cs) for
available options.