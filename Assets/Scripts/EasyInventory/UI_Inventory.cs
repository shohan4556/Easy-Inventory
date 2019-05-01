using System.Collections.Generic;
using UnityEngine;

namespace EasyInventory {

	public class UI_Inventory : MonoBehaviour {

		// what items do I have 
		// where are those item 
		// ref each one 

		public List<UI_Item> uiItems = new List<UI_Item>();
		public GameObject slotPrefab;
		public Transform slotPanel;
		
		[Header("Inventory Size")]
		[SerializeField] private int INV_SIZE = 20;

		private void Awake(){
			for (int i = 0; i < INV_SIZE; i++) {
				GameObject go = Instantiate(slotPrefab);
				go.transform.SetParent(slotPanel);
				// get the slot image UI_Item
				uiItems.Add(go.GetComponentInChildren<UI_Item>());
			}
		}


		public void UpdateSlot(int slot, Item item){
			//update item slot, it pass item then add item icon, if null then clear icon 
			uiItems[slot].UpdateItem(item);
		}

		public void AddNewItem(Item itemToAdd){
			// find an empty slot 
			UpdateSlot(uiItems.FindIndex(i => i.item == null), itemToAdd);
		}

		public void RemoveItem(Item item){
			UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
		}

	}
}
