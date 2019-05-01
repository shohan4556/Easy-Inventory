using System.Collections.Generic;
using UnityEngine;

namespace EasyInventory {
	
	[System.Serializable]
	public class Item {
		/// <summary>
		/// item id
		/// </summary>
		public int id;
		/// <summary>
		/// item title 
		/// </summary>
		public string title;
		/// <summary>
		/// item description 
		/// </summary>
		public string description;
		/// <summary>
		/// item icon
		/// </summary>
		public Sprite icon;
		/// <summary>
		/// store items stats like : item power, item damage etc 
		/// </summary>
		public Dictionary<string, int> stats = new Dictionary<string, int>();
		
		/// <summary>
		/// initialize the item
		/// </summary>
		/// <param name="id"></param>
		/// <param name="title"></param>
		/// <param name="description"></param>
		/// <param name="icon"></param>
		/// <param name="stats"></param>
		public Item(int id, string title, string description, Dictionary<string, int> stats){
			this.id = id;
			this.title = title;
			this.description = description;
			//load icon from resources folder
			this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
			this.stats = stats;
		}
		
		/// <summary>
		/// allready it is a item 
		/// </summary>
		/// <param name="item"></param>
		public Item(Item item){
			this.id = item.id;
			this.title = item.title;
			this.description = item.description;
			//load icon from resources folder
			this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.title);
			this.stats = item.stats;
		}
	}

}

