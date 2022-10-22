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

    [SerializeField] [Range(0,1)] private float spriteAlpha;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
        _shiActor = FindObjectOfType<ShiActor>();
        _playerActor = FindObjectOfType<PlayerActor>();

        weaponSpriteRenderer = GetComponent<SpriteRenderer>();
        SetColorAlpha(1);
    }

    // Update is called once per frame
    void Update()
    {
        SummonPositionActor();
    }

    private async void SummonPositionActor()
    {
        if (Input.GetButton("CallWeapon") && _shiActor.SummonON == false && _shiActor.SummonCD == false)
        {
            ResetPosition();
            if (_playerActor.IsRight)
            {
                GetEndPoint_R();
                await Task.Delay(800);
                Debug.Log("VAR");
                PositionMove();
            }
            else
            {
                GetEndPoint_L();
                await Task.Delay(800);
                Debug.Log("VAR");
                PositionMove();
            }
        }
        
        if (Input.GetButtonUp("CallWeapon"))
        {
            Debug.Log("VARB");
            //EventBus.Post(new CallWeaponDetected());
        }
        
    }

    private void PositionMove()
    {
        this.transform.position = Vector3.Lerp(playerPosition.position, new Vector3(endPosition,playerPosition.position.y), 0.05f);
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
        SetColorAlpha(Mathf.Lerp(weaponSpriteRenderer.color.a,1,0.05f));
    }

    private void OnSummonRelease()
    {
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
