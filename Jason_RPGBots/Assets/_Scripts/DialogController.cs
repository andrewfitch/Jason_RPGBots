using System.Text;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    Story _story;
    [SerializeField] TextAsset _dialog;
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Button[] _choiceButtons;

    [ContextMenu("Start Dialog")]
    public void StartDialog()
    {
        _story = new Story(_dialog.text);
        RefreshView();
    }

    void RefreshView()
    {
        StringBuilder storyText = new StringBuilder();
        while (_story.canContinue)
            storyText.AppendLine(_story.Continue());

        _storyText.SetText(storyText);

        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var button = _choiceButtons[i];
            button.onClick.RemoveAllListeners();
            bool choicesExist = i < _story.currentChoices.Count;
            button.gameObject.SetActive(choicesExist);
            if (choicesExist)
            {
                var choice = _story.currentChoices[i];
                button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        }
    }
}