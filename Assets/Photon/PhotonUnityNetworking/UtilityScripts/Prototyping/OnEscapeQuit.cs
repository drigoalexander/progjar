<<<<<<< HEAD
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnJoinedInstantiate.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Utilities, 
// </copyright>
// <summary>
//  This component will quit the application when escape key is pressed
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Diagnostics;

namespace Photon.Pun.UtilityScripts
{
    /// <summary>
    /// This component will quit the application when escape key is pressed
    /// </summary>
    public class OnEscapeQuit : MonoBehaviour
    {
        [Conditional("UNITY_ANDROID"), Conditional("UNITY_IOS")]
        public void Update()
        {
            // "back" button of phone equals "Escape". quit app if that's pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnJoinedInstantiate.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Utilities, 
// </copyright>
// <summary>
//  This component will quit the application when escape key is pressed
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Diagnostics;

namespace Photon.Pun.UtilityScripts
{
    /// <summary>
    /// This component will quit the application when escape key is pressed
    /// </summary>
    public class OnEscapeQuit : MonoBehaviour
    {
        [Conditional("UNITY_ANDROID"), Conditional("UNITY_IOS")]
        public void Update()
        {
            // "back" button of phone equals "Escape". quit app if that's pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
}