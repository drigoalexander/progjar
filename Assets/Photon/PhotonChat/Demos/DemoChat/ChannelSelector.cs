<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChannelSelector : MonoBehaviour, IPointerClickHandler
{
    public string Channel;

    public void SetChannel(string channel)
    {
        this.Channel = channel;
        Text t = GetComponentInChildren<Text>();
        t.text = this.Channel;        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChatGui handler = FindObjectOfType<ChatGui>();
        handler.ShowChannel(this.Channel);
    }
}
=======
﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChannelSelector : MonoBehaviour, IPointerClickHandler
{
    public string Channel;

    public void SetChannel(string channel)
    {
        this.Channel = channel;
        Text t = GetComponentInChildren<Text>();
        t.text = this.Channel;        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChatGui handler = FindObjectOfType<ChatGui>();
        handler.ShowChannel(this.Channel);
    }
}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
