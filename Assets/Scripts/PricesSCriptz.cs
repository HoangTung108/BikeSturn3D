using UnityEngine;
using UnityEngine.UI;

public class PricesSCriptz : MonoBehaviour
{
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

	private void OnEnable()
	{
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("NoAdsPriceDB")))
		{
			NoAdsPriceText.text = PlayerPrefs.GetString("NoAdsPriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("StarterKitPriceDB")))
		{
			StarterKitPriceText.text = PlayerPrefs.GetString("StarterKitPriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CoinOfferPackPriceDB")))
		{
			CoinOfferPackPriceText.text = PlayerPrefs.GetString("CoinOfferPackPriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("DoubleCoinsPriceDB")))
		{
			DoubleCoinsPriceText.text = PlayerPrefs.GetString("DoubleCoinsPriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("DiscountPriceDB")))
		{
			DiscountOfferPackPriceText.text = PlayerPrefs.GetString("DiscountPriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("UnlockAllLevelsPriceDB")))
		{
			UnlockAllLevelsPriceText.text = PlayerPrefs.GetString("UnlockAllLevelsPriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("UnlockAllBikesPriceDB")))
		{
			UnlockAllBikesPriceText.text = PlayerPrefs.GetString("UnlockAllBikesPriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CashSet1PriceDB")))
		{
			CashSet1PriceText.text = PlayerPrefs.GetString("CashSet1PriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CashSet2PriceDB")))
		{
			CashSet2PriceText.text = PlayerPrefs.GetString("CashSet2PriceDB");
		}
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CashSet3PriceDB")))
		{
			CashSet3PriceText.text = PlayerPrefs.GetString("CashSet3PriceDB");
		}
	}
}
