using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyControl
{
    public class GlobalLocker
    {
        private static readonly object GlobalLock = new object();
        private static readonly Dictionary<string, Locker> GlobalLocks = new Dictionary<string, Locker>();

        /// <summary>
        /// 尝试获取指定对象的排他锁
        /// </summary>
        /// <param name="key">全局锁对象的Key</param>
        /// <param name="timeout">尝试获取锁的超时时间</param>
        /// <returns></returns>
        public static Locker Enter(string key, int timeout = 0)
        {
            Locker locker;
            try
            {
                lock (GlobalLock)
                {
                    if (!GlobalLocks.TryGetValue(key, out locker))
                    {
                        locker = new Locker(key);
                        GlobalLocks.Add(key, locker);
                    }

                    locker.Enter();
                }

                //Monitor.Enter(locker);
                if (timeout > 0)
                {
                    if (!Monitor.TryEnter(locker, timeout))
                    {
                        throw new Exception("Monitor.TryEnter程序锁获取失败。");
                    }
                }
                else
                {
                    Monitor.Enter(locker);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("程序锁获取失败。", ex);
            }

            return locker;
        }

        /// <summary>
        /// 释放指定对象上的排他锁,Locker Dispose的时候会调用此方法，通过Using 创建GlobalLocker即可
        /// </summary>
        /// <param name="locker">要释放的Locker</param>
        internal static void Exit(Locker locker)
        {
            if (locker == null)
            {
                return;
            }
            Monitor.Exit(locker);
            lock (GlobalLock)
            {
                if (locker.Exit())
                {
                    GlobalLocks.Remove(locker.Key);
                }
            }
        }
    }
}
