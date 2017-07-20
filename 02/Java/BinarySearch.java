public class BinarySearch 
{
	//TODO а если порядок не обратый? а если повторения? а если крайний элемент == key?
	//TODO запилить реализацию через поиск по монотонной ф-и и плаваюшюю точку
	//TODO плаваюшая точка за O<Log(n)>?
	
    public static void main(String[] args) 
	{
        int key = Integer.parseInt(args[0]);
        int a[] = new int[args.length - 1];
        for (int i = 1; i < args.length; i++) 
		{
            a[i-1] = Integer.parseInt(args[i]);
        }
		
        System.out.println(binsearchRecur(a,key,-1,a.length));
    }

    //pre: a[i+1] <= a[i]
    //post: r = min(i) -- a[i] <= key 
    public static int binsearchIter(int[] a, int key) 
	{
        int l=-1, r=a.length, m=0;
        //inv: a[l] > key & a[r] <= key
        while (l < r - 1) 
		{
            m = l + (r - l) / 2;
            if (a[m] > key) 
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
    public static int binsearchRecur(int[] a, int key, int l, int r) 
	{
        int m = l + (r - l) / 2;
        if(l >= r - 1) 
		{
            return r;
        } else if(a[m] > key) 
		{
            return binsearchRecur(a, key, m, r);
        } else 
		{
            return binsearchRecur(a, key, l, m);
        }
    }
	
}