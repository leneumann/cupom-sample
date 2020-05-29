using System.Threading.Tasks;

namespace CupomSample.Domain.CupomContext.Repositories
{
    public interface ICupomRepository
    {
        Task Add(Cupom cupom);
        Task<CupomDto> Obter(string codigoCupom);

    }
}