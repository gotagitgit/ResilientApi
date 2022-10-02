namespace ResilientApi.ConfigSetup
{
    public static class ConfigSetupExtensions
    {
        public static WebApplicationBuilder ConfigureSetup(this WebApplicationBuilder builder)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
                typeof(IConfigSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IConfigSetup>().ToList();

            installers.ForEach(installer => installer.Configure(builder));

            return builder;
        }
    }
}
