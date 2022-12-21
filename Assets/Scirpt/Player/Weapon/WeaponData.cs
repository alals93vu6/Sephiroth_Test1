
using UnityEngine;

namespace Project.Player
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "WeaponOffset", order = 0)]

    public class WeaponData : ScriptableObject
    {
        [Header("數值")]
        [SerializeField] public float MoveSpeed;
        [SerializeField] public float StrikeSpeed;
        [SerializeField] public float PlayerX;
        [SerializeField] public float NowShiGapPosX , NowShiGapPosY;
        [SerializeField] public float XAxis;
        [SerializeField] public int LogState;
        [SerializeField] public Vector3 StrikeOffset;
        [SerializeField] public float StrileRange;
    }

}
