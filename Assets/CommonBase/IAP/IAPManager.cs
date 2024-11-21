using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPManager : Trip.Singleton<IAPManager>, IDetailedStoreListener
{
    public event Action<string> OnPurchaseSuccess, OnPurchaseFail;
    Action<bool, string> _completionHandler;
    string removeAdsId = "";
    IStoreController m_StoreController;
    private void Start()
    {
        //try
        //{
        //    //var options = new InitializationOptions()
        //    //    .SetEnvironmentName(Application.isEditor ? "dev" : "production");

        //    //await UnityServices.InitializeAsync();

        //    var result = Task.Run(async () => await UnityServices.InitializeAsync());
        //    if (result.IsCompleted)
        //    {
        //        InitIAP();
        //    }
        //}
        //catch (Exception exception)
        //{
        //    // An error occurred during initialization.
        //    Debug.LogError(exception.Message);
        //} 
        InitIAP();
    }
    private void InitIAP()
    {
        Debug.Log(">>>>>>>>>>>IAPManager Start init iap..........");
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        //Add products that will be purchasable and indicate its type.
        builder.AddProduct(removeAdsId, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log(">>>>>>>IAPManager OnInitialized");

        m_StoreController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log(">>>>>>>IAPManager OnInitializeFailed");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        _completionHandler?.Invoke(false, failureReason.ToString());
        OnPurchaseFail?.Invoke(product.definition.id);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        _completionHandler?.Invoke(true, "Successfull");
        OnPurchaseSuccess?.Invoke(purchaseEvent.purchasedProduct.definition.id);

        return PurchaseProcessingResult.Complete;
    }
  
    public void Purchase()
    {
        if (m_StoreController != null)
        {
            //_completionHandler = completionHandler;
            m_StoreController.InitiatePurchase(removeAdsId);
        }
        //else
        //    completionHandler?.Invoke(false, "IAP not available!");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log(">>>>>>>IAPManager OnInitializeFailed");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
    }
}