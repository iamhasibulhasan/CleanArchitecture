﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuraion =>
        configuraion.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);



        return services;
    }
}