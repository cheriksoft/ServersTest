using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace ServersApp.Infrastructure
{
    /// <summary>
    /// Расширения для IoC в Castle - чтоюы не писать под каждую зависимость длинные простыни опций
    /// Позволит удобно регистрировать в global.asax зависимости по принципу Fluent Builder, цепочкой методов
    /// </summary>
    public static class WindsorExtensions
    {
        public static IWindsorContainer PerRequest<TInterface, TImplement>(this IWindsorContainer container)
            where TInterface : class
            where TImplement : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TImplement>().Named(typeof(TInterface).FullName).LifeStyle.PerWebRequest());

            return container;
        }

        public static IWindsorContainer Singleton<TInterface, TImplement>(this IWindsorContainer container)
            where TInterface : class
            where TImplement : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TImplement>().Named(typeof(TInterface).FullName).LifeStyle.Singleton.IsDefault());

            return container;
        }

        public static IWindsorContainer Transient<TInterface, TImplement>(this IWindsorContainer container)
            where TInterface : class
            where TImplement : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TImplement>().Named(typeof(TInterface).FullName).LifeStyle.Transient);

            return container;
        }

        public static IWindsorContainer ArrayPerRequest<TInterface>(this IWindsorContainer container, Assembly assembly)
        {
            container.Register(Classes
                .FromAssembly(assembly)
                .BasedOn<TInterface>()
                .WithService.FromInterface(typeof(TInterface))
                .LifestylePerWebRequest());
            return container;
        }

        public static IWindsorContainer ArraySingleton<TInterface>(this IWindsorContainer container, Assembly assembly)
        {
            container.Register(Classes
                .FromAssembly(assembly)
                .BasedOn<TInterface>()
                .WithService.FromInterface(typeof(TInterface))
                .LifestyleSingleton());
            return container;
        }

        public static IWindsorContainer Scoped<TInterface, TImplement>(this IWindsorContainer container)
            where TInterface : class
            where TImplement : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TImplement>().Named(typeof(TInterface).FullName).LifeStyle.Scoped());

            return container;
        }
    }
}