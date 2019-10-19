using System;

namespace Demo
{

    /// <summary>
    /// 鸭子超类
    /// </summary>
    public class Duck
    {
        /// <summary>
        /// 呱呱叫
        /// </summary>
        public virtual void Quack()
        {
            Console.WriteLine($"鸭子在呱呱叫");
        }

        /// <summary>
        /// 游泳
        /// </summary>
        public void Swim()
        {
            Console.WriteLine($"鸭子在游泳");
        }

        /// <summary>
        /// 外观
        /// </summary>
        public virtual void Display()
        {
            Console.WriteLine("鸭子的外观");
        }

        /// <summary>
        /// 飞行
        /// </summary>
        public virtual void Fly()
        {
            Console.WriteLine($"鸭子在飞");
        }
    }

    /// <summary>
    /// 野鸭
    /// </summary>
    public class MallardDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("绿头鸭子");
        }
    }

    /// <summary>
    /// 红头鸭
    /// </summary>
    public class ReadheadDuck : Duck
    {

        public override void Display()
        {
            Console.WriteLine("红头鸭子");
        }

    }

    /// <summary>
    /// 橡皮鸭子
    /// </summary>
    public class RubberDuck : Duck
    {
        public override void Quack()
        {
            Console.WriteLine("吱吱吱地叫");
        }

        public override void Fly()
        {
            // base.Fly();
            // 重写方法,橡皮鸭子鸭子不会飞
        }
    }

    /// <summary>
    /// 诱饵(木头)鸭子
    /// </summary>
    public class DecoyDuck : Duck
    {
        public override void Fly()
        {
            // base.Fly();
            // 木头鸭子也不会飞
        }

        public override void Quack()
        {
            // base.Quack();
            // 木头鸭子也不会叫
        }
    }

    /// <summary>
    /// 飞行接口
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// 飞行方法
        /// </summary>
        void Fly();
    }

    /// <summary>
    /// 叫声接口
    /// </summary>
    public interface IQuackable
    {
        /// <summary>
        /// 叫声
        /// </summary>
        void Quack();
    }

    /// <summary>
    /// 鸭子V2版本
    /// </summary>
    public class DuckV2
    {

        /// <summary>
        /// 游泳
        /// </summary>
        public void Swim()
        {
            Console.WriteLine($"鸭子在游泳");
        }

    }

    /// <summary>
    /// 野鸭V2版本
    /// </summary>
    public class MallardDuckV2 : DuckV2, IFlyable, IQuackable
    {
        public void Fly()
        {
            FlyWithWings flyWithWings = new FlyWithWings();
            flyWithWings.Fly();
            //Console.WriteLine("野鸭在飞");
        }

        public void Quack()
        {
           
            Console.WriteLine("野鸭在叫");
        }
    }

    /// <summary>
    /// 橡皮鸭v2
    /// </summary>
    public class RubberDuckV2 : DuckV2, IQuackable
    {
        public void Quack()
        {
            Squeak squeak = new Squeak();
            squeak.Quack();
        }
    }

    /// <summary>
    /// 火箭鸭
    /// </summary>
    public class RocketsDuck : DuckV2, IFlyBehavior
    {
        public void Fly()
        {
            FlyWithRockets flyWithRockets = new FlyWithRockets();
            flyWithRockets.Fly();
        }
    }

    /// <summary>
    /// 木头鸭V2版本 不继承飞行和叫声接口
    /// </summary>
    public class DecoyDuckV2 : DuckV2
    {

    }


    /// <summary>
    /// 飞行行为类
    /// </summary>
    public interface IFlyBehavior
    {
        void Fly();
    }

    /// <summary>
    /// 会飞的实现
    /// </summary>
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("实现鸭子飞行");
        }
    }

    /// <summary>
    /// 火箭飞行
    /// </summary>
    public class FlyWithRockets : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("实现鸭子火箭飞行");
        }
    }

    /// <summary>
    /// 不会飞的实现
    /// </summary>
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("不做操作");
        }
    }

    /// <summary>
    /// 叫声行为类
    /// </summary>
    public interface IQuackBehavior
    {
        void Quack();
    }

    /// <summary>
    /// 呱呱叫
    /// </summary>
    public class Quack : IQuackBehavior
    {
        void IQuackBehavior.Quack()
        {
            Console.WriteLine("呱呱叫");
        }
    }

    /// <summary>
    /// 吱吱叫
    /// </summary>
    public class Squeak : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("吱吱叫");
        }
    }

    /// <summary>
    /// 不出声
    /// </summary>
    public class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("不出声");
        }
    }

    /// <summary>
    /// 动物类
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// 举例
        /// </summary>
        /// <returns></returns>
        public Animal GetAnimal()
        {
            return new Cat();
        }

        /// <summary>
        /// 叫
        /// </summary>
        public abstract void MakeSound();
    }

    /// <summary>
    /// 狗
    /// </summary>
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Brak();
        }

        /// <summary>
        /// 汪汪叫
        /// </summary>
        public void Brak()
        {
            Console.WriteLine("汪汪叫");
        }
    }

    /// <summary>
    /// 猫
    /// </summary>
    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Meow();
        }

        /// <summary>
        /// 喵喵叫
        /// </summary>
        public void Meow()
        {
            Console.WriteLine("喵喵叫");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("鸭子的设计");

            // 需求 ： 鸭子游戏的OO设计 面向对象设计
            // 1. 设计一个鸭子超类
            // 2. 不同鸭子继承超类
            // 3. 野鸭和红头鸭 外观不同 所以重写外观Display方法
            // 4. 业务需求给鸭子添加了飞行 给鸭子超类添加fly方法
            // 5. 业务需求添加一个橡皮鸭子
            //    因为也继承了鸭子超类 橡皮鸭子也继承了飞行的方法 实际情况是不可能的
            //    橡皮鸭子可以重写飞行方法 什么都不做 也可以，但后面如果有更多种类的鸭子 每个都得重写方法
            //    比如木头鸭子 既不会飞 也不会叫 就得重写多个方法
            // 6. 这样设计的缺点 代码在多个子类重复 很难知道所有鸭子的全部行为(需求不确定) 改动会牵一发而动全身
            //    造成鸭子不想要的改变
            // 7. 解决思路：使用接口 抽象出飞行和叫声 缺点 重复代码太多 ，如果有更多的鸭子种类 都得重写方法
            // 8. 软件开发 永远都存在改变
            // 9. 解决思路： 针对接口编程 而不是针对实现编程 问题Q:为什么不用抽象超类 使用多态 而是写接口?
            // 10.针对接口编程- 针对超类型编程, 利用多态 执行时根据实际状态执行到真正的行为，不会绑死在超类型的行为上
            //    "针对超类型编程" 具体就是 变量的声明类型应该是超类型，通常是一个抽象类或是一个接口
            //    只要具体实现此超类型的类所产生的对象 都可以指定给这个变量 举例：动物类 和猫 和狗的设计
            // 11.分开变化和不会变化的部分 把飞行和叫声归纳到鸭子的行为上 飞行行为 叫声行为
            //    这样的设计 可以让飞行和呱呱叫的动作被其他对象复用，因为这些行为已经与鸭子类无关. 还可以新增一些
            //    行为，不会影响到仅有的行为类 也不会影响 使用到飞行行为的鸭子类。有了 继承的好处，缺解决了继承带来
            //    的包袱

            // 野鸭
            MallardDuck mallardDuck = new MallardDuck();
            Console.WriteLine("--------------野鸭--------------");
            mallardDuck.Display();

            // 红头鸭
            ReadheadDuck readheadDuck = new ReadheadDuck();
            Console.WriteLine("--------------红头鸭--------------");
            readheadDuck.Quack();
            readheadDuck.Display();

            // 橡皮鸭
            RubberDuck rubberDuck = new RubberDuck();
            Console.WriteLine("--------------橡皮鸭子--------------");
            rubberDuck.Quack(); // 橡皮鸭跟普通鸭子声音不一样
            rubberDuck.Fly();// 不合理的地方

            // 木头鸭子
            DecoyDuck decoyDuck = new DecoyDuck();
            Console.WriteLine("--------------木头鸭子--------------");
            decoyDuck.Quack(); // 覆盖 什么也不操作
            decoyDuck.Fly(); // 同样覆盖

            // 野鸭V2
            MallardDuckV2 mallardDuckV2 = new MallardDuckV2();
            Console.WriteLine("--------------野鸭V2--------------");
            mallardDuckV2.Fly();
            mallardDuckV2.Quack();

            // 木头鸭子
            DecoyDuckV2 decoyDuckV2 = new DecoyDuckV2();
            Console.WriteLine("--------------木头鸭子V2--------------");
            // 只有游泳方法
            decoyDuckV2.Swim();

            RubberDuckV2 rubberDuckV2 = new RubberDuckV2();
            Console.WriteLine("--------------橡皮鸭子V2--------------");
            rubberDuckV2.Quack();

            RocketsDuck rocketsDuck = new RocketsDuck();
            Console.WriteLine("--------------火箭鸭--------------");
            rocketsDuck.Fly();

            Console.WriteLine("--------------针对实现编程和针对接口/超类型编程--------------");
            // 针对实现编程
            Dog d = new Dog();  // 声明变量 d 为Dog类型 会造成我们必须针对具体实现编程
            d.Brak();

            // 针对接口/超类型编程
            Animal animal = new Dog();  // 知道对象是狗 但用的是Animal类进行多态调用
            animal.MakeSound();
            // 子类实例化动作 不需要在代码中硬编码 如 new Dog(); 而是在运行时才指定具体实现的对象 如：

            Animal animal2 = animal.GetAnimal();
            animal2.MakeSound();

           
        }
    }
}
