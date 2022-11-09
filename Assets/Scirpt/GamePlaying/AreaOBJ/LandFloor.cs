using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LandFloor : MonoBehaviour
{
    #region Instance
    static public LandFloor instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    [SerializeField] private float CubeSizeX;
    [SerializeField] private float CubeSizeY;
    [SerializeField] private float SizeRamX;
    [SerializeField] private float SizeRamY;
    

    [SerializeField] private bool IsWriting;
    [SerializeField] private bool ActiveLand;

    [SerializeField] private LayerMask PlayerLayer;

    [SerializeField] private GameObject DetectArea;
    [SerializeField] private GameObject NowPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SizeRamX = CubeSizeX;
        SizeRamY = CubeSizeY;
    }

    // Update is called once per frame
    void Update()
    {
        WritimgDetect();
        
        OnPlayerFloorCross();
    }

    private void WritimgDetect()
    {
        if (Physics2D.OverlapBox(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY),0,PlayerLayer))
        {
            //Debug.Log("On");
            OnAllowed();
            IsWriting = true;
        }
        else
        {
            //Debug.Log("Off");
            OnNotAllowed();
            IsWriting = false;
        }
    }

    public async void OnPlayerFloorCross()
    {
        if (Input.GetAxis("Vertical") <= -0.6f && Input.GetButtonDown("AKey"))
        {
            if (IsWriting)
            {
                this.gameObject.layer = LayerMask.NameToLayer("Default");
                CubeSizeX = 0;
                CubeSizeY = 0;

                await Task.Delay(800);

                CubeSizeX = SizeRamX;
                CubeSizeY = SizeRamY;
                this.gameObject.layer = LayerMask.NameToLayer("JumpFloor");

            }
        }
        
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            if (IsWriting)
            {
                this.gameObject.layer = LayerMask.NameToLayer("Default");
                CubeSizeX = 0;
                CubeSizeY = 0; 

                await Task.Delay(800);

                CubeSizeX = SizeRamX;
                CubeSizeY = SizeRamY;
                this.gameObject.layer = LayerMask.NameToLayer("JumpFloor");

            }
        }

        
    }

    private void OnAllowed()
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        //Debug.Log("IsUP");
    }

    private void OnNotAllowed()
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //Debug.Log("IsDown");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY));
    }


    /*
    private void WritingDetect()
    {
        if (Physics2D.OverlapBox(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY),0,PlayerLayer))
        {
            
            //OnAllowed();
            if (this.transform.position.y + 0.7f <= NowPlayer.transform.position.y)
            {
                IsWriting = true;
                
                OnAllowed();
            }
            else
            {
                IsWriting = false;
                
                OnNotAllowed();
            }
            //Debug.Log("ISON");
        }
        else 
        {
            IsWriting = false;
            
            OnAllowed();
            
            if (this.transform.position.y  <= NowPlayer.transform.position.y)
            {
                OnAllowed();
            }
            else
            {
                OnNotAllowed();
            }
            
            
        }
    }
    
    private async void OnFloorCross()
    {
        if (Input.GetAxis("VerticalA") <= -0.6f && Input.GetButtonDown("AKey"))
        {
            //Debug.Log("PlayerDown");
            ActiveLand = true;
            OnNotAllowed();

            await Task.Delay(1000);
            
            OnAllowed();
            ActiveLand = false;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("PlayerDown");
            ActiveLand = true;
            OnNotAllowed();

            await Task.Delay(1000);
            
            OnAllowed();
            ActiveLand = false;
        }
    }
    
    
        if (Physics2D.OverlapBox(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY),0,PlayerLayer))
        {
            IsWriting = true;
            
            await Task.Delay(300);
            
            OnAllowed();
            //Debug.Log("ISON");
        }
        else 
        {
            IsWriting = false;
            
            if (this.transform.position.y + 1.5f <= NowPlayer.transform.position.y)
            {
                await Task.Delay(300);
                
                OnAllowed();
            }
            else
            {
                OnNotAllowed();
            }
            
        }
        
        
        gameObject.layer = LayerMask.NameToLayer("JumpFloor");
        Debug.Log("UP");
        */
    
}
