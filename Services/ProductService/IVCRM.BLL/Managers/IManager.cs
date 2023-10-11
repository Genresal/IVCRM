using IVCRM.Core.Models.Common;

namespace IVCRM.BLL.Managers;
public interface IManager<TModel>
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken);
    Task<PagedResponse<TModel>> GetPagedAsync(SortedRequest request, CancellationToken cancellationToken);
    Task<TModel> GetDetailsAsync(long id, CancellationToken cancellationToken);
    Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken);
    Task DeleteAsync(long id, CancellationToken cancellationToken);
}
