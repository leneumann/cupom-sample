using CupomSample.Domain;
using CupomSample.Domain.CupomContext.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CupomSample.Infrastructure.Repositories
{
    public class CupomRepository : ICupomRepository
    {
        public async Task Add(Cupom cupom)
        {
            Console.WriteLine("Cupom inserido");
        }

        public async Task<CupomDto> Obter(string codigoCupom){
            var cupom = new CupomDto(Guid.NewGuid(), "CUPOM10");

            return cupom;
        } 
    }
}
