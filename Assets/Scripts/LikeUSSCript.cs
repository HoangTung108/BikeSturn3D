using UnityEngine;
using UnityEngine.Analytics;

public class LikeUSSCript : MonoBehaviour
{
	public void LikeUS_Click_Btn()
	{
		Application.OpenURL("https://www.facebook.com/monstergamesproductions");
		Analytics.CustomEvent("FBLikeClick");
	}
}
