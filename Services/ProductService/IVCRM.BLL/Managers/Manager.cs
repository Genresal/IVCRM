using AutoMapper;
using IVCRM.BLL.Models;
using IVCRM.Core.Constants;
using IVCRM.Core.Enums;
using IVCRM.Core.Exceptions;
using IVCRM.Core.Extensions;
using IVCRM.Core.Models.Common;
using IVCRM.DAL.Entities.Core;
using IVCRM.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace IVCRM.BLL.Managers;

public class Manager<TModel, TEntity> : IManager<TModel> where TEntity : Entity where TModel : Model
{
    private readonly ILogger<Manager<TModel, TEntity>> _logger;
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public Manager(ILogger<Manager<TModel, TEntity>> logger,
        IRepository<TEntity> repository,
        IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<PagedResponse<TModel>> GetPagedAsync(SortedRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Try to get entities list, page: {page}", request.Page);

        (var sortExpression, bool ascOrder) = GetOrderByExpression(request);

        var result = await _repository.PagedFindAsync<TModel, object>(
            request.Page,
            request.PageSize,
            null,
            sortExpression,
            ascOrder,
            cancellationToken);

        return result;
    }

    public virtual async Task<TModel> GetDetailsAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await GetAsync(id, cancellationToken);

        return _mapper.Map<TModel>(entity);
    }

    public virtual async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Try to create new Entity");

        var entity = _mapper.Map<TEntity>(model);
        await _repository.AddAsync(entity, cancellationToken: cancellationToken);

        _logger.LogInformation("Created successfully");

        return await GetDetailsAsync(entity.Id, cancellationToken);
    }

    public async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Try to update existing entity. entity ID : {ID}", model.Id);

        var entity = await GetAsync(model.Id, cancellationToken);
        _repository.Detach(entity);

        var updatedEntity = _mapper.Map<TEntity>(model);
        await _repository.UpdateAsync(updatedEntity, cancellationToken: cancellationToken);

        _logger.LogInformation("Updated successfully");

        return await GetDetailsAsync(updatedEntity.Id, cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Try to delete by id: {ID}", id);

        var category = await GetAsync(id, cancellationToken);

        await _repository.DeleteAsync(category, cancellationToken: cancellationToken);
    }

    // Private methods

    private async Task<TEntity> GetAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await _repository.FirstOrDefaultAsync<TEntity>(x => x.Id == id, null, true, cancellationToken);

        if (entity is null)
        {
            _logger.LogWarning("Unable to find entity with id: {id}", id);
            throw new WebApiException(ErrorCodes.INVALID_INPUTS);
        }

        return entity;
    }

    private static (Expression<Func<TEntity, object>>, bool) GetOrderByExpression(SortedRequest request)
    {
        var orderByClause = request.GetFirstOrderByClause();

        // default order
        Expression<Func<TEntity, object>> sortExpression = x => x.Id;

        var isAscending = orderByClause.Value == SortOrder.Ascending;

        return (sortExpression, isAscending);
    }
}
