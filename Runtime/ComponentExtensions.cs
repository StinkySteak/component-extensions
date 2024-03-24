using UnityEngine;

namespace StinkySteak.ComponentExtensions
{
    public static class ComponentExtensions
    {
        public static bool TryGetComponentInChildren<T>(this Transform transform, out T component) where T : Component
        {
            component = transform.GetComponentInChildren<T>();

            return component != null;
        }
        /// <summary>
        /// Return error on null parent
        /// </summary>
        public static bool TryGetComponentInParentUnsafe<T>(this Transform transform, out T component) where T : Component
        {
            component = transform.parent.GetComponentInChildren<T>();

            return component != null;
        }
        public static bool TryGetComponentInParent<T>(this Transform transform, out T component) where T : Component
        {
            if (transform.parent == null)
            {
                component = null;
                return false;
            }

            component = transform.parent.GetComponentInChildren<T>();

            return component != null;
        }
        public static bool HasComponent<T>(this Transform transform) where T : Component
        {
            T component = transform.GetComponent<T>();

            return component != null;
        }
        public static bool TryGetComponentInParent<T>(this Component self, out T component) where T : Component
            => TryGetComponentInParent(self.transform, out component);

        public static bool TryGetComponentInChildren<T>(this Component self, out T component) where T : Component
           => TryGetComponentInChildren(self.transform, out component);

        /// <summary>
        /// Try find component in this transform, if null, search in parent
        /// </summary>
        /// <returns></returns>
        public static bool TryGetComponentOrInParent<T>(this Component transform, out T component) where T : Component
        {
            if (transform.TryGetComponent(out T outCompA))
            {
                component = outCompA;
                return true;
            }

            if (transform.transform.parent == null)
            {
                component = null;
                return false;
            }

            if (transform.transform.parent.TryGetComponent(out T outCompB))
            {
                component = outCompB;
                return true;
            }

            component = null;
            return false;
        }
    }
}
