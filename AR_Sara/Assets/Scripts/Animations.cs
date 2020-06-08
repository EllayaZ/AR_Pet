using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    private string animationState = "Running";

    private void Update()
    {
        EnableTouchScreen();
    }

    /// <summary>
    /// Enables the touch on the screen to switch between
    /// Waiting and Running animation at any point.
    /// </summary>
    private void EnableTouchScreen()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.transform.CompareTag("Sara"))
                    {
                        if (animationState != "Waiting")
                        {
                            gameObject.GetComponent<Animator>().SetBool("Running", false);
                            gameObject.GetComponent<Animator>().SetBool("Waiting", true);
                            animationState = "Waiting";
                        }
                        else
                        {
                            gameObject.GetComponent<Animator>().SetBool("Running", true);
                            gameObject.GetComponent<Animator>().SetBool("Waiting", false);
                            animationState = "Running";
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Trigger animations from UI buttons.
    /// </summary>
    public void TriggerAnimation(string newAnimationState)
    {
        gameObject.GetComponent<Animator>().SetBool(animationState, false);
        gameObject.GetComponent<Animator>().SetTrigger(newAnimationState);
    }
}