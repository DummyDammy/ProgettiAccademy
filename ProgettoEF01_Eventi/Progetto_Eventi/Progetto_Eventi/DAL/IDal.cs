using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Eventi.DAL
{
    internal interface IDal<T>
    {
        bool insert(T t);
        List<T> findAll();
        T findById(int id);
        bool deleteById(int id);
        bool update(T t);
    }
}
