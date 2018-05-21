
namespace L7 {

	public abstract class Singleton<T> where T : Singleton<T>, new() {

		protected static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null) {
					_instance = new T();
				}
				return _instance;
			}
		}

		public virtual void Release() {
			_instance = null;
		}

	}

}
