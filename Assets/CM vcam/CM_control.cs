using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CM_control : MonoBehaviour
{
    public CinemachineVirtualCamera CM;
    float size;
    public float start_size;
    public float end_size;
    //float start_time = 0;
    float time;
    public bool is_ON_CM = false;
    public bool is_OFF_CM = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (is_ON_CM == true)
        {
            time += Time.deltaTime;
            if (time >= 0.01f)
            {
                if (CM.m_Lens.OrthographicSize <= end_size)
                {
                    CM.m_Lens.OrthographicSize = CM.m_Lens.OrthographicSize + 0.1f;
                }
                time = 0;
            }
            if (CM.m_Lens.OrthographicSize >= end_size)
            {
                is_ON_CM = false;
            }
        }

        if (is_OFF_CM == true)
        {
            time += Time.deltaTime;
            if (time >= 0.01f)
            {
                if (CM.m_Lens.OrthographicSize >= start_size)
                {
                    CM.m_Lens.OrthographicSize = CM.m_Lens.OrthographicSize - 0.1f;
                }
                time = 0;
            }
            if (CM.m_Lens.OrthographicSize <= start_size)
            {
                is_OFF_CM = false;
            }
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && is_OFF_CM == false)
        {
            is_ON_CM = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")&& is_ON_CM == false)
        {
            is_OFF_CM = true;

        }
    }
    /* private void OnDrawGizmos()
     {
         Gizmos.color = Color.white;
         Gizmos.DrawWireCube(DetectArea.transform.position, new Vector2(CubeSizeX, CubeSizeY));
     }*/
}
