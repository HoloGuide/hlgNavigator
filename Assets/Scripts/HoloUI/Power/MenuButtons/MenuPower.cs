using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPower : MonoBehaviour {

    public GameObject cursor;
    public GameObject menu;
    public GameObject menuBar;
    public GameObject eventManager;
    public GameObject effectMap;
    public GameObject effectRoute;
    public GameObject effectClock;

    private HoloGuideInput manipulateHand;
    private ContentsVisible menuState;
    private Config powerSetting;

    
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();
            powerSetting = eventManager.GetComponent<Config>();
            menuState = eventManager.GetComponent<ContentsVisible>();

            if (manipulateHand.airTap == true)
            {
                if(powerSetting.menuPower == false)
                {
                    manipulateHand.airTap = false;
                    menu.SetActive(true);
                    menuState.MenuAlive(); 
                    powerSetting.menuPower = true;
                  
                }
                else if (powerSetting.menuPower == true && menuState.editMode == true)
                {
                    manipulateHand.airTap = false;
                    menu.SetActive(true);
                    menuState.editMode = false;
                    menuState.MenuAlive();
                    effectMap.SetActive(false);
                    effectRoute.SetActive(false);
                    effectClock.SetActive(false);


                }
               //(powerSetting.menuPower == true && menuState.editMode == false)
               else
                {
                    manipulateHand.airTap = false;
                    powerSetting.menuPower = false;
                    menu.SetActive(false);
                    menuState.MenuDead();
                    
                }

            }
            
        }

    }


}
