public class BinarySearchSpan 
{
    public static void main(String[] args) 
	{
        int x = Integer.parseInt(args[0]);
        int a[] = new int[args.length - 1];
        for (int i = 1; i < args.length; i++) 
		{
            a[i - 1] = Integer.parseInt(args[i]);
        }
        int l = binsearchIterLeft(a,x);
        int r = binsearchRecurRight(a, x, -1, a.length);
        System.out.println(Integer.toString(l) + " " + Integer.toString(r - l + 1));
    }

    //pre: a[i+1] <= a[i]
    //post: r = min(i) -- a[i] <= key 
    public static int binsearchIterLeft(int[] a, int x) {
        int  l = -1, r = a.length, m = 0;
        //inv: a[l] > key & a[r] <= key
        while (l < r - 1) 
		{
            m = l + (r - l) / 2;
            if (a[m] > x) 
			{
                l = m;
            } else 
			{
                r = m;
            }
        }
        return r;
    }

    //pre: a[i+1] <= a[i], l = (-1; a.Length), r = (-1; a.Length)  
    //post: r = min(i) -- a[i] <= key    
    public static int binsearchRecurRight(int[] a, int x, int l, int r) 
	{
        int m = l + (r - l) / 2;
        if (l >= r - 1) 
		{
            return l;
        } else if (a[m] >= x) 
		{
            return binsearchRecurRight(a, x, m, r);
        } else {
            return binsearchRecurRight(a, x, l, m);
        }
    }
}