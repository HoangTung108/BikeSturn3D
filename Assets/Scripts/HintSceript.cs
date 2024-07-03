using UnityEngine;
using UnityEngine.UI;

public class HintSceript : MonoBehaviour
{
	public Text HintText;

	private int Counter;

	private void OnEnable()
	{
		Counter = Random.Range(0, 4);
		if (Counter == 0)
		{
			if (PlayerPrefs.GetInt("LanguageSet") == 0)
			{
				HintText.text = "Whenever bike stucks press Reset button to reset the bike.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 1)
			{
				HintText.text = "每当自行车卡住时，按“重置”按钮重置自行车。";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 2)
			{
				HintText.text = "Chaque fois que le vélo bloque Appuyez sur le bouton RESET pour réinitialiser le vélo.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 3)
			{
				HintText.text = "Immer wenn Bike Stucks drücken Reset-Taste, um das Fahrrad zurückzusetzen.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 4)
			{
				HintText.text = "Cuando la bicicleta se atasca, pulse el botón RESET para restablecer la bicicleta.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 5)
			{
				HintText.text = "जब भ\u0940 ब\u093eइक अटक प\u094dर\u0947स र\u0940स\u0947ट बटन ब\u093eइक र\u0940स\u0947ट करन\u0947 क\u0947 ल\u093fए ।";
			}
			else
			{
				HintText.text = "Whenever bike stucks press Reset button to reset the bike.";
			}
		}
		else if (Counter == 1)
		{
			if (PlayerPrefs.GetInt("LanguageSet") == 0)
			{
				HintText.text = "if any stunt difficult to pass try on another bike and Trail bike is best for all stunts.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 1)
			{
				HintText.text = "如果任何特技难以通过尝试在另一辆自行车和越野自行车是最好的所有特技。";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 2)
			{
				HintText.text = "Si un Stunt difficile à passer essayer sur un autre vélo et le vélo de piste est le meilleur pour tous les cascades.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 3)
			{
				HintText.text = "Wenn ein Stunt schwer zu passieren versuchen, auf einem anderen Fahrrad und Trail-Bike ist am besten für alle Stunts.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 4)
			{
				HintText.text = "Si cualquier truco difícil de pasar prueba en otra moto y Trail Bike es mejor para todos los trucos.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 5)
			{
				HintText.text = "क\u093fस\u0940 भ\u0940 स\u094dट\u0902ट म\u0941श\u094dक\u093fल एक और ब\u093eइक और ट\u094dर\u0947ल ब\u093eइक पर क\u094bश\u093fश प\u093eस करन\u0947 क\u0947 ल\u093fए सभ\u0940 स\u094dट\u0902ट क\u0947 ल\u093fए सबस\u0947 अच\u094dछ\u093e ह\u0948 ।";
			}
			else
			{
				HintText.text = "if any stunt difficult to pass try on another bike and Trail bike is best for all stunts.";
			}
		}
		else if (Counter == 2)
		{
			if (PlayerPrefs.GetInt("LanguageSet") == 0)
			{
				HintText.text = "For successful landing bike press brake button in air and front wheel up.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 1)
			{
				HintText.text = "为成功的着陆自行车按刹车按钮在空气和前轮。";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 2)
			{
				HintText.text = "Pour un vélo d'atterrissage réussi presser le bouton de frein dans l'air et la roue avant vers le haut.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 3)
			{
				HintText.text = "Für eine erfolgreiche Landung Bike pressbremse Knopf in Luft und Vorderrad nach oben.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 4)
			{
				HintText.text = "Para la bici de aterrizaje acertada Presione el botón del freno en el aire y la rueda delantera para arriba.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 5)
			{
				HintText.text = "हव\u093e और स\u093eमन\u0947 पह\u093fय\u093e अप म\u0947\u0902 सफल ल\u0948\u0902ड\u093f\u0902ग ब\u093eइक प\u094dर\u0947स ब\u094dर\u0947क बटन क\u0947 ल\u093fए ।";
			}
			else
			{
				HintText.text = "For successful landing bike press brake button in air and front wheel up.";
			}
		}
		else if (Counter == 3)
		{
			if (PlayerPrefs.GetInt("LanguageSet") == 0)
			{
				HintText.text = "Land Parachute on building by giving direction through arrow buttons.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 1)
			{
				HintText.text = "通过箭头按钮给出方向, 在建筑物上降落降落伞。";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 2)
			{
				HintText.text = "Débarquez le parachute sur la construction en donnant la direction par des boutons de flèche.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 3)
			{
				HintText.text = "Land Fallschirm auf dem Gebäude, indem Sie Richtung durch Pfeiltasten.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 4)
			{
				HintText.text = "Aterrice el paracaídas en la construcción dando la dirección con los botones de flecha.";
			}
			else if (PlayerPrefs.GetInt("LanguageSet") == 5)
			{
				HintText.text = "एर\u094b बटन\u094b\u0902 क\u0947 म\u093eध\u094dयम स\u0947 द\u093fश\u093e द\u0947कर ब\u093fल\u094dड\u093f\u0902ग पर ल\u0948\u0902ड प\u0948र\u093eश\u0942ट ।";
			}
			else
			{
				HintText.text = "Land Parachute on building by giving direction through arrow buttons.";
			}
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 0)
		{
			HintText.text = "Whenever bike stucks press Reset button to reset the bike.";
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 1)
		{
			HintText.text = "每当自行车卡住时，按“重置”按钮重置自行车。";
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 2)
		{
			HintText.text = "Chaque fois que le vélo bloque Appuyez sur le bouton RESET pour réinitialiser le vélo.";
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 3)
		{
			HintText.text = "Immer wenn Bike Stucks drücken Reset-Taste, um das Fahrrad zurückzusetzen.";
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 4)
		{
			HintText.text = "Cuando la bicicleta se atasca, pulse el botón RESET para restablecer la bicicleta.";
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 5)
		{
			HintText.text = "जब भ\u0940 ब\u093eइक अटक प\u094dर\u0947स र\u0940स\u0947ट बटन ब\u093eइक र\u0940स\u0947ट करन\u0947 क\u0947 ल\u093fए ।";
		}
		else
		{
			HintText.text = "Whenever bike stucks press Reset button to reset the bike.";
		}
	}
}
