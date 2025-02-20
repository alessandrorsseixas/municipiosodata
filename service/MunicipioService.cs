using WebApplication1.dto;
using WebApplication1.repository;

namespace WebApplication1.service
{
    public interface IMunicipioService
    {
        IQueryable<MunicipioDto> GetAll();
    }

    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _repository;

        public MunicipioService(IMunicipioRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<MunicipioDto> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
