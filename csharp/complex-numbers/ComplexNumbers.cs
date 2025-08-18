public struct ComplexNumber
{
    private double real;
    private double imaginary;
    
    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public double Real()
    {
        return real;
    }

    public double Imaginary()
    {
        return imaginary;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        var a = this.real;
        var b = this.imaginary;
        var c = other.real;
        var d = other.imaginary;

        double realPart = a * c - b * d;
        double imaginaryPart = a * d + b * c;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        var a = this.real;
        var b = this.imaginary;
        var c = other.real;
        var d = other.imaginary;

        double realPart = a + c;
        double imaginaryPart = b + d;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        var a = this.real;
        var b = this.imaginary;
        var c = other.real;
        var d = other.imaginary;

        double realPart = a - c;
        double imaginaryPart = b - d;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public ComplexNumber Div(ComplexNumber other)
    {  
        var a = this.real;
        var b = this.imaginary;
        var c = other.real;
        var d = other.imaginary;

        double realPart = (a * c + b * d) / (c * c + d * d); 
        double imaginaryPart = (b * c - a * d) / (c * c + d * d); 
        
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public double Abs()
    {
        var a = this.real;
        var b = this.imaginary;
        return Math.Sqrt(a * a + b * b);
    }

    public ComplexNumber Conjugate()
    {
        var a = this.real;
        var b = this.imaginary;
        
        return new ComplexNumber(a, -b);
    }
    
    public ComplexNumber Exp()
    {
        var a = this.real;
        var b = this.imaginary;
        var expA = Math.Exp(a);
        var realPart = expA * Math.Cos(b);
        var imaginaryPart = expA * Math.Sin(b);

        return new ComplexNumber(realPart, imaginaryPart);
    }
}