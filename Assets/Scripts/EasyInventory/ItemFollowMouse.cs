using UnityEngine;

public class ItemFollowMouse : MonoBehaviour {

	// Update is called once per frame
	void LateUpdate (){
		transform.position = Input.mousePosition;
	}
}
