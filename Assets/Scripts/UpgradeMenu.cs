using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
	public bool upgradeCollide = false;

	string upgradeMessage = "Press E to access upgrades.";

	public GameObject upgradeUI;
	public GameObject playerInfo;

	public AudioSource ambiance;    //ambient background noise
	public AudioSource engine;      //player's engine - audiosource is attached to the "ship" object
	public AudioSource upgrade;

	public Button btnExit;

	void OnTriggerEnter(Collider other)
	{
		//Telling game to actiavte boolean
		if (other.gameObject.tag == "Player")
		{
			upgradeCollide = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		upgradeCollide = false;
	}

	void OnGUI()
	{
		if (upgradeCollide == true)
		{
			GUI.Label(new Rect((Screen.width / 2) - 40, Screen.height / 2, 400, 200), upgradeMessage);
			if (Input.GetKeyDown(KeyCode.E))
			{
				upgradeMessage = "";
				playerInfo.SetActive(false);
				ambiance.Pause();
				engine.Pause();
				Time.timeScale = 0f;
				upgradeUI.SetActive(true);
				upgrade.Play();
				btnExit.onClick.AddListener(ExitUpgrade);
			}
		}
	}

	void ExitUpgrade()
	{
		upgrade.Pause();
		upgradeUI.SetActive(false);
		playerInfo.SetActive(true);
		ambiance.Play();
		engine.Play();
		Time.timeScale = 1f;
		upgradeMessage = "Press E to access upgrades.";
	}

	// Start is called before the first frame update
	void Start()
	{
		upgradeUI.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
