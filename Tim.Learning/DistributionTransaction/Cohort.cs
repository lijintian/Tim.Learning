using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionTransaction
{
    /// <summary>
    /// 参与者
    /// </summary>
    public class Cohort
    {
        /// <summary>
        /// 参与者名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 参与者代码
        /// </summary>
        public string Code { get;private set; }
        /// <summary>
        /// 接口Base地址
        /// </summary>
        public string WebApiBaseUrl { get; private set; }

        /// <summary>
        /// 记录RedoUndo的信息
        /// </summary>
        private void LogRedoUndoInfo()
        {

        }

        /// <summary>
        /// 提交本地事务
        /// </summary>
        private void CommitLocalTransaion()
        {

        }




    }
}
