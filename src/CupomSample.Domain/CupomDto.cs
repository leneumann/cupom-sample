using System;

namespace CupomSample.Domain
{
    public class CupomDto
    {
        public Guid IdCupom { get; private set; }
        public string CodigoCupom { get; private set; }

        public CupomDto(Guid idCupom, string codigoCupom)
        {
            IdCupom = idCupom;
            CodigoCupom = codigoCupom;
        }
    }
}