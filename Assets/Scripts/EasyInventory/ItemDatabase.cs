using System.Collections.Generic;
using UnityEngine;

namespace EasyInventory {
	
	[System.Serializable]
	public class ItemDatabase : MonoBehaviour {
		
		public List<Item> itemsList = new List<Item>();

		private void Awake(){
			BuildDatabase();
			
		}
		
		/// <summary>
		/// look for an item by its ID
		/// </summary>
		/// <param name="itemID"></param>
		/// <returns></returns>
		public Item GetItem(int itemID){
			return itemsList.Find(item => item.id == itemID);
		}
		
		/// <summary>
		/// look for an item by its Title
		/// </summary>
		/// <param name="itemTitle"></param>
		/// <returns></returns>
		public Item GetItem(string itemTitle){
			return itemsList.Find(item => item.title == itemTitle);
		}

		private void BuildDatabase(){
			// load previously loaded item 
			//TODO make scriptable object
			// build database at the begining of gameplay 
			// title name should match the sprite of the resource folder 
			Item item1 = new Item(0, "Diamond Sword", "A sword made of diamond", new Dictionary<string, int>() {
				{"Power", 11},
				{"Defence", 22}
			});
			
			Item item2 = new Item(1, "Silver Pick", "A sword made of Silver", new Dictionary<string, int>() {
				{"Power", 5},
				{"Defence", 20}
			});
			
			itemsList.Add(item1);
			itemsList.Add(item2);
		}


		private void BuildDatabase(Item item){
			itemsList.Add(item);
		}
		
		
	}

}