using Microsoft.Extensions.DependencyInjection;
using PetPlayBackend.Domain.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Common.Helpers
{
    public static class Binder
    {
        public static void BindContext(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
