using Application.Abstraction.Behaviors;
using Application.Abstraction.Factories;
using Application.Abstraction.Messaging;
using Application.DomainEvents;
using Application.Time;
using Application.Entity.Handlers;
using Domain.Primitives;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Application.Abstraction.Services;
using Application.Services;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjection))
                //.AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                //    .AsImplementedInterfaces()
                //    .WithScopedLifetime()
                //.AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                //    .AsImplementedInterfaces()
                //    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.Decorate(typeof(ICommandHandler<,>), typeof(ValidationDecorator.CommandHandler<,>));
            //services.Decorate(typeof(ICommandHandler<>), typeof(ValidationDecorator.CommandBaseHandler<>));

            //services.Decorate(typeof(IQueryHandler<,>), typeof(LoggingDecorator.QueryHandler<,>));
            services.Decorate(typeof(ICommandHandler<,>), typeof(LoggingDecorator.CommandHandler<,>));
            //services.Decorate(typeof(ICommandHandler<>), typeof(LoggingDecorator.CommandBaseHandler<>));

            services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjection))
                .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

            services
                .AddProcessFactories()
                .AddServices();

            return services;
        }

        private static IServiceCollection AddProcessFactories(this IServiceCollection services)
        {
            services.AddScoped<IUserProcessFactory, UserProcessFactory>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IDomainEventsDispatcher, DomainEventsDispatcher>();
            services.AddScoped<IAppLogService, AppLogService>();

            return services;
        }
    }
}
