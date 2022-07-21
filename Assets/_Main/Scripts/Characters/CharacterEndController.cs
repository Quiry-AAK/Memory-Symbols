using UnityEngine;

namespace _Main.Scripts.Characters
{
    public class CharacterEndController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public bool AmIPlayer;
        
        public void Won()
        {
            animator.SetBool("Winner",true);
        }
    }
}
