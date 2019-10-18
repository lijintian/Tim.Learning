using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlan
{
    class Program
    {
        static void Main(string[] args)
        {

            var employees  = 4;//员工总数

            var busyTimeNeedEmployeeCount = 3;//忙时需要员工数
            var prepareEmployeeCount = 2;//营业准备需要员工数

            var restPerWeek = 1;//每周休息一天

            var earlyTime = "10:00-20:00";
            var latterTime = "12:00-22:00";
            var allTime = "10:00-22:00";



            /*
            休息时间尽量错开周五六日、节假日
            非特殊节假日周一、二、三、四错开休息，特殊节假日另行安排
            有人休息就必须有人通班
            排班需满足一早一通二晚，或有人休息时二通一晚（工作日12:00-22:00需保证三个人在店内，周五六日需要保证4个人通班在店内）
            轮流早班、通班、休息
            周五、六、日两两轮流通班晚班（即周五六日高峰期必须同时有4人在店）。
            */

        }
    }
}
