using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Interfaces;
internal interface IDataGenerationService
{
    public List<IPallet> GeneratePallets();
}
