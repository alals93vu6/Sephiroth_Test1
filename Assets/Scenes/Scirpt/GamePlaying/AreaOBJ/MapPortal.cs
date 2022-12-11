using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private Vector2 portalSize;
    private bool PortalCD = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox(this.transform.position, portalSize, 0, 4096) && !PortalCD)
        {
            OnTransition();   
        }
    }

    public async void OnTransition()
    {
        PortalCD = true;
        EventBus.Post(new PlayerChangeMapDetected());
        await Task.Delay(500);
        player.transform.position = endPoint.transform.position;
        PortalCD = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        
        Gizmos.DrawWireCube(this.transform.position,portalSize);
    }
}
