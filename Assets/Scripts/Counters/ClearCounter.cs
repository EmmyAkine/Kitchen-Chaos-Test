using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
   

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen Object here
            if (player.HasKitchenObject())
            {
                // player iscarrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying anything
            }
        }
        else
        {
            // There is a kitchen object here
            if (player.HasKitchenObject())
            {
                // player iscarrying something
                if (player.GetKitchenObject().TryGetPlate(out PlatesKitchenObject platesKitchenObject))
                {
                    // Player is holding a plate
                    
                    if (platesKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // Player is not carrying a plate but something else
                    if (GetKitchenObject().TryGetPlate(out platesKitchenObject))
                    {
                        // Counter is holding a plate
                        platesKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO());
                        player.GetKitchenObject().DestroySelf();
                    }

                }
            }
            else
            {
                // Player not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }
    }
}
