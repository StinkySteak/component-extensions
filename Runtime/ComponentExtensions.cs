using UnityEngine;

namespace StinkySteak.ComponentExtensions
{
    public static class ComponentExtensions
    {
        public static bool HasComponent<T>(this Transform transform) where T : Component
        {
            T component = transform.GetComponent<T>();

            return component != null;
        }

        public static bool HasComponent<T>(this Component self, out T component) where T : Component
         => HasComponent(self.transform, out component);
        public static bool HasComponent<T>(this GameObject self, out T component) where T : Component
           => HasComponent(self.transform, out component);

        public static bool TryGetComponentInChildren<T>(this Transform transform, out T component) where T : Component
        {
            component = transform.GetComponentInChildren<T>();

            return component != null;
        }
        public static bool TryGetComponentInChildren<T>(this Component self, out T component) where T : Component
          => TryGetComponentInChildren(self.transform, out component);
        public static bool TryGetComponentInChildren<T>(this GameObject self, out T component) where T : Component
           => TryGetComponentInChildren(self.transform, out component);

        #region TRY_GET_COMP_PARENT

        public static bool TryGetComponentInParentUnsafe<T>(this Transform transform, out T component) where T : Component
        {
            component = transform.parent.GetComponentInChildren<T>();

            return component != null;
        }

        public static bool TryGetComponentInParentUnsafe<T>(this Component self, out T component) where T : Component
           => TryGetComponentInParentUnsafe(self.transform, out component);
        public static bool TryGetComponentInParentUnsafe<T>(this GameObject self, out T component) where T : Component
           => TryGetComponentInParentUnsafe(self.transform, out component);

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

        public static bool TryGetComponentInParent<T>(this Component self, out T component) where T : Component
            => TryGetComponentInParent(self.transform, out component);
        public static bool TryGetComponentInParent<T>(this GameObject self, out T component) where T : Component
           => TryGetComponentInParent(self.transform, out component);
        public static bool TryGetComponentInParent<T>(this MonoBehaviour self, out T component) where T : Component
           => TryGetComponentInParent(self.transform, out component);

        /// <summary>
        /// Try find component in this transform, if null, search in parent
        /// </summary>
        /// <returns></returns>
        public static bool TryGetComponentOrInParent<T>(this Transform transform, out T component) where T : Component
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
        public static bool TryGetComponentOrInParent<T>(this Component self, out T component) where T : Component
            => TryGetComponentOrInParent(self.transform, out component);
        public static bool TryGetComponentOrInParent<T>(this GameObject gameObject, out T component) where T : Component
           => TryGetComponentOrInParent(gameObject.transform, out component);
        
        #endregion
    }
}
