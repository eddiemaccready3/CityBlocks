#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("kGOs9IMpi9/0Dyus6mv9mJW5NzRDAh1nYQCwx3QJu05xbqKuM6lUKGZDuGUG+OUJnCHkhna9jC+ZGGUORvR3VEZ7cH9c8D7wgXt3d3dzdnUuOtqrcilPjx0xyUPD3RaQv6OSuDUZjfr1XDZfqM3d+XIYz5ysvQtTCfM7/281PQSvgfiOsNzdmqtRlWnVBIe+MIFe1aPPiV+UARP53Fe7n02faWoWF7Mb5BbEg5BgEuSATMai9Hd5dkb0d3x09Hd3dsP99ebEOcCDm5rrhYXp5H5AtQ2om+1K/2OOFCdU79UNYcstzSFE8d9zSvzEUwAi6lB7HaPlTiCF54iAY6YF9rgH6MdAuDglXFx4Anu9cvMitWGIQz9f36HrjPT1VuYSC3R1d3Z3");
        private static int[] order = new int[] { 5,8,10,5,11,11,7,7,12,12,10,13,13,13,14 };
        private static int key = 118;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
