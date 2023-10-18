using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAnimate : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;
    
    private void Update()
    {
        СlickActions();
    }

    private void СlickActions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                
                switch (hit.collider.tag)
                {
                    case GlobalConstants.ELEPHANT_TAG:
                        _animator.SetTrigger(GlobalConstants.CLICK_TAG);
                        break;
                   
                    default:
                        break;
                }
            }
        }
    }
}