namespace BuildingBlocks.Application.Queries.List
{
    public abstract class ListResult<TModel>
    {
        public abstract ListResult<TModel> FromModel(TModel model);
    }
}
