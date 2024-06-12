using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    interface IFlyBehaviour
    {
        void Fly();
    }

    class FlyWithWings : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    class FlyNoWay : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly!");
        }
    }

    interface IQuackBehaviour
    {
        void Quack();
    }

    class QuackLoud : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("Quaaaaaaack!");
        }
    }

    class QuackQuiet : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("<< Quiet >>: Quack!");
        }
    }

    class QuackNoWay : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("<< Silence >>");
        }
    }

    abstract class ADuck
    {
        private IFlyBehaviour FlyBehaviour;
        private IQuackBehaviour QuackBehaviour;
        public void SetFlyBehaviour(IFlyBehaviour behaviour)
        {
            FlyBehaviour = behaviour;
        }

        public void SetQuackBehaviour(IQuackBehaviour behaviour)
        {
            QuackBehaviour = behaviour;
        }

        public void PerformFly()
        {
            FlyBehaviour.Fly();
        }

        public void PerformQuack()
        {
            QuackBehaviour.Quack();
        }
    }

    class MallardDuck : ADuck
    {
        public MallardDuck(IFlyBehaviour flybehaviour, IQuackBehaviour quackbehaviour)
        {
            SetFlyBehaviour(flybehaviour);
            SetQuackBehaviour(quackbehaviour);
        }

        public MallardDuck():this(new FlyWithWings(), new QuackLoud()) { }
    }

    class DecoyDuck : ADuck
    {
        public DecoyDuck(IFlyBehaviour flybehaviour, IQuackBehaviour quackbehaviour)
        {
            SetFlyBehaviour(flybehaviour);
            SetQuackBehaviour(quackbehaviour);
        }

        public DecoyDuck() : this(new FlyNoWay(), new QuackNoWay()) { }
    }
}
