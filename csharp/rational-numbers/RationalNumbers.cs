    using System.ComponentModel.Design;
    using System.Security.Cryptography;

    public static class RealNumberExtension
    {
        public static double Expreal(this int realNumber, RationalNumber r)
        {
            return Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
        }
    }

    public struct RationalNumber
    {
        public int  Numerator { get; }
        public int Denominator { get; }
        
        public RationalNumber(int numerator, int denominator)
        {
         if (denominator == 0)
             throw new ArgumentException();
         
         Denominator = denominator;
         Numerator = numerator;
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            int numerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
            int denominator = r1.Denominator * r2.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            int numerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
            int denominator = r1.Denominator * r2.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            int numerator = r1.Numerator * r2.Numerator;
            int denominator = r1.Denominator * r2.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            if (r2.Numerator == 0)
                throw new DivideByZeroException();
            
            int numerator = r1.Numerator * r2.Denominator;
            int denominator = r1.Denominator * r2.Numerator;
            return new RationalNumber(numerator, denominator).Reduce();
        }

        public RationalNumber Abs()
        {
            int numerator = Math.Abs(Numerator);
            int denominator = Math.Abs(Denominator);
            return new RationalNumber(numerator, denominator);
        }

        public RationalNumber Reduce()
        {
            int numerator = Numerator;
            int denominator = Denominator;
            
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            
            int a = Math.Abs(numerator);
            int b = Math.Abs(denominator);

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            
            return new RationalNumber(numerator / a, denominator / a);
        }

        public RationalNumber Exprational(int power)
        {
            if (power >= 0)
            {
                return new RationalNumber(
                    (int)Math.Pow(Numerator, power), 
                    (int)Math.Pow(Denominator, power)).Reduce();
            }
            else
            {
                int abs = Math.Abs(power);
                return new RationalNumber((int)Math.Pow(Denominator, abs),
                    (int)Math.Pow(Numerator, abs)).Reduce();
            }
        }

        public double Expreal(int baseNumber)
        {
            return Math.Pow(baseNumber, (double)Numerator / Denominator);
        }

        public override bool Equals(object obj)
        {
            if (obj is  RationalNumber other)
            {
                var r1 = this.Reduce();
                var r2 = other.Reduce();
                return r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator;
                
            }

            return false;
        }

        public override int GetHashCode()
        {
            var r = this.Reduce();
            return HashCode.Combine(r.Numerator, r.Denominator);
        }
    }