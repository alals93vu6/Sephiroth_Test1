using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewBaseMap : MonoBehaviour
{
    [Header("材質球")]
    [SerializeField] public Material base_map;
    [Header("編號")]
    [SerializeField] public int base_unl;
    Renderer m_renderer;
    public List<Texture> SaveTexture = new List<Texture>();
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_renderer.material.SetTexture("_BaseMap",SaveTexture[base_unl]);
    }
}
