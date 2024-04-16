using Microsoft.Extensions.DependencyInjection;

using TossPayments.BrandPay.Client;
using TossPayments.Core.Client;

namespace TossPayments.Extensions
{
    public static class IServiceCollectionExtensions
    {
        internal const string TossPaymentsCoreOptionsName = "TossPaymentsCore";
        internal const string TossPaymentsBrandPayOptionsName = "TossPaymentsBrandPay";

        public static IServiceCollection AddTossPaymentsCoreClient(this IServiceCollection services, Action<TossPaymentsClientOptions> options)
        {
            services.AddScoped<ITossPaymentsCoreClient, TossPaymentsCoreClient>();
            services.AddOptions<TossPaymentsClientOptions>(TossPaymentsCoreOptionsName).Configure(options);
            services.AddHttpClient<ITossPaymentsCoreClient, TossPaymentsCoreClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.tosspayments.com");
            });

            return services;
        }

        public static IServiceCollection AddTossPaymentsClient(this IServiceCollection services, Action<TossPaymentsClientOptions> options)
        {
            services.AddScoped<ITossPaymentsBrandPayClient, TossPaymentsBrandPayClient>();
            services.AddOptions<TossPaymentsClientOptions>(TossPaymentsBrandPayOptionsName).Configure(options);
            services.AddHttpClient<ITossPaymentsBrandPayClient, TossPaymentsBrandPayClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.tosspayments.com");
            });

            return services;
        }
    }
}