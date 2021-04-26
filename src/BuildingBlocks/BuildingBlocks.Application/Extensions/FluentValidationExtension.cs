using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Application.Extensions
{
    public static class FluentValidationExtension
    {
        public static IMvcBuilder AddFluentValidation(this IMvcBuilder mvcBuilder)
        {
            FluentValidationMvcExtensions.AddFluentValidation(mvcBuilder);
            return mvcBuilder;
        }
    }
}
