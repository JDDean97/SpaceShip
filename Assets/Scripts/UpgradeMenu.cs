using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeMenu : MonoBehaviour
{
	//reference to pause menu
	public GameObject pauseMenu;

	public GameObject upgradeDialog;
	public GameObject upgradeMenu;
	public GameObject insufficientCredits;
	public GameObject playerHealth;
	public GameObject playerShield;

	public AudioSource ambiance;    //ambient background noise
	public AudioSource engine;      //player's engine - audiosource is attached to the "ship" object
	public AudioSource upgrade;     //audio for upgrade menu
	public AudioSource purchaseSuccess;
	public AudioSource purchaseFail;

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
	public Button btnOK;

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
				//make cursor visible
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
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
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
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
		insufficientCredits.SetActive(false);
		upgradeDialog.SetActive(false);
		upgradeMenu.SetActive(false);

		//add listeners for upgrade menu
		btnShield1.onClick.AddListener(delegate { Purchase(shield1); });
		btnShield2.onClick.AddListener(delegate { Purchase(shield2); });
		btnShield3.onClick.AddListener(delegate { Purchase(shield3); });
		btnLaser1.onClick.AddListener(delegate { Purchase(laser1); });
		btnLaser2.onClick.AddListener(delegate { Purchase(laser2); });
		btnLaser3.onClick.AddListener(delegate { Purchase(laser3); });
		btnRocket1.onClick.AddListener(delegate { Purchase(rocket1); });
		btnRocket2.onClick.AddListener(delegate { Purchase(rocket2); });
		btnRocket3.onClick.AddListener(delegate { Purchase(rocket3); });
		btnOK.onClick.AddListener(NotEnoughCred);
	}

	// Update is called once per frame
	void Update()
	{
		if (pauseMenu.activeSelf)
		{
			upgradeDialog.SetActive(false);
			upgradeMenu.SetActive(false);
		}
	}

	void Purchase(int amount)
	{
		if (GameManager.Instance.pCredits >= amount)
		{
			purchaseSuccess.Play();

			String upgradeName = EventSystem.current.currentSelectedGameObject.name;
			Debug.Log(upgradeName);

			//determine which button was pressed to assign correct bool value
			//currently not very efficient, but working
			if (upgradeName == "btnShield1")
			{
				GameManager.Instance.sUpgrade1 = true;
				btnShield1.interactable = false;
			}
			else if (upgradeName == "btnShield2")
			{
				GameManager.Instance.sUpgrade2 = true;
				btnShield2.interactable = false;
			}
			else if (upgradeName == "btnShield3")
			{
				GameManager.Instance.sUpgrade3 = true;
				btnShield3.interactable = false;
			}
			else if (upgradeName == "btnLaser1")
			{
				GameManager.Instance.lUpgrade1 = true;
				btnLaser1.interactable = false;
			}
			else if (upgradeName == "btnLaser2")
			{
				GameManager.Instance.lUpgrade2 = true;
				btnLaser2.interactable = false;
			}
			else if (upgradeName == "btnLaser3")
			{
				GameManager.Instance.lUpgrade3 = true;
				btnLaser3.interactable = false;
			}
			else if (upgradeName == "btnRocket1")
			{
				GameManager.Instance.rUpgrade1 = true;
				btnRocket1.interactable = false;
			}
			else if (upgradeName == "btnRocket2")
			{
				GameManager.Instance.rUpgrade2 = true;
				btnRocket2.interactable = false;
			}
			else if (upgradeName == "btnRocket3")
			{
				GameManager.Instance.rUpgrade3 = true;
				btnRocket3.interactable = false;
			}
			GameManager.Instance.pCredits -= amount;
			GameManager.Instance.playerCredits.text = GameManager.Instance.pCredits.ToString();
		}
		else
		{
			//player does not have enough credits - display dialog window stating as such
			purchaseFail.Play();
			insufficientCredits.SetActive(true);
		}
	}

	void NotEnoughCred()
    {
		insufficientCredits.SetActive(false);
    }
}
