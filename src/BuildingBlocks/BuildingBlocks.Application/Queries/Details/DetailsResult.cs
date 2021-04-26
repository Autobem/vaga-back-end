namespace BuildingBlocks.Application.Queries.Details
{
    public abstract class DetailsResult<TModel>
    {
        public abstract DetailsResult<TModel> FromModel(TModel model);
    }
}
