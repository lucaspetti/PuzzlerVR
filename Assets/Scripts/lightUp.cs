using UnityEngine;
using System.Collections;

public class lightUp : MonoBehaviour {
	public Material lightUpMaterial;
	public GameObject gameLogic;
	private Material defaultMaterial;

	// Use this for initialization
	void Start () {
		defaultMaterial = this.GetComponent<MeshRenderer> ().material;
		
		gameLogic = GameObject.Find ("gameLogic");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void patternLightUp(float duration) {
		StartCoroutine(lightFor(duration));
	}


	public void gazeLightUp() {
		this.GetComponent<MeshRenderer>().material = lightUpMaterial;
		/*this.GetComponent<GvrAudioSource>().Play();

		gameLogic.GetComponent<GameLogic>().playerSelection(this.gameObject);
*/

	}
	public void playerSelection() {
		gameLogic.GetComponent<GameLogic>().playerSelection(this.gameObject);
		this.GetComponent<GvrAudioSource>().Play();
	}
	public void aestheticReset() {
		this.GetComponent<MeshRenderer>().material = defaultMaterial; 
	}

	public void patternLightUp() { //Lightup behavior when the pattern shows.
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; 
		this.GetComponent<GvrAudioSource> ().Play (); 
	}


	IEnumerator lightFor(float duration) { //Light us up for a duration.  Used during the pattern display
		patternLightUp ();
		yield return new WaitForSeconds(duration-.1f);
		aestheticReset ();
	}
}
