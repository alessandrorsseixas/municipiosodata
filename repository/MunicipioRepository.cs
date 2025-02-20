using Bogus;
using MongoDB.Driver;
using WebApplication1.dto;

namespace WebApplication1.repository
{
  

    public interface IMunicipioRepository
    {
        IQueryable<MunicipioDto> GetAll();
    }

    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly MongoDbContext _context;

        public MunicipioRepository(MongoDbContext context)
        {
            _context = context;
        }

        public IQueryable<MunicipioDto> GetAll()
        {
            var municipios = _context.Municipios.AsQueryable().ToList();

            var faker = new Faker("pt_BR");

            var municipioDtos = municipios.Select(m => new MunicipioDto
            {
                CodigoMunicipio = m.CodigoMuniciopioIBGE,
                NomeMunicipio = m.MuniciopioIBGE,
                SlugNomeMunicipio = GenerateSlug(m.MuniciopioIBGE),
                SobreOMunicipio = faker.Lorem.Sentence(10),
                Fundacao = faker.Date.Past(200, DateTime.Now).Year.ToString(),
                UrlFotoMunicipio = faker.Image.PicsumUrl(),
                Credito = faker.Name.FullName()
            });

            return municipioDtos.AsQueryable();
        }


        private string GenerateSlug(string nomeMunicipio)
        {
            return nomeMunicipio.ToLower()
                .Replace(" ", "-")
                .Replace("á", "a").Replace("à", "a").Replace("ã", "a").Replace("â", "a")
                .Replace("é", "e").Replace("ê", "e")
                .Replace("í", "i")
                .Replace("ó", "o").Replace("õ", "o").Replace("ô", "o")
                .Replace("ú", "u")
                .Replace("ç", "c")
                .Replace(",", "")
                .Replace(".", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace("!", "")
                .Replace("?", "")
                .Replace("/", "")
                .Replace("\\", "")
                .Replace("&", "e");
        }
    }

}
