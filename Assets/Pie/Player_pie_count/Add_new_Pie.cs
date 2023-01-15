using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_new_Pie : MonoBehaviour
{
    [Header("Who play with player in the Game")]
    [SerializeField] public bool is_Get_Basic_Attack_pie;
    [SerializeField] public bool is_Get_Basic_Recover_pie;
    [SerializeField] public bool is_Get_Draw_knife_pie;

    [Header("Player_count")]
    [SerializeField] public int player_count = 0;
    public List<int> pie_list_player = new List<int>();

    [Header("Basic_Attack_count")]
    [SerializeField] public int Basic_Attack_count = 0;
    public List<int> pie_list_Basic_Attack = new List<int>();

    [Header("Basic_Recover_count")]
    [SerializeField] public int Basic_Recover_count = 0;
    public List<int> pie_list_Basic_Recover = new List<int>();

    [Header("Draw_knife_count")]
    [SerializeField] public int Draw_knife_count = 0;
    public List<int> pie_list_Draw_knife = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Get_player_pie();
        Get_Basic_Attack_pie();
        Get_Basic_Recover_pie();
        Get_Draw_knife_pie();
    }

    // Update is called once per frame
    void Update()
    {
        stop_pie_fine_now_count(pie_list_player, 0);
        if (is_Get_Basic_Attack_pie) { stop_pie_fine_now_count(pie_list_Basic_Attack, 1); }
        if (is_Get_Basic_Recover_pie) { stop_pie_fine_now_count(pie_list_Basic_Recover, 2); }
        if (is_Get_Draw_knife_pie) { stop_pie_fine_now_count(pie_list_Draw_knife, 3); }
    }
    void Get_player_pie()
    {
        pie_list_player.Add(0);
        pie_list_player.Add(20);
        pie_list_player.Add(40);
        pie_list_player.Add(50);
        pie_list_player.Add(60);
        pie_list_player.Add(80);
        pie_list_player.Add(100);
    }
    void Get_Basic_Attack_pie()
    {
        pie_list_Basic_Attack.Add(0);
        pie_list_Basic_Attack.Add(25);
        pie_list_Basic_Attack.Add(40);
        pie_list_Basic_Attack.Add(65);
        pie_list_Basic_Attack.Add(85);
        pie_list_Basic_Attack.Add(100);
    }
    void Get_Basic_Recover_pie()
    {
        pie_list_Basic_Recover.Add(0);
        pie_list_Basic_Recover.Add(15);
        pie_list_Basic_Recover.Add(40);
        pie_list_Basic_Recover.Add(45);
        pie_list_Basic_Recover.Add(55);
        pie_list_Basic_Recover.Add(75);
        pie_list_Basic_Recover.Add(90);
        pie_list_Basic_Recover.Add(100);
    }
    void Get_Draw_knife_pie()
    {
        pie_list_Draw_knife.Add(0);
        pie_list_Draw_knife.Add(30);
        pie_list_Draw_knife.Add(40);
        pie_list_Draw_knife.Add(60);
        pie_list_Draw_knife.Add(70);
        pie_list_Draw_knife.Add(100);
    }
    void stop_pie_fine_now_count(List<int> i, int SetCount)
    {

        for (int a = 0; a < i.Count; a++)
        {
            if (Now_pie.pie_int >= i[a] && Now_pie.pie_int <= i[a + 1])
            {
                /* Debug.Log("is_work");
                 Debug.Log(i[a]);
                 Debug.Log(i[a + 1]);
                 Debug.Log(a);*/

                if (SetCount == 0)
                {
                    player_count = a;
                }
                if (SetCount == 1)
                {
                    Basic_Attack_count = a;
                }
                if (SetCount == 2)
                {
                    Basic_Recover_count = a;
                }
                if (SetCount == 3)
                {
                    Draw_knife_count = a;
                }

            }

        }

    }
}

