using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour {

	public string buttonToPress = "Fire1";
	public Image darkMask;
	public Text coolDownTextDisplay;

	[SerializeField] private Ability ability;
	[SerializeField] private GameObject weaponHolder;
	private Image myButtonImage;
	private float coolDownDuration;
	private float nextReadyTime;
	private float coolDownTimeLeft;


	void Start () 
	{
		Initialize (ability, weaponHolder); 
	}

	public void Initialize(Ability selectedAbility, GameObject weaponHolder)
	{
		ability = selectedAbility;
		myButtonImage = GetComponent<Image> ();
		myButtonImage.sprite = ability.aSprite;
		darkMask.sprite = ability.aSprite;
		coolDownDuration = ability.aBaseCoolDown;
		ability.Initialize (weaponHolder);
		AbilityReady ();
	}

	// Update is called once per frame
	void Update () 
	{
		bool coolDownComplete = (Time.time > nextReadyTime);
		if (coolDownComplete) 
		{
			AbilityReady ();
			ManaPlayer mana = weaponHolder.GetComponent<ManaPlayer> ();
			if (Input.GetKey (buttonToPress) && mana.CastASpell (ability.manaCost)) {
				ButtonTriggered ();
			} else {
				ShutDownAbility ();
			}
		} else 
		{
			CoolDown();
		}
	}

	private void ShutDownAbility(){
		ability.ShutDown ();
	}
		
	private void AbilityReady()
	{
		coolDownTextDisplay.enabled = false;
		darkMask.enabled = false;
	}

	private void CoolDown()
	{
		coolDownTimeLeft -= Time.deltaTime;
		float roundedCd = Mathf.Round (coolDownTimeLeft);
		coolDownTextDisplay.text = roundedCd.ToString ();
		darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
	}

	private void ButtonTriggered()
	{
		nextReadyTime = coolDownDuration + Time.time;
		coolDownTimeLeft = coolDownDuration;
		darkMask.enabled = true;
		coolDownTextDisplay.enabled = true;
	

		ability.TriggerAbility ();
	}
}