<<<<<<< HEAD
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomListView.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	/// <summary>
	/// PhotonNetwork.GameVersion UI property.
	/// </summary>
	public class GameVersionProperty : MonoBehaviour 
    {
		public Text Text;

		string _cache;

		void Update()
		{
			if (PhotonNetwork.GameVersion != _cache) {
				_cache = PhotonNetwork.GameVersion;
				Text.text = _cache;
			}
		}
	}
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomListView.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	/// <summary>
	/// PhotonNetwork.GameVersion UI property.
	/// </summary>
	public class GameVersionProperty : MonoBehaviour 
    {
		public Text Text;

		string _cache;

		void Update()
		{
			if (PhotonNetwork.GameVersion != _cache) {
				_cache = PhotonNetwork.GameVersion;
				Text.text = _cache;
			}
		}
	}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
}