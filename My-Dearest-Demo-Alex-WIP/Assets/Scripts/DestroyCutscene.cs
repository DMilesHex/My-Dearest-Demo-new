using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class DestroyCutscene : MonoBehaviour
{
    PlayableDirector dir;
    public TimeCycle tc;
    // Start is called before the first frame update
    void Start()
    {
        dir = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dir.state != PlayState.Playing)
        {

            Destroy(gameObject);
            tc.gameObject.SetActive(true);
        }
        else
        {
            tc.gameObject.SetActive(false);
        }
    }
}
