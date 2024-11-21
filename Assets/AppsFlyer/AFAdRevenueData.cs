using System;
using System.Collections.Generic;

namespace AppsFlyerSDK
{
    public enum MediationNetwork : ulong
    {      
        GoogleAdMob = 1,
        IronSource = 2,
        ApplovinMax = 3,
        Fyber = 4,
        Appodeal = 5,
        Admost = 6,
        Topon = 7,
        Tradplus = 8,
        Yandex = 9,
        ChartBoost = 10,
        Unity = 11,
        ToponPte = 12,
        Custom = 13,
        DirectMonetization = 14
    }

    public static class AdRevenueScheme
    {
        /**
        * code ISO 3166-1 format
        */
        public const string COUNTRY = "country";

        /**
        * ID of the ad unit for the impression
        */
        public const string AD_UNIT = "ad_unit";

        /**
        * Format of the ad
        */
        public const string AD_TYPE = "ad_type";

        /**
        * ID of the ad placement for the impression
        */
        public const string PLACEMENT = "placement";
    }

    /// <summary>
    // Data class representing ad revenue information.
    //
    // @property monetizationNetwork The name of the network that monetized the ad.
    // @property mediationNetwork An instance of MediationNetwork representing the mediation service used.
    // @property currencyIso4217Code The ISO 4217 currency code describing the currency of the revenue.
    // @property eventRevenue The amount of revenue generated by the ad.
    /// </summary>
    public class AFAdRevenueData
    {
        public string monetizationNetwork { get; private set; }
        public MediationNetwork mediationNetwork { get; private set; }
        public string currencyIso4217Code { get; private set; }
        public double eventRevenue { get; private set; }

        public AFAdRevenueData(string monetization, MediationNetwork mediation, string currency, double revenue)
        {
            monetizationNetwork = monetization;
            mediationNetwork = mediation;
            currencyIso4217Code = currency;
            eventRevenue = revenue;
        }
    }

}