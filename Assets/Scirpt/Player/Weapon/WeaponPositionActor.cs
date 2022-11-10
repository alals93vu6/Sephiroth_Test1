using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponPositionActor : MonoBehaviour
{
    private ShiActor _shiActor;
    private PlayerActor _playerActor;
    
    private SpriteRenderer weaponSpriteRenderer;
    [SerializeField]private Transform playerPosition;
    [SerializeField]private float endPosition;

    [SerializeField] private int NowState;

    [SerializeField] [Range(0,1)] private float spriteAlpha;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
        _shiActor = FindObjectOfType<ShiActor>();
        _playerActor = FindObjectOfType<PlayerActor>();
        weaponSpriteRenderer = GetComponent<SpriteRenderer>();
        NowState = 3;
        SetColorAlpha(Mathf.Lerp(weaponSpriteRenderer.color.a,0,0.02f));
        SetColorAlpha(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_shiActor.SummonON && !_shiActor.SummonCD)
        {
            SummonPositionActor();
        }

        if (NowState == 1 || NowState == 2)
        {
            OnSummonPress();
        }
        else
        {
            OnSummonRelease();
        }



        PositionMove();
    }

    private async void SummonPositionActor()
    {
        //Debug.Log("VARB");
        if (Input.GetButtonDown("CallWeapon") && NowState == 3 )
        {
            ResetPosition();
            NowState = 4;
            await Task.Delay(400);

            if (NowState == 4)
            {
                PlayerFacingDetected();
            }
        }

        if (Input.GetButtonUp("CallWeapon") && !_shiActor.SummonON && !_shiActor.SummonCD)
        {
            //Debug.Log("VAR");
            NowState = 5;
            EventBus.Post(new CallWeaponDetected());
        }
        
    }

    private void PlayerFacingDetected()
    {
        
    }

    private void PositionMove()
    {
        if (NowState == 1)
        {
            GetEndPoint_R();
        }
        else if (NowState == 2)
        {
            GetEndPoint_L();   
        }

        if (NowState == 1 || NowState == 2)
        {
            transform.position = Vector3.Lerp(this.transform.position,new Vector3(endPosition,playerPosition.position.y,0), 0.015f);
        }

        
        //this.transform.position = new Vector3(endPosition, this.transform.position.y, 0f);
    }

    public void WeaPonReset()
    {
        NowState = 3;
    }

    private void StateDetected()
    {
        /*
        if (_playerActor.IsRight)
        {
            NowState = 1;
        }
        else
        {
            NowState = 2;
        }
        */
    }

    private void GetEndPoint_R()
    {
        endPosition = playerPosition.position.x + 7f;
    }
    
    private void GetEndPoint_L()
    {
        endPosition = playerPosition.position.x - 7f;
    }

    private void ResetPosition()
    {
        this.transform.position = playerPosition.position;
    }

    private void OnSummonPress()
    {
        //Debug.Log("AAA");
        SetColorAlpha(Mathf.Lerp(weaponSpriteRenderer.color.a,1,0.035f));
    }

    private void OnSummonRelease()
    {
        //Debug.Log("BBB");
        SetColorAlpha(Mathf.Lerp(weaponSpriteRenderer.color.a,0,0.02f));
    }

    public void SetColorAlpha(float alpha)
    {
        Color m_color = weaponSpriteRenderer.color;
        m_color.a = alpha;
        weaponSpriteRenderer.color = m_color;
    }

    /* SetColorAlpha(Mathf.Lerp(weaponSpriteRenderer.color.a,1,0.03f)); */







}
