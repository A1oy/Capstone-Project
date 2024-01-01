using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<IPoolable>()
            .pool.Release(animator.gameObject);
    }
}
