global using FastEndpoints;
using FastEndpoints.Swagger;
using Kayord.Pos.Common.Extensions;
using Kayord.Pos.Services;
using KayordKit.Extensions.Api;
using KayordKit.Extensions.Cors;
using KayordKit.Extensions.Health;
using KayordKit.Extensions.Host;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddLoggingConfiguration(builder.Configuration);
// builder.Services.ConfigureApi();
builder.Services.AddFastEndpoints();
builder.Services.AddFastEndpoints()
        .SwaggerDocument(o =>
        {
            o.DocumentSettings = s =>
            {
                s.Title = AppDomain.CurrentDomain.FriendlyName;
                s.Version = "v1";
                // s.MarkNonNullablePropsAsRequired();
                // s.OperationProcessors.Add(new CustomOperationsProcessor());
                // s.SchemaSettings.SchemaNameGenerator = new CustomSchemaNameGenerator();
            };
        });
builder.Services.ConfigureHealth(builder.Configuration);
// TODO: Move url to config
builder.Services.ConfigureCors(["http://localhost:5173"]);

builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.ConfigureEF(builder.Configuration);

builder.Services.AddHostedService<MigratorHostedService>();
builder.Services.AddSingleton<CurrentUserService>();

var app = builder.Build();

app.UseApi();
app.UseCorsKayord();
app.UseHealth();
app.Run();