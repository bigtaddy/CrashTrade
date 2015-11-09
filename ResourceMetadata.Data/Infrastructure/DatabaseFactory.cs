using ResourceMetadata.Data;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Infrastructure 
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private ResourceManagerContext dataContext;
    public ResourceManagerContext Get()
    {
        return dataContext ?? (dataContext = new ResourceManagerContext());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
