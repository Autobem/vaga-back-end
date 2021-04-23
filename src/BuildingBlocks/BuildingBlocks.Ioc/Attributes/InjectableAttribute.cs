using System;

namespace BuildingBlocks.Ioc.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectableAttribute : Attribute
    {
        public Lifecicles Lifecicle;

        public InjectableAttribute(Lifecicles lifecicle = Lifecicles.INSTANCE_PER_LIFETIME_SCOPE)
        {
            this.Lifecicle = lifecicle;
        }

    }

    /// <summary>
    /// More about lifecicles in https://autofaccn.readthedocs.io/en/latest/lifetime/instance-scope.html
    /// </summary>
    public enum Lifecicles
    {
        INSTANCE_PER_DEPENDENCY,
        SINGLETON,
        INSTANCE_PER_LIFETIME_SCOPE,
        INSTANCE_PER_MATCHING_LIFETIME_SCOPE,
        INSTANCE_PER_REQUEST,
    }
}
