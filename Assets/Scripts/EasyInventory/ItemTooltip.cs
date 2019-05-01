using UnityEngine;
using UnityEngine.UI;

namespace EasyInventory {
	
	public class ItemTooltip : MonoBehaviour {
		private Text tooltipText;
		
		// Use this for initialization
		void Start(){
			tooltipText = GetComponentInChildren<Text>();
			gameObject.SetActive(false);
		}

		public void GenerateTooltip(Item item){
			string stateText = "";
			
			if (item.stats.Count > 0) {
				foreach (var stat in item.stats) {
					stateText += stat.Key.ToString() + " : "+stat.Value +"\n";
				}
			}

			string tooltip = string.Format("<b>{0}</b> \n {1} \n \n{2}", item.title, item.description, stateText);
			tooltipText.text = tooltip;
			gameObject.SetActive(true);
		} // end 
		
	}
}