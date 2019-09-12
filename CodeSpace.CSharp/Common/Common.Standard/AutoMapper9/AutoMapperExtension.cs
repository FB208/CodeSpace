using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Common.Standard.AutoMapper9
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection service)
        {
            service.TryAddSingleton<MapperConfigurationExpression>();
            service.TryAddSingleton(serviceProvider =>
            {
                var mapperConfigurationExpression = serviceProvider.GetRequiredService<MapperConfigurationExpression>();
                var instance = new MapperConfiguration(mapperConfigurationExpression);

                instance.AssertConfigurationIsValid();

                return instance;
            });
            service.TryAddSingleton(serviceProvider =>
            {
                var mapperConfiguration = serviceProvider.GetRequiredService<MapperConfiguration>();

                return mapperConfiguration.CreateMapper();
            });

            return service;
        }

        public static IMapperConfigurationExpression UseAutoMapper(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.ApplicationServices.GetRequiredService<MapperConfigurationExpression>();
        }
        public static void UseAutoInject(this IApplicationBuilder applicationBuilder, params Assembly[] assemblys)
        {
            var factory = applicationBuilder.ApplicationServices.GetRequiredService<AutoInjectFactory>();
            factory.AddAssemblys(assemblys);
        }
    }
}
