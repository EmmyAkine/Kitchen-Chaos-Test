using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField] private PlatesKitchenObject platesKitchenObject;
    [SerializeField] private Transform iconTemplate;



    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        platesKitchenObject.OnIngredientAdded += PlatesKitchenObject_OnIngredientAdded;
    }

    private void PlatesKitchenObject_OnIngredientAdded(object sender, PlatesKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in platesKitchenObject.GetKitchenObjectSOList())
        {
            Transform iconTransform =  Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}
