﻿using System;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerUIBuilderExtensions
    {
        private const string EmbeddedFilesNamespace = "ApiDocUi.Browser.dist";

        public static IApplicationBuilder UseSwaggerUI(
            this IApplicationBuilder app,
            Action<SwaggerUIOptions> setupAction = null)
        {
            var options = new SwaggerUIOptions();
            setupAction?.Invoke(options);

            var assembly = typeof(SwaggerUIBuilderExtensions).GetTypeInfo().Assembly;

            app.UseMiddleware<SwaggerUIIndexMiddleware>(options);
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = string.IsNullOrEmpty(options.RoutePrefix) ? string.Empty : $"/{options.RoutePrefix}",
                FileProvider = new EmbeddedFileProvider(typeof(SwaggerUIBuilderExtensions).GetTypeInfo().Assembly, EmbeddedFilesNamespace),
            });

            return app;
        }
    }
}
