using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;

namespace EasyInventory {

	public class Inventory : MonoBehaviour {
		public List<Item> playerItems;
		public ItemDatabase itemDatabase;
		public UI_Inventory inventoryUI;


		
		private void Start(){
			 playerItems = new List<Item>();
			// added four item of the inventory
			//AddItem(1);
			//AddItem(0);
			//AddItem(1);
			//AddItem(0);
			
			//LoadInventory();
		}
		
		/// <summary>
		/// search item for item id if found then added to the UI and inventory 
		/// </summary>
		/// <param name="itemID"></param>
		public void AddItem(int itemID){
			// found the item to the database 
			Item itemToAdd = itemDatabase.GetItem(itemID);
			// add item to the player inventory 
			playerItems.Add(itemToAdd);
			// add item to the UI 
			inventoryUI.AddNewItem(itemToAdd);
		}
		
		public void AddItem(string itemTitle){
			Item itemToAdd = itemDatabase.GetItem(itemTitle);
			playerItems.Add(itemToAdd);
			
			//Debug.Log("Added  item " + itemToAdd.title);
		}

		public Item CheckForItem(int itemID){
			return playerItems.Find(item => item.id == itemID);
		}
		
		public Item CheckForItem(string itemTitle){
			return playerItems.Find(item => item.title == itemTitle);
		}

		public void RemoveItem(int itemID){
			Item itemToRemove = CheckForItem(itemID);
			if (itemToRemove != null) {
				playerItems.Remove(itemToRemove);
				inventoryUI.RemoveItem(itemToRemove);
			}
		}
		
		public void RemoveItem(string itemTitle){
			Item itemToRemove = CheckForItem(itemTitle);
			if (itemToRemove != null) {
				playerItems.Remove(itemToRemove);
			}
		}
		
		// create a file named data.json 
		private string gameDataProjectFilePath = "/StreamingAssets/data.json";
		
		// save the current state of the inventory 
		public void SaveInventory(){
	
			string path = Application.dataPath + gameDataProjectFilePath;
			// list save 
			string json = JsonUtility.ToJson(this, true);
			File.WriteAllText(path, json);
			Debug.Log(json);
		}

		public Inventory inventory;
		
		public void LoadInventory(){
			string filePath = Application.dataPath + gameDataProjectFilePath;

			if (File.Exists (filePath)) {
				string dataAsJson = File.ReadAllText (filePath);
				JsonUtility.FromJsonOverwrite(dataAsJson, playerItems);
				
				Debug.Log("load from JSON "+ dataAsJson);
			} 
		}
		
	} // end 
}