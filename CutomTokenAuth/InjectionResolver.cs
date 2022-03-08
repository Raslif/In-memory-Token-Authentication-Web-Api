using Ninject;

namespace CutomTokenAuth
{
    public static class InjectionResolver
    {
        /* If it is not possible to get the instance from Constructor, then, we can use this concept */
        public static IKernel Kernel;
        public static T GetType<T>() => Kernel.Get<T>();
        public static T GetType<T>(string binding) => Kernel.Get<T>(binding);
    }
}