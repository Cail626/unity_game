using UnityEngine;
using UnityEngine.UI;

public class Dialog_trigger : MonoBehaviour
{
    public Dialog dialog;
    public bool isInRange;

    private Text interactUI;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialog();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            Dialog_manager.instance.EndDialog();
        }
    }

    void TriggerDialog()
    {
        Dialog_manager.instance.ActionDialog(dialog);
    }
}
