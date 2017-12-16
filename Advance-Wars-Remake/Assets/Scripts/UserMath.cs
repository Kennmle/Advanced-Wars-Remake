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

	}
