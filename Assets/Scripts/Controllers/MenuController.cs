using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private float cardAnimMoveToHidePointDuration = 1f;
    //private float cardAnimMoveHiddenePointDuration = 0.1f;
    //private float cardAnimMoveToVisiblePointDuration = 0.1f;
    //private float cardAnimMoveToStartPointDuration = 1.5f;

    private float sideBarStartPositionX = 0;
    private float buttonStartPositionX = 0;

    private bool isMenuMoving = false;
    private bool isMenuVisible = false;
    public RectTransform SideBarMenu;
    public RectTransform Button;

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    private AudioSource audio;

    private void Start()
    {
        sideBarStartPositionX = SideBarMenu.localPosition.x;
        buttonStartPositionX = Button.localPosition.x;

        audio = this.GetComponent<AudioSource>();

    }
    public void OnClickSoundUp()
    {
        audio.volume += 0.1f;
        Debug.Log("OnClickSoundUp");
    }
    public void OnClickSoundDown()
    {
        audio.volume -= 0.1f;
        Debug.Log("OnClickSoundDown");
    }


    public void OnClickPullDownMenu()
    {
        if (isMenuMoving == false)
        {
            isMenuMoving = true;
            float sideBarWidth = SideBarMenu.rect.width;
            float buttonWidth = Button.rect.width;

            if (isMenuVisible == false)
            {

                SideBarMenu.DOLocalMoveX(Button.localPosition.x - (sideBarWidth / 2) - (buttonWidth / 2), cardAnimMoveToHidePointDuration)
                      .OnComplete(() =>
                              {
                                  SideBarMenu.DOLocalMoveX(sideBarStartPositionX + sideBarWidth, cardAnimMoveToHidePointDuration);
                                  Button.DOLocalMoveX(sideBarStartPositionX + sideBarWidth + (sideBarWidth / 2) + (buttonWidth / 2), cardAnimMoveToHidePointDuration)
                                  .OnComplete(() =>
                                  {
                                      isMenuVisible = true;
                                      isMenuMoving = false;
                                      Button.GetComponentInChildren<Text>().text = "<";

                                  }
                                  );
                              }
                      );
            }
            else
            {

                Button.DOLocalMoveX(buttonStartPositionX, cardAnimMoveToHidePointDuration);
                SideBarMenu.DOLocalMoveX(sideBarStartPositionX, cardAnimMoveToHidePointDuration)
                .OnComplete(() =>
                {
                    isMenuVisible = false;
                    isMenuMoving = false;
                    Button.GetComponentInChildren<Text>().text = ">";
                }
                );
            }
        }
    }

}
