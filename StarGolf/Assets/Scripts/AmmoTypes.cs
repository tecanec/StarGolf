using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTypes : MonoBehaviour {
 
	public int selectedAmmoType = 0;


	// Use this for initialization
	void Start () {
		SelectAmmoType();
	}
	
	// Update is called once per frame
	void Update () {

		int previuesSelecedWeapon = selectedAmmoType;


		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if (selectedAmmoType >= transform.childCount - 1)
				selectedAmmoType = 0;
			else
				selectedAmmoType++;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (selectedAmmoType >= transform.childCount - 1)
				selectedAmmoType = 0;
			else
				selectedAmmoType++;
		}

		if (previuesSelecedWeapon != selectedAmmoType) ;
		{
			SelectAmmoType();
		}
	}

	void SelectAmmoType()
	{
		int i = 0;
		foreach (Transform AmmoType in transform)
		{
			if (i == selectedAmmoType)
			{
				AmmoType.gameObject.SetActive(true);
			}else
			{
				AmmoType.gameObject.SetActive(false);
			}
			i++;
		}
	}
}
