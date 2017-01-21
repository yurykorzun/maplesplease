using UnityEngine;
using UnityEngine.UI;

public class HUDAttackManager : MonoBehaviour {

	public Text PuckValue;
	public Text LeafValue;

	public void SetPucks(int number) {
		PuckValue.text = number.ToString();
	}

	public void SetLeafs(int number) {
		LeafValue.text = number.ToString();
	}

	public void ResetGameValues() {
		PuckValue.text = "0";
		LeafValue.text = "0";
	}

	public void ResetRoundValues() {
		PuckValue.text = "0";
		LeafValue.text = "0";
	}
}
