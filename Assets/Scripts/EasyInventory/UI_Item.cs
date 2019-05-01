using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EasyInventory {

	public class UI_Item : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

		public Item item;

		private Image spriteImage;
		private UI_Item seletedItem;
		private ItemTooltip itemTooltip;

		void Awake(){
			seletedItem = GameObject.FindGameObjectWithTag("Player").GetComponent<UI_Item>();
			spriteImage = GetComponent<Image>();
			itemTooltip = FindObjectOfType<ItemTooltip>();
			UpdateItem(null);
		}

		public void UpdateItem(Item item){
			this.item = item;
			
			if (this.item != null) {
				spriteImage.color = Color.white;
				spriteImage.sprite = item.icon;
				//Debug.Log(item.icon.name);
			}
			else {
				spriteImage.color = Color.clear;
			}
		}

		public void OnPointerDown(PointerEventData eventData){
			if (this.item != null) {
				if (seletedItem.item != null) {
					Item clone = new Item(seletedItem.item);
					seletedItem.UpdateItem(this.item);
					UpdateItem(clone);
				}
				else {
					seletedItem.UpdateItem(this.item);
					UpdateItem(null);
				}
			}
			else if (seletedItem.item != null) {
				UpdateItem(seletedItem.item);
				seletedItem.UpdateItem(null);
			}
		} // end 

		public void OnPointerEnter(PointerEventData eventData){
			if (this.item != null) {
				//itemTooltip.gameObject.transform.position = eventData.position;
				//Debug.Log("enable tooltip "+eventData.pointerCurrentRaycast.gameObject.name);
				itemTooltip.GenerateTooltip(this.item);
			}
		}

		public void OnPointerExit(PointerEventData eventData){
			Debug.Log("disable tooltip");
			itemTooltip.gameObject.SetActive(false);
		}
	}

}