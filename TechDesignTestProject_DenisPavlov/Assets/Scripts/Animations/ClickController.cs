using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animatorLetter;
    [SerializeField] private Animator animatorEye;
    [Header("Button")]
    [SerializeField] private GameObject second_scene_transition_button;
    
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
                        animatorLetter.SetTrigger(GlobalConstants.CLICK_TAG);
                        animatorEye.SetTrigger(GlobalConstants.CLICK_TAG);
                        AudioController.instance.PlaySoundEffect(AudioController.instance.letter_mix_sfx);
                        break;
                    case GlobalConstants.DOOR_TAG:
                        AudioController.instance.PlaySoundEffect(AudioController.instance.door_knock_sfx);
                        second_scene_transition_button.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void TransitionToSecondScene()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.SECOND_SCENE_TAG);
    }
}