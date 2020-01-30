using UnityEngine;
using UnityEngine.Purchasing.Security;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    IStoreController controller;
    IExtensionProvider extensions;

    const string gameID = "com.GoodDogGames.CityBlocks.";

    void Start()
    {
        InitializePurchasing();
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Use your own products
        builder.AddProduct(gameID + "FullGamePurchase", ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return controller != null && extensions != null;
    }

    /// <summary>
    /// Called when Unity IAP is ready to make purchases.
    /// </summary>
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("IAP: Initialized successfully");
        this.controller = controller;
        this.extensions = extensions;
    }

    /// <summary>
    /// Called when Unity IAP encounters an unrecoverable initialization error.
    ///
    /// Note that this will not be called if Internet is unavailable; Unity IAP
    /// will attempt initialization until it becomes available.
    /// </summary>
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void BuyProductID(string productId)
    {
        productId = gameID + productId;
        if (IsInitialized())
        {
            Product product = controller.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                controller.InitiatePurchase(product);
            }
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }
   
    /// <summary>
    /// Called when a purchase completes.
    ///
    /// May be called at any time after OnInitialized().
    /// </summary>
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        bool validPurchase = true; // Presume valid for platforms with no R.V.
        
        // Unity IAP's validation logic is only included on these platforms.
        #if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX
        // Prepare the validator with the secrets we prepared in the Editor
        // obfuscation window.
        var validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
            AppleTangle.Data(), Application.identifier);

        try
        {
            // On Google Play, result has a single product ID.
            // On Apple stores, receipts contain multiple products.
            var result = validator.Validate(e.purchasedProduct.receipt);
            // For informational purposes, we list the receipt(s)
            Debug.Log("Receipt is valid. Contents:");
            foreach (IPurchaseReceipt productReceipt in result)
            {
                if (productReceipt.productID != e.purchasedProduct.definition.id)
                {
                    Debug.Log("Invalid receipt data");
                    validPurchase = false;
                }
            }
        }
        catch (IAPSecurityException)
        {
            Debug.Log("Invalid receipt, not unlocking content");
            validPurchase = false;
            #if UNITY_EDITOR
            validPurchase = true;
            #endif
        }
        #endif

        //apply the purchasing in case if the transaction is valid
        if (validPurchase)
        {
            switch(e.purchasedProduct.definition.id)
            {
            //Use your own products
                case (gameID + "FullGamePurchase"):
                    //Do your product logic
                    break;
            }
        }

        return PurchaseProcessingResult.Complete;
    }

    /// <summary>
    /// Called when a purchase fails.
    /// </summary>
    public void OnPurchaseFailed(Product p, PurchaseFailureReason r)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", p.definition.storeSpecificId, r));
    }

    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer 
                || Application.platform == RuntimePlatform.OSXPlayer 
                || Application.platform == RuntimePlatform.tvOS) 
        {
            Debug.Log("RestorePurchases started ...");

            var apple = extensions.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions(OnTransactionsRestored);
        }
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    void OnTransactionsRestored(bool success)
    {
        Debug.Log("Transactions restored " + success.ToString());
    } 
}