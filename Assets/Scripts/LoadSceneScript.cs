using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{
	private bool loadScene;

	[SerializeField]
	private int scene;

	[SerializeField]
	private Text loadingText;

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space) && !loadScene)
		{
			loadScene = true;
			loadingText.text = "Loading...";
			StartCoroutine(LoadNewScene());
		}
		if (loadScene)
		{
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1f));
		}
	}

	private IEnumerator LoadNewScene()
	{
		yield return new WaitForSeconds(3f);
		AsyncOperation async = Application.LoadLevelAsync(scene);
		while (!async.isDone)
		{
			yield return null;
		}
	}
}
