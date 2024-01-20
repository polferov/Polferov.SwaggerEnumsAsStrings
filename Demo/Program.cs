using System.Text.Json.Serialization;
using Polferov.SwaggerEnumsAsStrings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    // prettier json
    options.SerializerOptions.WriteIndented = true;
    // make enums be (de)serialized as strings
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // register the filter here
    c.AddEnumsAsStringsFilter(
        new EnumsAsStringsFilterOptions // optional
        {
            EnumeratedExample = true,
            MaxExamples = 3
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// serve a cool endpoint with a cool enum in its contracts
app.MapMethods("/cool", ["get", "post"], CoolHandler)
    .Accepts<CoolRequest>("application/json")
    .Produces<CoolResponse>()
    .WithDescription("This is a cool endpoint");


// for ease of use, redirect to swagger when not found
app.MapFallback(ctx =>
{
    ctx.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});

app.Run();
return;

IResult CoolHandler(CoolRequest request)
{
    var resp = new CoolResponse
    {
        OtherCoolEnum = (OtherCoolEnum)((int)request.CoolEnum % 2)
    };
    return Results.Ok(resp);
}

public class CoolRequest
{
    public required CoolEnum CoolEnum { get; set; }
}

public class CoolResponse
{
    public OtherCoolEnum OtherCoolEnum { get; set; }
}

// enum with more than 3 values
public enum CoolEnum
{
    // ReSharper disable global UnusedMember.Global
    Cool,
    VeryCool,
    ExtremelyCool,
    IndescribablyCool,
}

// enum with less than 3 values
public enum OtherCoolEnum
{
    // ReSharper disable global UnusedMember.Global
    OtherCool,
    OtherVeryCool,
}