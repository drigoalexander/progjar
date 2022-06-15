<<<<<<< HEAD
﻿using UnityEngine;

public class HUDController : MonoBehaviour {

    CanvasGroup canvasGroup;
    float HUDSetting = 0.0f;

    void Start() {

        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0.0f;

        if (PlayerPrefs.HasKey("HUD")) {

            HUDSetting = PlayerPrefs.GetFloat("HUD");
        }
    }

    // Update is called once per frame
    void Update() {

        if (RaceMonitor.racing) {

            canvasGroup.alpha = HUDSetting;
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            canvasGroup.alpha = canvasGroup.alpha == 1 ? 0 : 1;
            HUDSetting = canvasGroup.alpha;
            PlayerPrefs.SetFloat("HUD", canvasGroup.alpha);
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    CanvasGroup canvasGroupHUD;
    float HUDSetting = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroupHUD = GetComponentInParent<CanvasGroup>();
        canvasGroupHUD.alpha = 0.0f;

        if (PlayerPrefs.HasKey("HUDSetting"))
        {
            HUDSetting = PlayerPrefs.GetFloat("HUDSetting");
            canvasGroupHUD.alpha = HUDSetting;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!RaceMonitor.racing)
        {
            canvasGroupHUD.alpha = 0.0f;
            return;
        }

        canvasGroupHUD.alpha = HUDSetting;

        if (Input.GetKeyDown(KeyCode.H))
        {
            canvasGroupHUD.alpha = (canvasGroupHUD.alpha == 1.0f) ? 0.0f : 1.0f;
            HUDSetting = canvasGroupHUD.alpha;
            PlayerPrefs.SetFloat("HUDSetting", HUDSetting);
        }
    }
}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
