using System;
using System.Runtime.InteropServices;


namespace UnityEngine {
	public static class GameObjectExtensions {
		// Methods
		public static GameObject AddChild(this GameObject gObj, string name, [Optional, DefaultParameterValue(null)] Vector3? localPosition, [Optional, DefaultParameterValue(null)] Quaternion? localRotation, [Optional, DefaultParameterValue(null)] Vector3? localScale) {
			GameObject go = new GameObject(name);
			Transform transform = go.transform;
			if (!localPosition.HasValue) {
				localPosition = Vector3.zero;
			}
			if (!localRotation.HasValue) {
				localRotation = Quaternion.identity;
			}
			if (!localScale.HasValue) {
				localScale = Vector3.one;
			}
			transform.SetParent(gObj.transform);
			transform.localPosition = localPosition.Value;
			transform.localRotation = localRotation.Value;
			transform.localScale = localScale.Value;
			return go;
		}

		public static T GetOrAddComponent<T>(this GameObject gObj) where T : Component {
			T t = gObj.GetComponent<T>();
			if (t == null) {
				t = gObj.AddComponent<T>();
			}
			return t;
		}
	}


	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class DefaultParameterValueAttribute : Attribute {
		// Fields
		private object value;

		// Methods
		public DefaultParameterValueAttribute(object value) {
			this.value = value;
		}

		// Properties
		public object Value
		{
			get
			{
				return this.value;
			}
		}
	}

}

