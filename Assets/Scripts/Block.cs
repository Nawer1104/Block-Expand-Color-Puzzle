using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Animator anim;

    public GameObject vfxDestroy;

    private int state = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (state == 0)
        {
            state = 1;
            anim.SetTrigger("Scale");
        }
        else
        {
            state = 0;
            anim.SetTrigger("Base");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("hehe");

        if (collision != null && collision.gameObject.tag == gameObject.tag)
        {
            GameObject vfx = Instantiate(vfxDestroy, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            gameObject.SetActive(false);
            GameManager.Instance.CheckLevelUp();
        }
        else
        {
            anim.SetTrigger("Base");
        }
    }
}
