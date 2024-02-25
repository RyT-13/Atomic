using UnityEngine;

namespace Utils
{
    public class MonoHelper : MonoBehaviour
    {
        public static T CreateInstance<T>(T pref, Vector3 position = default) where T : MonoBehaviour
        {
            return Instantiate(pref, position, Quaternion.identity);
        }

        public static void DestroyGO(GameObject obj)
        {
            Destroy(obj);
        }
    }
}
