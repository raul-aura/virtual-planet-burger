using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    private PlayableDirector timelineDirector;

    void Start()
    {
        timelineDirector = GetComponent<PlayableDirector>(); //This script will be in the same object as the PlayableDirector.
    }

    public void InitializeTimeline()
    {
        timelineDirector.time = 0;
        timelineDirector.Play();
    }

    /* Simple script to initialize the timer timeline. */
}
