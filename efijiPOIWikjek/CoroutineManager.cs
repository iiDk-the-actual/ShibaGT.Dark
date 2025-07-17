﻿using System.Collections;
using UnityEngine;

namespace efijiPOIWikjek
{
    public class CoroutineManager : MonoBehaviour
    {
        public static CoroutineManager instance = null;

        private void Awake() =>
            instance = this;

        public static Coroutine RunCoroutine(IEnumerator enumerator) =>
            instance.StartCoroutine(enumerator);

        public static void EndCoroutine(Coroutine enumerator) =>
            instance.StopCoroutine(enumerator);
    }
}
