using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {
	public class GameManager : MonoBehaviour {

		public int height;

		public ulong[] allElementDatas;

		void InitVolume() {
			allElementDatas = new ulong[height];
		}

		List<int> CheckCrush() {
			List<int> result = new List<int>();
			for (int i = 0; i < allElementDatas.Length; i++) {
				var canCrush = allElementDatas[i] == ulong.MaxValue;
				if (canCrush) {
					result.Add(i);
				}
			}
			return result;
		}

		public void StartGame() {
			InitVolume();
		}
	}
}