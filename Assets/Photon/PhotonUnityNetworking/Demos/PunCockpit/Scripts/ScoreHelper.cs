<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class ScoreHelper : MonoBehaviour {


	public int Score;

	int _currentScore;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (PhotonNetwork.LocalPlayer !=null && Score != _currentScore)
		{
			_currentScore = Score;
			PhotonNetwork.LocalPlayer.SetScore(Score);
		}

	}
}
=======
﻿using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class ScoreHelper : MonoBehaviour {


	public int Score;

	int _currentScore;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (PhotonNetwork.LocalPlayer !=null && Score != _currentScore)
		{
			_currentScore = Score;
			PhotonNetwork.LocalPlayer.SetScore(Score);
		}

	}
}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
