using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.interfaces
{
    public interface IRotulavel
    {
        public void SetRotulo(string rotulo);
        public string GetRotulo();

        public void MontaRotulo();
    }
}
