using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Pipeline
{
    //管道接口
    public interface IPipeLine
    {
        AbstractValve GetFirst();
        AbstractValve GetBasic();
        void SetBasic(AbstractValve v);
        void AddValve(AbstractValve v);
    }
}
