using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Pipeline
{
    public class StandardPipeLine : IPipeLine
    {
        /// <summary>
        /// 第一个阀门（链头）
        /// </summary>
        private AbstractValve _firstValve;
        /// <summary>
        /// 最后一个阀门（链尾）
        /// </summary>
        private AbstractValve _basicValve;
        public AbstractValve GetFirst()
        {
            return _firstValve;
        }
        public AbstractValve GetBasic()
        {
            return _basicValve;
        }
        public void SetBasic(AbstractValve v)
        {
            _basicValve = v;
        }
        public void AddValve(AbstractValve v)
        {
            if (_firstValve == null)
            {//第一个阀门为空，将第一个加入的阀门设为第一个阀门
                _firstValve = v;

                //设置下一个为最后一个阀门
                v.SetNext(_basicValve);
            }
            else
            {
                AbstractValve current = _firstValve;
                //遍历链条，将阀门加到基础阀门前面
                while (current != null)
                {
                    if (current.GetNext() == _basicValve)
                    {
                        current.SetNext(v);
                        v.SetNext(_basicValve);
                        break;
                    }
                    current = current.GetNext();
                }
            }
        }
    }
}
