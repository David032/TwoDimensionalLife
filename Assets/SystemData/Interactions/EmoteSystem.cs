using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

namespace TwoDLife.Interactions
{
    public enum Emotes
    {
        Blank,
        Happy,
        Sad,
        Angry
    }

    public class EmoteSystem : MonoBehaviour
    {
        List<(string, GameObject)> Emotes = new();

        // Start is called before the first frame update
        void Start()
        {
            var emotes = GetComponentsInChildren<SpriteRenderer>();
            foreach (var emote in emotes)
            {
                Emotes.Add((emote.gameObject.name, emote.gameObject));
                emote.gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Show(Emotes emote)
        {
            try
            {
                var emoteToShow = Emotes.Select(x => x).Where(x => x.Item1 == emote.ToString()).First();
                StartCoroutine(nameof(ShowEmote), emoteToShow.Item2);
            }
            catch (System.Exception)
            {
                var blankEmote = Emotes.Select(x => x).Where(x => x.Item1 == "Blank").First();
                StartCoroutine(nameof(ShowEmote), blankEmote.Item2);
            }
        }

        IEnumerator ShowEmote(GameObject go)
        {
            Emotes.ForEach(x => x.Item2.SetActive(false));
            go.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            go.SetActive(false);
        }
    }
}

