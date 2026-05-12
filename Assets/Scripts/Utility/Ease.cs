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
            const double c1 = 1.70158f;
            const double c3 = c1 + 1;

            return (float)(1 + c3 * Math.Pow(progress - 1, 3) + c1 * Math.Pow(progress - 1, 2));
        }

        public static float OUT_BOUNCE(float progress)
        {
            const double n1 = 7.5625;
            const double d1 = 2.75;

            if (progress < 1 / d1) {
                return (float)(n1 * progress * progress);
            } else if (progress < 2 / d1) {
                progress -= (float)(1.5 / d1);
                return (float)(n1 * progress * progress + 0.75);
            } else if (progress < 2.5 / d1) {
                progress -= (float)(2.25 / d1);
                return (float)(n1 * progress * progress + 0.9375);
            } else {
                progress -= (float)(2.625 / d1);
                return (float)(n1 * progress * progress + 0.984375);
            }
        }
    }
}