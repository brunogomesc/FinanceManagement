using Application.Abstractions.Ports.Handlers;
using Application.Contracts;
using Application.Modules.Accounts.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationLayerDependency
    {

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<Command.CreateAccountCommand>, CreateAccountHandler>();
        }

    }
}
