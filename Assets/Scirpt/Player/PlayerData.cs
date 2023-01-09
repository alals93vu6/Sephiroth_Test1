using UnityEngine;

namespace Project.Player
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "PlayerOffset", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [Header("數值")]
        [SerializeField] public float runSpeed;
        [SerializeField] public float jumpRange;
        [SerializeField] public Vector3 JumpAera = new Vector3(0, 0, 0);
        [SerializeField] public Vector3 AttackAeraL = new Vector3(0, 0, 0);
        [SerializeField] public Vector3 AttackAeraR = new Vector3(0, 0, 0);
        [SerializeField] public Vector3 hitboxAera = new Vector3(0, 0, 0);
        [SerializeField] public Vector3 HitandDashOffset = new Vector3(0, 0, 0);
        [SerializeField] public Vector2 hitbox = new Vector2(0, 0);
        [SerializeField] public float JumpForce;
        [SerializeField] public Vector3 HitDetected = new Vector3(0, 0, 0);
        [SerializeField] public Vector2 hitDetectedbox = new Vector2(0, 0);
    }
}