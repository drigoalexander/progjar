<<<<<<< HEAD
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToggleExpand.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit Demo
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
    /// UI toggle to activate GameObject.
    /// </summary>
    public class ToggleExpand : MonoBehaviour
    {
        public GameObject Content;

        public Toggle Toggle;

        bool _init;

        void OnEnable()
        {
            Content.SetActive(Toggle.isOn);

            if (!_init)
            {
                _init = true;
                Toggle.onValueChanged.AddListener(HandleToggleOnValudChanged);
            }

            HandleToggleOnValudChanged(Toggle.isOn);

        }


        void HandleToggleOnValudChanged(bool value)
        {
            Content.SetActive(value);
        }

    }
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToggleExpand.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit Demo
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
    /// UI toggle to activate GameObject.
    /// </summary>
    public class ToggleExpand : MonoBehaviour
    {
        public GameObject Content;

        public Toggle Toggle;

        bool _init;

        void OnEnable()
        {
            Content.SetActive(Toggle.isOn);

            if (!_init)
            {
                _init = true;
                Toggle.onValueChanged.AddListener(HandleToggleOnValudChanged);
            }

            HandleToggleOnValudChanged(Toggle.isOn);

        }


        void HandleToggleOnValudChanged(bool value)
        {
            Content.SetActive(value);
        }

    }
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
}