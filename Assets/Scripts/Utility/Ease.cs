using System;

namespace Ease {
    public delegate float Shape(float p);

    public class Shapes {
        public static float IN_SINE(float progress)
        {
            return 1f - (float)Math.Cos(progress * Math.PI / 2);
        }

        public static float OUT_SINE(float progress)
        {
            return (float)Math.Sin(progress * Math.PI / 2);
        }

        public static float IN_OUT_SINE(float progress)
        {
            return (float)(-(Math.Cos(Math.PI * progress) - 1) / 2);
        }

        public static float IN_QUAD(float progress)
        {
            return progress * progress;
        }

        public static float OUT_QUAD(float progress)
        {
            progress = 1 - progress;
            return 1 - (progress * progress);
        }

        public static float IN_OUT_QUAD(float progress)
        {
            if (progress < 0.5f)
            {
                return 2 * progress * progress;
            }
            
            return (float)(1 - Math.Pow(-2 * progress + 2, 2) / 2);
        }

        public static float OUT_ELASTIC(float progress)
        {
            const float c4 = (float)(2 * Math.PI) / 3;

            if (progress <= 0f)
            {
                return 0f;
            }

            if (progress >= 1f)
            {
                return 1f;
            }

            return (float)(Math.Pow(2, -10 * progress) * Math.Sin((progress * 10 - 0.75) * c4) + 1);
        }

        public static float OUT_BACK(float progress)
        {
            return 1f;
        }
    }
}