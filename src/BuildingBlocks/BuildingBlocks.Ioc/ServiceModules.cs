using Autofac;
using BuildingBlocks.Ioc.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;


namespace BuildingBlocks.Ioc
{
    public class ServiceModules : Autofac.Module
    {
        private IConfiguration Configuration { get; }

        public ServiceModules(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        protected override void Load(ContainerBuilder builder)
        {
            var Assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var Assemble in Assemblies)
            {
                foreach (var type in Assemble.GetTypes())
                {
                    //Inject Controller
                    if (type.IsDefined(typeof(ApiControllerAttribute), false))
                    {
                        builder.RegisterType(type)
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired(PropertySelector);

                        //continue;
                    }

                    //Inject per annotation
                    if (type.IsDefined(typeof(InjectableAttribute), false))
                    {
                        var attribute = type.GetCustomAttribute<InjectableAttribute>(false);
                        this.InjectPerLigeContainer(builder, type, attribute.Lifecicle);
                    }
                }
            }

        }

        protected void InjectPerLigeContainer(ContainerBuilder builder, Type type, Lifecicles lifecicle)
        {
            switch (lifecicle)
            {
                case Lifecicles.INSTANCE_PER_DEPENDENCY:

                    builder.RegisterType(type)
                            .AsImplementedInterfaces()
                            .InstancePerDependency()
                            .PropertiesAutowired(PropertySelector);
                    return;

                case Lifecicles.INSTANCE_PER_LIFETIME_SCOPE:

                    if (type.GetInterfaces().Any())
                    {
                        builder.RegisterType(type)
                            .AsImplementedInterfaces()
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired(PropertySelector);

                        return;
                    }

                    builder.RegisterType(type)
                           .InstancePerLifetimeScope()
                           .PropertiesAutowired(PropertySelector);

                    return;
                case Lifecicles.INSTANCE_PER_MATCHING_LIFETIME_SCOPE:
                    builder.RegisterType(type)
                        .AsImplementedInterfaces()
                        .InstancePerMatchingLifetimeScope()
                        .PropertiesAutowired(PropertySelector);

                    return;

                case Lifecicles.INSTANCE_PER_REQUEST:
                    builder.RegisterType(type)
                        .AsImplementedInterfaces()
                        .InstancePerRequest()
                        .PropertiesAutowired(PropertySelector);

                    return;

                case Lifecicles.SINGLETON:
                    if (type.GetInterfaces().Any())
                    {
                        builder.RegisterType(type)
                            .AsImplementedInterfaces()
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired(PropertySelector);

                        return;
                    }

                    builder.RegisterType(type)
                        .SingleInstance()
                        .PropertiesAutowired(PropertySelector);
                    return;
            }
        }
        public bool PropertySelector(PropertyInfo propertyInfo, object instance)
        {
            var attr = propertyInfo.GetCustomAttribute<InjectAttribute>(inherit: true);

            return attr != null && propertyInfo.CanWrite && (propertyInfo.CanRead && propertyInfo.GetValue(instance, null) == null);
        }
    }
}
