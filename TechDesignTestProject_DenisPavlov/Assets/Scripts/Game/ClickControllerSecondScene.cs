using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickControllerSecondScene : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animatorNote;
    [SerializeField] private Animator animatorStars;
   
   
    [Header("Button")]
    [SerializeField] private GameObject first_scene_transition_button;
    
    private void Update()
    {
        СlickActions();
        Exit();
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
                    case GlobalConstants.DJ_REMOTE_TAG:
                        animatorNote.SetTrigger(GlobalConstants.CLICK_TAG);
                        animatorStars.SetTrigger(GlobalConstants.CLICK_TAG);
                        AudioController.instance.PlaySoundEffect(AudioController.instance.note_group_sfx);
                        break;
                    case GlobalConstants.EXIT_TAG:
                        animatorStars.SetTrigger(GlobalConstants.EXIT_TAG);
                        AudioController.instance.PlaySoundEffect(AudioController.instance.exit_sfx);
                        StartCoroutine(ShowButton());
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void TransitionToFirstScene()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.FIRST_SCENE_TAG);
    }
    
    private void Exit()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(3f);
        first_scene_transition_button.SetActive(true);
    }
}