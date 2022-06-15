<<<<<<< HEAD
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BestRegionInPrefsProperty.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
	/// PhotonNetwork.BestRegionSummaryInPreferences UI property.
    /// </summary>
	public class BestRegionInPrefsProperty : PropertyListenerBase
    {
        public Text Text;

        string _cache;

        void Update()
        {
			if (PhotonNetwork.BestRegionSummaryInPreferences != _cache)
            {
				_cache = PhotonNetwork.BestRegionSummaryInPreferences;

				this.OnValueChanged();

                if (string.IsNullOrEmpty(_cache))
                {
                    Text.text = "n/a";
                }
                else
                {
                    Text.text = _cache;
                }
            }
        }
    }
=======
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BestRegionInPrefsProperty.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
    /// <summary>
	/// PhotonNetwork.BestRegionSummaryInPreferences UI property.
    /// </summary>
	public class BestRegionInPrefsProperty : PropertyListenerBase
    {
        public Text Text;

        string _cache;

        void Update()
        {
			if (PhotonNetwork.BestRegionSummaryInPreferences != _cache)
            {
				_cache = PhotonNetwork.BestRegionSummaryInPreferences;

				this.OnValueChanged();

                if (string.IsNullOrEmpty(_cache))
                {
                    Text.text = "n/a";
                }
                else
                {
                    Text.text = _cache;
                }
            }
        }
    }
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
}