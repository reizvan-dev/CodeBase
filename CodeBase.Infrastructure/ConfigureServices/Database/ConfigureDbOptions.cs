using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CodeBase.Infrastructure.ConfigureServices.Database
{
    public class ConfigureDbOptions : IConfigureOptions<DbOptions>
    {
        private const string ConfigurationSectionName = "DatabaseOptions";
        private readonly IConfiguration _configuration;

        public ConfigureDbOptions(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DbOptions options)
        {
            var connectionString = _configuration.GetConnectionString("CodeBaseDbConnectionString");

            if (connectionString != null)
            {
                options.ConnectionString = connectionString;

                _configuration.GetSection(ConfigurationSectionName).Bind(options);
            }
        }
    }
}

