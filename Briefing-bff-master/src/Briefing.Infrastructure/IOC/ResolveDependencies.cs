using Briefing.Domain.Interfaces.Mediatrs;
using Briefing.Domain.Mediatrs;
using Briefing.Infrastructure.AutoMapper;
using Briefing.Infrastructure.Swagger;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Briefing.Domain.Interfaces.Repositories;
using Briefing.Infrastructure.Data.Repositories;
using Briefing.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Briefing.Application.Commands;
using Briefing.Application.Queries;

namespace Briefing.Infrastructure.IOC
{
    [ExcludeFromCodeCoverage]
    public static class ResolveDependencies
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.SwaggerAdd();

            services.AddScoped<IPerguntaQueries, PerguntaQueries>();
            services.AddScoped<IRespostaQueries, RespostaQueries>();
            
            services.AddScoped<IRequestHandler<AdicionarPerguntaCommand,bool>, PerguntaCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarRespostaCommand,bool>, RespostaCommandHandler>();

            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IRespostaRepository, RespostaRepository>();
            services.AddDbContext<QuizContext>(options => options.UseSqlServer(configuration.GetConnectionString("BriefingConnection")));
            services.AddAutoMapper(
                typeof(ViewModelToCommandMappingProfile),
                typeof(ViewModelToDomainMappingProfile));

            var assembly = AppDomain.CurrentDomain.Load("Briefing.Application");
            services.AddMediatR(assembly);
            services.AddTransient<IMediatrHandler, MediatrHandler>();

            return services;
        }
        public static IApplicationBuilder Register(this IApplicationBuilder app)
        {
            app.SwaggerAdd();
            return app;
        }
    }
}
