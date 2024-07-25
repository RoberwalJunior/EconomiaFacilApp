using EconomiaFacilApp.Libraries.Domain.Interfaces.Services.Model;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Repositories.Model;

namespace EconomiaFacilApp.Libraries.Domain.Services.Base;

public abstract class BaseService<T>(IModelRepository<T> repository) : IModelService<T> where T : class
{
    private readonly IModelRepository<T> repository = repository;

    public async Task<IEnumerable<T>> GetModelsAsync()
    {
        return await repository.GetAll();
    }

    public T? GetModelById(int id)
    {
        return repository.GetById(id);
    }

    public async Task<bool> CreateModel(T model)
    {
        return await repository.CreateAsync(model);
    }

    public async Task<bool> UpdateModel(T model)
    {
        return await repository.UpdateAsync(model);
    }

    public async Task<bool> DeleteModel(int id)
    {
        return await repository.DeleteAsync(id);
    }
}
