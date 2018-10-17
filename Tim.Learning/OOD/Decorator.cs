using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    class Decorator
    {
    }

    /// <summary>
    /// 饮料抽象类
    /// </summary>
    public abstract class Beverage {
        protected string description = "Unknown Beverage";

        public virtual string GetDescription()
        {
            return description;
        }

        public abstract double Cost();
    }

    /// <summary>
    /// 调料装饰者
    /// </summary>
    public abstract class CondimentDecorator : Beverage {
        public override string GetDescription()
        {
            return base.description;
        }
    }

    /// <summary>
    /// 具体某一种饮料  Espresso：浓咖啡
    /// </summary>
    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }


    /// <summary>
    /// 摩卡调料
    /// </summary>
    public class Mocha : CondimentDecorator
    {
        Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override double Cost()
        {
            return _beverage.Cost() + 0.20;
        }
    }

    /// <summary>
    /// 奶泡调料
    /// </summary>
    public class Whip : CondimentDecorator
    {
        Beverage _beverage;

        public Whip(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override double Cost()
        {
            return _beverage.Cost() + 0.20;
        }
    }
}
