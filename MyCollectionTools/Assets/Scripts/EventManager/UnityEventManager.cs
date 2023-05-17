using System;
using System.Collections.Generic;

namespace FoxTool
{
    public static class UnityEventManager
    {
        private static Dictionary<string, List<Action<object>>> eventDictionary = new Dictionary<string, List<Action<object>>>();

        public static void SubscribeEvent<T>(string eventName, Action<T> callback)
        {
            if (eventDictionary.ContainsKey(eventName))
            {
                eventDictionary[eventName].Add((data) => callback((T)data));
            }
            else
            {
                var callbackList = new List<Action<object>> { (data) => callback((T)data) };
                eventDictionary[eventName] = callbackList;
            }
        }

        public static void UnsubscribeEvent<T>(string eventName, Action<T> callback)
        {
            if (eventDictionary.ContainsKey(eventName))
            {
                eventDictionary[eventName].Remove((data) => callback((T)data));
            }
        }

        public static void TriggerEvent<T>(string eventName, T eventData = default)
        {
            if (eventDictionary.ContainsKey(eventName))
            {
                var callbackList = eventDictionary[eventName];
                for (int i = 0; i < callbackList.Count; i++)
                {
                    callbackList[i]?.Invoke(eventData);
                }
            }
        }
    }

}
