using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Infrastructure.CrossCutting.IoC
{
    public class ModuleIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoC.Load(builder);
        }
    }
}
