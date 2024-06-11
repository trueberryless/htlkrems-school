//https://stackoverrun.com/de/q/2079131
public static int search(int[] arr, int value)
{
    Debug.Assert(arr.Length > 0);
    var left = 0;
    var right = arr.Length - 1;

    while (((right - left) / 2) > 0)
    {
        var middle = left + (right - left) / 2;
        if (arr[middle] < value)
            left = middle + 1;
        else
            right = middle;
    }
    return arr[left] >= value ? left : right;
}