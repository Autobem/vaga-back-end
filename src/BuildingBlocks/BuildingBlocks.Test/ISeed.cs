using System.Collections.Generic;

namespace BuildingBlocks.Test
{
    public interface ISeed<TModel>
    {
        public TModel[] GetSeed();
    }
}
