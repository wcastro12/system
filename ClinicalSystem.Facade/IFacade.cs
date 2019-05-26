using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClinicalSystem.Facade
{
    public interface IFacade<T>
    {
        List<T> ToList();
        T Find(int? Id);
        bool Add(T obje);
        bool Change(T obje);
        T Remove(T obje);
    }
}
