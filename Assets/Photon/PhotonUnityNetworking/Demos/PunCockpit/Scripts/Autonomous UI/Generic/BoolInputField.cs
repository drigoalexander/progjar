<<<<<<< HEAD
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrcCheckToggle.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit Demo
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
    /// Boolean UI UI Toggle input.
    /// </summary>
    public class BoolInputField : MonoBehaviour
    {
        public Toggle PropertyValueInput;

        [System.Serializable]
        public class OnSubmitEvent : UnityEvent<bool> { }

        public OnSubmitEvent OnSubmit;

        bool registered;

        void OnEnable()
        {
            if (!registered)
            {
                registered = true;
                PropertyValueInput.onValueChanged.AddListener(OnValueChanged);
            }
        }

        void OnDisable()
        {
            registered = false;
            PropertyValueInput.onValueChanged.RemoveListener(OnValueChanged);
        }

        void OnValueChanged(bool value)
        {
            OnSubmit.Invoke(PropertyValueInput.isOn);
        }

        public void SetValue(bool value)
        {
            PropertyValueInput.isOn = value;
        }

    }
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrcCheckToggle.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit Demo
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
    /// Boolean UI UI Toggle input.
    /// </summary>
    public class BoolInputField : MonoBehaviour
    {
        public Toggle PropertyValueInput;

        [System.Serializable]
        public class OnSubmitEvent : UnityEvent<bool> { }

        public OnSubmitEvent OnSubmit;

        bool registered;

        void OnEnable()
        {
            if (!registered)
            {
                registered = true;
                PropertyValueInput.onValueChanged.AddListener(OnValueChanged);
            }
        }

        void OnDisable()
        {
            registered = false;
            PropertyValueInput.onValueChanged.RemoveListener(OnValueChanged);
        }

        void OnValueChanged(bool value)
        {
            OnSubmit.Invoke(PropertyValueInput.isOn);
        }

        public void SetValue(bool value)
        {
            PropertyValueInput.isOn = value;
        }

    }
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
}