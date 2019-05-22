using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    class Program
    {
        class MainApp
        {
            static void Main()
            {
                // Конкретный компонент  и 3 Конкретных декоратора
                ConcreteComponent c = new ConcreteComponent();
                ConcreteDecoratorA dA = new ConcreteDecoratorA();
                ConcreteDecoratorB dB = new ConcreteDecoratorB();
                ConcreteDecoratorB dB2 = new ConcreteDecoratorB();
                dA.SetComponent(c); //оборачиваем с в первый декоратор
                dB.SetComponent(c);
                dB2.SetComponent(dA); //оборачиваем dA во второй декоратор

                dA.Operation();

                Console.WriteLine();

                dB.Operation();

                Console.WriteLine();

                dB2.Operation();

                Console.Read();
            }
        }

        // определяем интерфейс для объектов, на которые могут быть динамически 
        // возложены дополнительные обязанности
        
        abstract class Component
        {
            public abstract void Operation();
        }

        class ConcreteComponent : Component
        {
            public override void Operation()
            {
                Console.Write("Дом или кот? Вот в чем вопрос, а может и то и другое, но точно не дом без кота, хотя...");
            }
        }

      
        // Decorator - декоратор
        // хранит ссылку на объект и определяет интерфейс,
        // соответствующий интерфейсу 

        abstract class Decorator : Component
        {
            protected Component component;

            public void SetComponent(Component component)
            {
                this.component = component;
            }

            public override void Operation()
            {
                if (component != null)
                {
                    component.Operation();
                }
            }
        }

        class ConcreteDecoratorA : Decorator
        {
            public override void Operation()
            {
                base.Operation();
                string domik = @"
                                           (   )
                                          (    )
                                           (    )
                                          (    )
                                            )  )
                                           (  (                  /\
                                            (_)                 /  \  /\
                                    ________[_]________      /\/    \/  \
                           /\      /\        ______    \    /   /\/\  /\/\
                          /  \    //_\       \    /\    \  /\/\/    \/    \
                   /\    / /\/\  //___\       \__/  \    \/
                  /  \  /\/    \//_____\       \ |[]|     \
                 /\/\/\/       //_______\       \|__|      \
                /      \      /XXXXXXXXXX\                  \
                        \    /_I_II  I__I_\__________________\
                               I_I|  I__I_____[]_|_[]_____I
                               I_II  I__I_____[]_|_[]_____I
                               I II__I  I     XXXXXXX     I
                            ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~";

                 Console.WriteLine(domik);
            }
        }

        class ConcreteDecoratorB : Decorator
        {
            public override void Operation()
            {
                base.Operation();
                string domik = @"

                        .../\__/\
                        ..(=•_•= )
                        ...*****.•*
                        (¯`•\|/•´¯)** ";

                Console.WriteLine(domik);
            }
        }
    }
}
