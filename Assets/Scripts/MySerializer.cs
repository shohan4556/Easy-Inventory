using System.Collections;
using System.Collections.Generic;
using System.IO;
using EasyInventory;
using UnityEngine;

public class MySerializer : MonoBehaviour {

	public static MySerializer Instance;
	public Inventory inventory;
	
	private void Awake(){
		Instance = this;
		if (Instance != this) {
			Destroy(this);
		}
	}

	private void Start(){
		inventory = new Inventory();
	}

	public void SaveToJSON(){
		Item item1 = new Item(0, "Diamond Sword", "A sword made of diamond", new Dictionary<string, int>() {
			{"Power", 11},
			{"Defence", 22}
		});
		
		string json = JsonUtility.ToJson(item1);
		Debug.Log(json);
	}

	
	public string gameDataProjectFilePath = "/StreamingAssets/data.json";
	
	public void LoadInventory(){
		string filePath = Application.dataPath + gameDataProjectFilePath;

		if (File.Exists (filePath)) {
			string dataAsJson = File.ReadAllText (filePath);
			JsonUtility.FromJsonOverwrite(dataAsJson, inventory);
				
			Debug.Log("load from JSON "+inventory);
		} 
	}
	
	public void SaveInventory(){
	
		string path = Application.dataPath + gameDataProjectFilePath;
			
		string json = JsonUtility.ToJson(inventory, true);
		File.WriteAllText(path, json);
		Debug.Log(" saved "+json);
	}
}
