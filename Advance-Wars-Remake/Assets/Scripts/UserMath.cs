using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

	class UserMath {
		private UserMath() {

		}
		public static int Dround(double d)
		{
			return (int)Math.Round(d);
		}
		public static bool About(double x, double y) {
			return x-y<0.00000001;
		}
		public static bool inRange(Unit u1, Unit u2, int r) {
			int x1 = UserMath.Dround(u1.gameObject.transform.position.x+.5);
			int y1 = UserMath.Dround(u1.gameObject.transform.position.y+.5);
			int x2 = UserMath.Dround(u2.gameObject.transform.position.x+.5);
			int y2 = UserMath.Dround(u2.gameObject.transform.position.y+.5);
			for(int i = -1*r; i <= r; i++) {
				for(int j = -1*(r-Math.Abs(i)); j <= (r-Math.Abs(i)) ; j++) {
					if(x1+i==x2&&y1+j==y2)
						return true;
				}
			}
			return false;
		}
	}
