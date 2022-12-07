using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public Text deadText;
    public GameObject Transition;
    public SpriteRenderer TransititonRenderer;
    [SerializeField] public bool IsTransition;
    // Start is called before the first frame update
    void Start()
    {
        TransititonRenderer = Transition.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MapChange();
    }

    public void PlayerDead()
    {
        
    }

    public async void MapChange()
    {
        if (IsTransition)
        {
            SetColorAlpha(Mathf.Lerp(TransititonRenderer.color.a,1,0.08f));
            await Task.Delay(1000);
            IsTransition = false;
        }
        else
        {
            SetColorAlpha(Mathf.Lerp(TransititonRenderer.color.a,0,0.08f));
        }

        
    }
    
    public void SetColorAlpha(float alpha)
    {
        Color m_color = TransititonRenderer.color;
        m_color.a = alpha;
        TransititonRenderer.color = m_color;
    }
}
