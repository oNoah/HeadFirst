using System;
using System.Collections.Generic;

namespace Demo
{
    public class WeatherData
    {
        /// <summary>
        /// 温度
        /// </summary>
        public float Temperature { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        public float Humidity { get; set; }

        /// <summary>
        /// 气压
        /// </summary>
        public string Pressure { get; set; }


        /// <summary>
        /// 气象更新时触发
        /// </summary>
        public virtual void MeasurementsChanged()
        {
            Console.WriteLine("拉去气象数据");
        }
    }

    /// <summary>
    /// 布告板
    /// </summary>
    public class Board
    {
        /// <summary>
        /// 外观
        /// </summary>
        public void Display()
        {

        }
    }

    /// <summary>
    /// 主题
    /// </summary>
    public interface ISubject
    {

        /// <summary>
        /// 订阅
        /// </summary>
        void Register(IObserver observer);

        /// <summary>
        /// 移除订阅
        /// </summary>
        /// <param name="key"></param>
        void Remove(IObserver observer);

        /// <summary>
        /// 发送通知后更新观察者的update
        /// </summary>
        void Notify();
    }

    /// <summary>
    /// 观察者
    /// </summary>
    public interface IObserver
    {
        void Update();
    }

    /// <summary>
    /// 具体主题
    /// </summary>
    public class ConcreteSubject : ISubject
    {
        public List<IObserver> Observers;
        public ConcreteSubject()
        {
            Observers = new List<IObserver>();
        }
        public void Notify()
        {
            if(Observers.Count == 0)
            {
                Console.WriteLine("没有订阅");
                return;
            }
            foreach(var item in Observers)
            {
                item.Update();
            }
        }

        public void Register(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            Observers.Remove(observer);
        }
    }

    public class ConcreteObserver : IObserver
    {
        public void Update()
        {
            Console.WriteLine("订阅者执行更新");
        }
    }



    /// <summary>
    /// 观察者
    /// </summary>
    public interface IObserver2
    {
        void Update(float temperature);
    }

    /// <summary>
    /// 样式
    /// </summary>
    public interface IDisplayElement
    {
        void Display();
    }

    /// <summary>
    /// 看板
    /// </summary>
    public interface BoardObserver
    {
        void Update();
    }


    /// <summary>
    /// 看板1
    /// </summary>
    public class BoardNo1Observer : IObserver
    {
        public void Update()
        {
            Console.WriteLine("温度：");
            Console.WriteLine("湿度：");
            Console.WriteLine("气压：");
        }
    }

    public class BoardNo2Observer : IObserver
    {
        public void Update()
        {
            Console.WriteLine("平均气温：");
            Console.WriteLine("最低温度：");
            Console.WriteLine("最高温度：");
        }
    }

    public class BoardNo3Observer : IObserver
    {
        public void Update()
        {
            Console.WriteLine("天气预报：");
        }
    }

    public class CurrentConditionDisplay : IObserver2, IDisplayElement
    {

        public ISubject WeatherData;
        /// <summary>
        /// 温度
        /// </summary>
        public float Temperature { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        public float Humidity { get; set; }

        /// <summary>
        /// 气压
        /// </summary>
        public string Pressure { get; set; }

        public CurrentConditionDisplay(ISubject weatherData)
        {
            WeatherData = weatherData;
        }

        public void Display()
        {
            Console.WriteLine("气温：");
            Console.WriteLine("温度：");
            Console.WriteLine("温度：");
        }

        public void Update(float temperature)
        {
            this.Temperature = temperature;
        }
    }


    /// <summary>
    /// 气象监测主题
    /// </summary>
    public class WeatherDataSubject : WeatherData, ISubject
    {
        public List<IObserver> Observers;


        public WeatherDataSubject()
        {
            Observers = new List<IObserver>();
        }

        public override void MeasurementsChanged()
        {
            // 拉取数据后执行通知
            Notify();
        }

        public void Notify()
        {
            if (Observers.Count == 0)
            {
                Console.WriteLine("没有订阅");
                return;
            }
            foreach (var item in Observers)
            {
                item.Update();
            }
        }

        public void Register(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            Observers.Remove(observer);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("天气站的设计");

            // 需求 ： 天气站的设计 面向对象设计



            ConcreteSubject concreteSubject = new ConcreteSubject();
            ConcreteObserver observer = new ConcreteObserver();
            // 订阅
            concreteSubject.Register(observer);
            // 主题发送通知
            concreteSubject.Notify();
            // 移除订阅
            concreteSubject.Remove(observer);
            // 主题发送通知
            concreteSubject.Notify();
        }
    }
}
