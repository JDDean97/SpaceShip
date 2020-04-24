using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
	public GameObject upgradeDialog;
	public GameObject upgradeMenu;
	public GameObject playerHealth;
	public GameObject playerShield;

	public AudioSource ambiance;    //ambient background noise
	public AudioSource engine;      //player's engine - audiosource is attached to the "ship" object
	public AudioSource upgrade;     //audio for upgrade menu

	//upgrade menu buttons
	public Button btnShield1;
	public Button btnShield2;
	public Button btnShield3;
	public Button btnLaser1;
	public Button btnLaser2;
	public Button btnLaser3;
	public Button btnRocket1;
	public Button btnRocket2;
	public Button btnRocket3;
	public Button btnExit;

	//upgrade costs
	public int shield1 = 500;
	public int shield2 = 2000;
	public int shield3 = 5000;
	public int laser1 = 500;
	public int laser2 = 2000;
	public int laser3 = 5000;
	public int rocket1 = 500;
	public int rocket2 = 2000;
	public int rocket3 = 5000;

	void OnTriggerEnter(Collider other)
	{
		//Telling game to actiavte boolean
		if (other.gameObject.tag == "Player")
		{
			upgradeDialog.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		upgradeDialog.SetActive(false);
	}

	void OnGUI()
	{
		if (upgradeDialog.activeSelf)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				upgradeDialog.SetActive(false);
				playerHealth.SetActive(false);
				playerShield.SetActive(false);
				ambiance.Pause();
				engine.Pause();
				Time.timeScale = 0f;
				upgradeMenu.SetActive(true);
				upgrade.Play();
				btnExit.onClick.AddListener(ExitUpgrade);
			}
		}
	}

	void ExitUpgrade()
	{
		upgrade.Pause();
		upgradeMenu.SetActive(false);
		playerHealth.SetActive(true);
		playerShield.SetActive(true);
		upgradeDialog.SetActive(true);
		ambiance.Play();
		engine.Play();
		Time.timeScale = 1f;
	}

	// Start is called before the first frame update
	void Start()
	{
		upgradeDialog.SetActive(false);
		upgradeMenu.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
