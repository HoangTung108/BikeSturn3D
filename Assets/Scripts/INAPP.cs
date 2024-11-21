using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

public class INAPP : MonoBehaviour, IDetailedStoreListener
{
	private static IStoreController m_StoreController;

	private static IExtensionProvider m_StoreExtensionProvider;

	public static string NoAdsid = "aaaaa.rider.removeads";

	public static string StarterKit = "aaaaa.rider.starterkit";

	public static string CoinOfferPack = "aaaaa.rider.coin.offerpack";

	public static string DoubleCoins = "aaaaa.rider.doublecoins";

	public static string UnlockAllLevels = "aaaaa.rider.unlocklevels";

	public static string UnlockAllBikes = "aaaaa.rider.unlockbikes";

	public static string CashSet1 = "aaaaa.rider.cashsetone";

	public static string CashSet2 = "aaaaa.rider.cashsettwo";

	public static string CashSet3 = "aaaaa.rider.cashsetthree";

	public Text NoAdsPriceText;

	public Text StarterKitPriceText;

	public Text CoinOfferPackPriceText;

	public Text DiscountOfferPackPriceText;

	public Text DoubleCoinsPriceText;

	public Text UnlockAllLevelsPriceText;

	public Text UnlockAllBikesPriceText;

	public Text CashSet1PriceText;

	public Text CashSet2PriceText;

	public Text CashSet3PriceText;

	public Text CashText;

	public MenuScript MenuScriptsCRIPT;

	public GameObject PriceSETObj;

	private void Start()
	{
		if (m_StoreController == null)
		{
			InitializePurchasing();
		}

#if UNITY_EDITOR
		PlayerPrefs.SetInt("FUnlockedLevel2", 1);
		PlayerPrefs.SetInt("FUnlockedLevel3", 1);
		PlayerPrefs.SetInt("FUnlockedLevel4", 1);
		PlayerPrefs.SetInt("FUnlockedLevel5", 1);
		PlayerPrefs.SetInt("FUnlockedLevel6", 1);
		PlayerPrefs.SetInt("FUnlockedLevel7", 1);
		PlayerPrefs.SetInt("FUnlockedLevel8", 1);
		PlayerPrefs.SetInt("FUnlockedLevel9", 1);
		PlayerPrefs.SetInt("FUnlockedLevel10", 1);
		PlayerPrefs.SetInt("FUnlockedLevel11", 1);
		PlayerPrefs.SetInt("FUnlockedLevel12", 1);
		PlayerPrefs.SetInt("FUnlockedLevel13", 1);
		PlayerPrefs.SetInt("FUnlockedLevel14", 1);
		PlayerPrefs.SetInt("FUnlockedLevel15", 1);
		PlayerPrefs.SetInt("FUnlockedLevel16", 1);
		PlayerPrefs.SetInt("FUnlockedLevel17", 1);
		PlayerPrefs.SetInt("FUnlockedLevel18", 1);
		PlayerPrefs.SetInt("FUnlockedLevel19", 1);
		PlayerPrefs.SetInt("FUnlockedLevel20", 1);
		PlayerPrefs.SetInt("TUnlockedLevel2", 1);
		PlayerPrefs.SetInt("TUnlockedLevel3", 1);
		PlayerPrefs.SetInt("TUnlockedLevel4", 1);
		PlayerPrefs.SetInt("TUnlockedLevel5", 1);
		PlayerPrefs.SetInt("TUnlockedLevel6", 1);
		PlayerPrefs.SetInt("TUnlockedLevel7", 1);
		PlayerPrefs.SetInt("TUnlockedLevel8", 1);
		PlayerPrefs.SetInt("TUnlockedLevel9", 1);
		PlayerPrefs.SetInt("TUnlockedLevel10", 1);
		PlayerPrefs.SetInt("TUnlockedLevel11", 1);
		PlayerPrefs.SetInt("TUnlockedLevel12", 1);
		PlayerPrefs.SetInt("TUnlockedLevel13", 1);
		PlayerPrefs.SetInt("TUnlockedLevel14", 1);
		PlayerPrefs.SetInt("TUnlockedLevel15", 1);
		PlayerPrefs.SetInt("TUnlockedLevel16", 1);
		PlayerPrefs.SetInt("TUnlockedLevel17", 1);
		PlayerPrefs.SetInt("TUnlockedLevel18", 1);
		PlayerPrefs.SetInt("TUnlockedLevel19", 1);
		PlayerPrefs.SetInt("TUnlockedLevel20", 1);
		PlayerPrefs.SetInt("UnlockTimeModeDB", 1);
		PlayerPrefs.SetInt("UnlockALLLevelsDB", 1);

		//BIKE
		PlayerPrefs.SetInt("BikeTwoPurcahsed", 1);
		PlayerPrefs.SetInt("BikeThreePurcahsed", 1);
		PlayerPrefs.SetInt("BikeFourPurcahsed", 1);
		PlayerPrefs.SetInt("BikeFivePurcahsed", 1);
		PlayerPrefs.SetInt("BikeSixPurcahsed", 1);
		PlayerPrefs.SetInt("BikeSevenPurcahsed", 1);
		PlayerPrefs.SetInt("BikeEightPurcahsed", 1);
		PlayerPrefs.SetInt("BikeNinePurcahsed", 1);
		PlayerPrefs.SetInt("BikeTenPurcahsed", 1);
		PlayerPrefs.SetInt("BikeElevenPurcahsed", 1);
#endif
	}

	public void InitializePurchasing()
	{
		if (!IsInitialized())
		{
			//ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
			//configurationBuilder.AddProduct(NoAdsid, ProductType.NonConsumable);
			//configurationBuilder.AddProduct(StarterKit, ProductType.NonConsumable);
			//configurationBuilder.AddProduct(CoinOfferPack, ProductType.NonConsumable);
			//configurationBuilder.AddProduct(DoubleCoins, ProductType.NonConsumable);
			//configurationBuilder.AddProduct(UnlockAllLevels, ProductType.NonConsumable);
			//configurationBuilder.AddProduct(UnlockAllBikes, ProductType.NonConsumable);
			//configurationBuilder.AddProduct(CashSet1, ProductType.Consumable);
			//configurationBuilder.AddProduct(CashSet2, ProductType.Consumable);
			//configurationBuilder.AddProduct(CashSet3, ProductType.Consumable);
			//UnityPurchasing.Initialize(this, configurationBuilder);
		}
	}

	private bool IsInitialized()
	{
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}

	public void BuyNoAdsProduct_Click()
	{
		BuyProductID(NoAdsid);
	}

	public void BuyStarterKitProduct_Click()
	{
		BuyProductID(StarterKit);
	}

	public void BuyCoinsOfferPackProduct_Click()
	{
		BuyProductID(CoinOfferPack);
	}

	public void BuyDoubleCoinsProduct_Click()
	{
		BuyProductID(DoubleCoins);
	}

	public void BuyUnlockAllLevelsProduct_Click()
	{
		BuyProductID(UnlockAllLevels);
	}

	public void BuyUnlockAllBikesProduct_Click()
	{
		BuyProductID(UnlockAllBikes);
	}

	public void BuyCashSetOne_Click()
	{
		BuyProductID(CashSet1);
	}

	public void BuyCashSetTwo_Click()
	{
		BuyProductID(CashSet2);
	}

	public void BuyCashSetThree_Click()
	{
		BuyProductID(CashSet3);
	}

	private void BuyProductID(string productId)
	{
		if (IsInitialized())
		{
			Product product = m_StoreController.products.WithID(productId);
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				m_StoreController.InitiatePurchase(product);
			}
			else
			{
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		else
		{
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}

	public void RestorePurchases()
	{
		if (!IsInitialized())
		{
			Debug.Log("RestorePurchases FAIL. Not initialized.");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
		{
			Debug.Log("RestorePurchases started ...");
			//IAppleExtensions extension = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			//extension.RestoreTransactions(delegate(bool result)
			//{
			//	Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			//});
		}
		else
		{
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		Debug.Log("OnInitialized: PASS");
		m_StoreController = controller;
		m_StoreExtensionProvider = extensions;
		if (Application.loadedLevel == 1)
		{
			string localizedPriceString = m_StoreController.products.WithStoreSpecificID(NoAdsid).metadata.localizedPriceString;
			NoAdsPriceText.text = localizedPriceString;
			string localizedPriceString2 = m_StoreController.products.WithStoreSpecificID(StarterKit).metadata.localizedPriceString;
			StarterKitPriceText.text = localizedPriceString2;
			string localizedPriceString3 = m_StoreController.products.WithStoreSpecificID(CoinOfferPack).metadata.localizedPriceString;
			CoinOfferPackPriceText.text = "Buy[" + localizedPriceString3 + "]";
			string localizedPriceString4 = m_StoreController.products.WithStoreSpecificID(DoubleCoins).metadata.localizedPriceString;
			DoubleCoinsPriceText.text = localizedPriceString4;
			string localizedPriceString5 = m_StoreController.products.WithStoreSpecificID(UnlockAllLevels).metadata.localizedPriceString;
			UnlockAllLevelsPriceText.text = localizedPriceString5;
			string localizedPriceString6 = m_StoreController.products.WithStoreSpecificID(UnlockAllBikes).metadata.localizedPriceString;
			UnlockAllBikesPriceText.text = localizedPriceString6;
			string localizedPriceString7 = m_StoreController.products.WithStoreSpecificID(CashSet1).metadata.localizedPriceString;
			CashSet1PriceText.text = localizedPriceString7;
			string localizedPriceString8 = m_StoreController.products.WithStoreSpecificID(CashSet2).metadata.localizedPriceString;
			CashSet2PriceText.text = localizedPriceString8;
			string localizedPriceString9 = m_StoreController.products.WithStoreSpecificID(CashSet3).metadata.localizedPriceString;
			CashSet3PriceText.text = localizedPriceString9;
			string s = m_StoreController.products.WithStoreSpecificID(CoinOfferPack).metadata.localizedPrice.ToString();
			float num = float.Parse(s);
			float num2 = num + num;
			string isoCurrencyCode = m_StoreController.products.WithStoreSpecificID(CoinOfferPack).metadata.isoCurrencyCode;
			DiscountOfferPackPriceText.text = num2 + isoCurrencyCode;
		}
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		if (string.Equals(args.purchasedProduct.definition.id, NoAdsid, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("NoAdsPurchase", 1);
		}
		else if (string.Equals(args.purchasedProduct.definition.id, StarterKit, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 20000);
			CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
			PlayerPrefs.SetInt("BikeSixPurcahsed", 1);
			PlayerPrefs.SetInt("NoAdsPurchase", 1);
			PlayerPrefs.SetInt("StarterKitPurchase", 1);
		}
		else if (string.Equals(args.purchasedProduct.definition.id, CoinOfferPack, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 40000);
			CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
			PlayerPrefs.SetInt("CoinsOfferPurchase", 1);
		}
		else if (string.Equals(args.purchasedProduct.definition.id, DoubleCoins, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("DoubleCoinsPurcahsed", 1);
		}
		else if (string.Equals(args.purchasedProduct.definition.id, UnlockAllLevels, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("FUnlockedLevel2", 1);
			PlayerPrefs.SetInt("FUnlockedLevel3", 1);
			PlayerPrefs.SetInt("FUnlockedLevel4", 1);
			PlayerPrefs.SetInt("FUnlockedLevel5", 1);
			PlayerPrefs.SetInt("FUnlockedLevel6", 1);
			PlayerPrefs.SetInt("FUnlockedLevel7", 1);
			PlayerPrefs.SetInt("FUnlockedLevel8", 1);
			PlayerPrefs.SetInt("FUnlockedLevel9", 1);
			PlayerPrefs.SetInt("FUnlockedLevel10", 1);
			PlayerPrefs.SetInt("FUnlockedLevel11", 1);
			PlayerPrefs.SetInt("FUnlockedLevel12", 1);
			PlayerPrefs.SetInt("FUnlockedLevel13", 1);
			PlayerPrefs.SetInt("FUnlockedLevel14", 1);
			PlayerPrefs.SetInt("FUnlockedLevel15", 1);
			PlayerPrefs.SetInt("FUnlockedLevel16", 1);
			PlayerPrefs.SetInt("FUnlockedLevel17", 1);
			PlayerPrefs.SetInt("FUnlockedLevel18", 1);
			PlayerPrefs.SetInt("FUnlockedLevel19", 1);
			PlayerPrefs.SetInt("FUnlockedLevel20", 1);
			PlayerPrefs.SetInt("TUnlockedLevel2", 1);
			PlayerPrefs.SetInt("TUnlockedLevel3", 1);
			PlayerPrefs.SetInt("TUnlockedLevel4", 1);
			PlayerPrefs.SetInt("TUnlockedLevel5", 1);
			PlayerPrefs.SetInt("TUnlockedLevel6", 1);
			PlayerPrefs.SetInt("TUnlockedLevel7", 1);
			PlayerPrefs.SetInt("TUnlockedLevel8", 1);
			PlayerPrefs.SetInt("TUnlockedLevel9", 1);
			PlayerPrefs.SetInt("TUnlockedLevel10", 1);
			PlayerPrefs.SetInt("TUnlockedLevel11", 1);
			PlayerPrefs.SetInt("TUnlockedLevel12", 1);
			PlayerPrefs.SetInt("TUnlockedLevel13", 1);
			PlayerPrefs.SetInt("TUnlockedLevel14", 1);
			PlayerPrefs.SetInt("TUnlockedLevel15", 1);
			PlayerPrefs.SetInt("TUnlockedLevel16", 1);
			PlayerPrefs.SetInt("TUnlockedLevel17", 1);
			PlayerPrefs.SetInt("TUnlockedLevel18", 1);
			PlayerPrefs.SetInt("TUnlockedLevel19", 1);
			PlayerPrefs.SetInt("TUnlockedLevel20", 1);
			PlayerPrefs.SetInt("UnlockTimeModeDB", 1);
			PlayerPrefs.SetInt("UnlockALLLevelsDB", 1);
		}
		else if (string.Equals(args.purchasedProduct.definition.id, UnlockAllBikes, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("BikeTwoPurcahsed", 1);
			PlayerPrefs.SetInt("BikeThreePurcahsed", 1);
			PlayerPrefs.SetInt("BikeFourPurcahsed", 1);
			PlayerPrefs.SetInt("BikeFivePurcahsed", 1);
			PlayerPrefs.SetInt("BikeSixPurcahsed", 1);
			PlayerPrefs.SetInt("BikeSevenPurcahsed", 1);
			PlayerPrefs.SetInt("BikeEightPurcahsed", 1);
			PlayerPrefs.SetInt("BikeNinePurcahsed", 1);
			PlayerPrefs.SetInt("BikeTenPurcahsed", 1);
			PlayerPrefs.SetInt("BikeElevenPurcahsed", 1);
			MenuScriptsCRIPT.DesBikeIns();
			MenuScriptsCRIPT.BikeIns();
		}
		else if (string.Equals(args.purchasedProduct.definition.id, CashSet1, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 5000);
			CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
		}
		else if (string.Equals(args.purchasedProduct.definition.id, CashSet2, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 10000);
			CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
		}
		else if (string.Equals(args.purchasedProduct.definition.id, CashSet3, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 30000);
			CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
		}
		else
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
		}
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
    }
}
