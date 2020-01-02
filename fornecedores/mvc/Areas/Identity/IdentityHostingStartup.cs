using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mvc.Context;

[assembly: HostingStartup(typeof(mvc.Areas.Identity.IdentityHostingStartup))]
namespace mvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlite("Data Source=fornecedores.db"));

                services.AddDefaultIdentity<AppIdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddErrorDescriber<IdentityErrorDescriberPtBr>()
                .AddEntityFrameworkStores<IdentityDbContext>();
            });
        }

        internal class IdentityErrorDescriberPtBr : IdentityErrorDescriber
        {
            public override IdentityError PasswordRequiresNonAlphanumeric()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresNonAlphanumeric),
                    Description = "A senha deve ter pelo menos um caractere numérico"
                };
            }

            public override IdentityError PasswordRequiresLower()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresLower),
                    Description = "A senha deve ter pelo menos uma letra minúscula"
                };
            }

            public override IdentityError PasswordRequiresUpper()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresUpper),
                    Description = "A senha deve ter pelo menos uma letra maiúscula"
                };
            }
        }
    }
}