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
        void Register(IObserver2 observer);

        /// <summary>
        /// 移除订阅
        /// </summary>
        /// <param name="key"></param>
        void Remove(IObserver2 observer);

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
        public List<IObserver2> Observers;
        public ConcreteSubject()
        {
            Observers = new List<IObserver2>();
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
                item.Update(0);
            }
        }

        public void Register(IObserver2 observer)
        {
            Observers.Add(observer);
        }

        public void Remove(IObserver2 observer)
        {
            Observers.Remove(observer);
        }
    }

    public class ConcreteObserver : IObserver2
    {
        public ConcreteObserver(ISubject subject)
        {
            subject.Register(this);
        }

        public void Update(float temperature)
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
            WeatherData.Register(this);
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
        public List<IObserver2> Observers;


        public WeatherDataSubject()
        {
            Observers = new List<IObserver2>();
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
                item.Update(0);
            }
        }

        public void Register(IObserver2 observer)
        {
            Observers.Add(observer);
        }

        public void Remove(IObserver2 observer)
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
            ConcreteObserver observer = new ConcreteObserver(concreteSubject);
            // 主题发送通知
            concreteSubject.Notify();
            // 移除订阅
            concreteSubject.Remove(observer);
            // 主题发送通知
            concreteSubject.Notify();
        }
    }

    public struct Message
    {
        string text;

        public Message(string newText)
        {
            this.text = newText;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
        }
    }

    public class Headquarters : IObservable<Message>
    {
        public Headquarters()
        {
            observers = new List<IObserver<Message>>();
        }

        private List<IObserver<Message>> observers;

        public IDisposable Subscribe(IObserver<Message> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Message>> _observers;
            private IObserver<Message> _observer;

            public Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void SendMessage(Nullable<Message> loc)
        {
            foreach (var observer in observers)
            {
                if (!loc.HasValue)
                    observer.OnError(new Exception());
                else
                    observer.OnNext(loc.Value);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }

    public class Test
    {

    }

    public class TestSub : IObservable<Test>
    {
        private readonly List<IObserver<Test>> observers;
        public TestSub()
        {
            observers = new List<IObserver<Test>>();
        }
        public IDisposable Subscribe(IObserver<Test> observer)
        {
            return new UnSub(observers, observer);
        }

        private class UnSub : IDisposable
        {
            private List<IObserver<Test>> Observables;
            private IObserver<Test> Observer;
            public UnSub(List<IObserver<Test>> observables, IObserver<Test> observer)
            {
                Observables = observables;
                Observer = observer;

            }

            public void Dispose()
            {
                if (Observables != null && Observables.Contains(Observer))
                    Observables.Remove(Observer);
            }
        }
    }

    // 使用自带订阅
    public class TestObserver : IObserver<Test>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Test value)
        {
            throw new NotImplementedException();
        }
    }
}
