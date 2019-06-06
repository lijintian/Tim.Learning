using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Pipeline
{
    //阀门抽象类
    public abstract class AbstractValve
    {
        private AbstractValve _nextValve;
        public AbstractValve GetNext()
        {
            return _nextValve;
        }
        public void SetNext(AbstractValve v)
        {
            _nextValve = v;
        }
        public abstract void Invoke(string s);

    }
}
