using System;

namespace CupomSample.Domain
{
    public class Cupom
    {
        public Cupom(string codCupom)
        {
            IdCupom = Guid.NewGuid();
            CodCupom = codCupom;
        }
        public Guid IdCupom { get; private set; }
        public string CodCupom { get; private set; }
    }
}
