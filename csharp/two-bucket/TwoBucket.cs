public enum Bucket
{
    One,
    Two
}

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}

public class TwoBucket
{
    private int bucketOneCapacity;
    private int bucketTwoCapacity;
    private Bucket startBucket;
    private int bucketOneAmount;
    private int bucketTwoAmount;
    private int moves = 0;

    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        bucketOneCapacity = bucketOne;
        bucketTwoCapacity = bucketTwo;
        this.startBucket = startBucket;

        if (startBucket == Bucket.One)
            bucketOneAmount = bucketOneCapacity;
        if (startBucket == Bucket.Two)
            bucketTwoAmount = bucketTwoCapacity;
        moves++;
    }

    public TwoBucketResult Measure(int goal)
    {
        if (goal > bucketOneCapacity && goal > bucketTwoCapacity)
            throw new ArgumentException();

        int a = bucketOneCapacity;
        int b = bucketTwoCapacity;
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        int gcd = a;

        if (goal % gcd != 0)
            throw new ArgumentException();

        int safety = 1000;
        while (bucketOneAmount != goal && bucketTwoAmount != goal && safety-- > 0)
        {
            
            if (startBucket == Bucket.One && goal == bucketTwoCapacity)
            {
                return new TwoBucketResult { Moves = 2, GoalBucket = Bucket.Two, OtherBucket = bucketOneCapacity };
            }
            if (startBucket == Bucket.Two && goal == bucketOneCapacity)
            {
                return new TwoBucketResult { Moves = 2, GoalBucket = Bucket.One, OtherBucket = bucketTwoCapacity };
            }
            
            bool empty = (startBucket == Bucket.One && bucketOneAmount == 0) ||
                         (startBucket == Bucket.Two && bucketTwoAmount == 0);

            if (empty)
            {
                if (startBucket == Bucket.One)
                    bucketOneAmount = bucketOneCapacity;
                else
                    bucketTwoAmount = bucketTwoCapacity;
                moves++;
                continue;
            }

            bool full = (startBucket == Bucket.One && bucketTwoAmount == bucketTwoCapacity) ||
                        (startBucket == Bucket.Two && bucketOneAmount == bucketOneCapacity);

            if (full)
            {
                if (startBucket == Bucket.One)
                    bucketTwoAmount = 0;
                else
                    bucketOneAmount = 0;
                moves++;
                continue;
            }

            int amountToPour;
            if (startBucket == Bucket.One)
                amountToPour = Math.Min(bucketOneAmount, bucketTwoCapacity - bucketTwoAmount);
            else
            {
                amountToPour = Math.Min(bucketTwoAmount, bucketOneCapacity - bucketOneAmount);
            }

            if (startBucket == Bucket.One)
            {
                bucketOneAmount -= amountToPour;
                bucketTwoAmount += amountToPour;
            }
            else
            {
                bucketTwoAmount -= amountToPour;
                bucketOneAmount += amountToPour;
            }

            moves++;
       
        }
        return new TwoBucketResult
        {
            Moves = moves,
            GoalBucket = (bucketOneAmount == goal) ? Bucket.One : Bucket.Two,
            OtherBucket = (bucketOneAmount == goal) ? bucketTwoAmount : bucketOneAmount
        };
    }
}