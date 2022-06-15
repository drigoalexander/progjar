<<<<<<< HEAD
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentRoomIsVisibleProperty.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
    /// PhotonNetwork.CurrentRoom.IsVisible UI property
    /// </summary>
    public class CurrentRoomIsVisibleProperty : PropertyListenerBase
    {

        public Text Text;

        int _cache = -1;

        void Update()
        {

            if (PhotonNetwork.CurrentRoom != null)
            {
                if ((PhotonNetwork.CurrentRoom.IsVisible && _cache != 1) || (!PhotonNetwork.CurrentRoom.IsVisible && _cache != 0))
                {
                    _cache = PhotonNetwork.CurrentRoom.IsVisible ? 1 : 0;
                    Text.text = PhotonNetwork.CurrentRoom.IsVisible ? "true" : "false";
                    this.OnValueChanged();
                }
            }
            else
            {
                if (_cache != -1)
                {
                    _cache = -1;
                    Text.text = "n/a";
                }
            }
        }
    }
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentRoomIsVisibleProperty.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
    /// PhotonNetwork.CurrentRoom.IsVisible UI property
    /// </summary>
    public class CurrentRoomIsVisibleProperty : PropertyListenerBase
    {

        public Text Text;

        int _cache = -1;

        void Update()
        {

            if (PhotonNetwork.CurrentRoom != null)
            {
                if ((PhotonNetwork.CurrentRoom.IsVisible && _cache != 1) || (!PhotonNetwork.CurrentRoom.IsVisible && _cache != 0))
                {
                    _cache = PhotonNetwork.CurrentRoom.IsVisible ? 1 : 0;
                    Text.text = PhotonNetwork.CurrentRoom.IsVisible ? "true" : "false";
                    this.OnValueChanged();
                }
            }
            else
            {
                if (_cache != -1)
                {
                    _cache = -1;
                    Text.text = "n/a";
                }
            }
        }
    }
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
}