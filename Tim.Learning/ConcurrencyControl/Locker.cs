using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyControl
{
    public class Locker : IDisposable
    {
        public string Key { get; private set; }
        private int _lockerCount;

        internal Locker(string key)
        {
            Key = key;
            _lockerCount = 0;
        }

        /// <summary>
        /// 加锁
        /// </summary>
        internal void Enter()
        {
            _lockerCount += 1;
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <returns></returns>
        internal bool Exit()
        {
            _lockerCount -= 1;
            return _lockerCount == 0;
        }

        public void Dispose()
        {
            GlobalLocker.Exit(this);
        }
    }
}
