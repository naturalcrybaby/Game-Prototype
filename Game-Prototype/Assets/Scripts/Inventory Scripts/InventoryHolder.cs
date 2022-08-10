using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem invetorySystem;

    public InventorySystem InventorySystem => invetorySystem;

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    public void Awake()
    {
        invetorySystem = new InventorySystem(inventorySize);
    }
}
