using AzureMobileClient.Helpers.Accounts;
using Unity;
using Microsoft.WindowsAzure.MobileServices;

namespace AzureMobileClient.Helpers
{
    /// <summary>
    /// Provides a base implementation for <see cref="ICloudService{TAccount}" /> and <see cref="ICloudAppContext" />
    /// </summary>
    public abstract class UnityCloudServiceContext<TAccount> : AzureCloudServiceContext<TAccount>
        where TAccount : IAccount
    {
        /// <summary>
        /// Gets the Resolving Container
        /// </summary>
        protected IUnityContainer Container { get; }

        /// <summary>
        /// Constructs a new <see cref="UnityCloudServiceContext{TAccount}" />
        /// </summary>
        public UnityCloudServiceContext(IUnityContainer container, IAzureCloudServiceOptions options, ILoginProvider<TAccount> loginProvider, string offlineDbPath = _offlineDbPath)
            : base(options, loginProvider, offlineDbPath)
        {
            Container = container;
        }

        /// <inheritDoc />
        public override ICloudSyncTable<T> SyncTable<T>() =>
            Container.Resolve<ICloudSyncTable<T>>();

        /// <inheritDoc />
        public override ICloudTable<T> Table<T>() =>
            Container.Resolve<ICloudTable<T>>();
    }
}