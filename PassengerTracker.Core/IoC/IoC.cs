using Ninject;

namespace PassengerTracker.Core
{
    /// <summary>
    /// Класс, позволяющий снизить зависимость между ViewModel и View
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Основной компонент IoC, отвечающий за привязку интерфейсов к реализациям, а также за доступ к этим самым элементам
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Интерфейс взаимодействия с графической частью приложения
        /// </summary>
        public static IUIManager UI => Get<IUIManager>();

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
