// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;
using System.Text;

Console.WriteLine(Convert("PAYPALISHIRING", 3));


string Convert(string s, int numRows)
{
    if (numRows == 1 || s.Length <= numRows)
    {
        return s;
    }

    var rows = new StringBuilder[numRows];
    for (int i = 0; i < numRows; i++)
    {
        rows[i] = new StringBuilder();
    }

    int currentRow = 0;
    int direction = 1;

    foreach (char c in s)
    {
        rows[currentRow].Append(c);
        currentRow += direction;

        if (currentRow == 0 || currentRow == numRows - 1)
        {
            direction *= -1;
        }
    }

    var result = new StringBuilder(s.Length);
    foreach (var row in rows)
    {
        result.Append(row);
    }

    return result.ToString();
}

string LongestPalindrome(string s)
{
    //LongestPalindrome("babad")
    string max = s[0].ToString();

    int len = s.Length;

    if (len == 1)
        return s;


    for (int i = 0; i < len; i++)
    {

        //check letter for center
        int left = i - 1;
        int right = i + 1;
        int counter = 0;
        while (left >= 0 && right < len && s[right] == s[left])
        {
            counter++;
            left--;
            right++;
        }
        if (counter * 2 + 1 > max.Length)
            max = s.Substring(left + 1, right - (left + 1));


    }

    for (int i = 0; i < len; i++)
    {
        //check middle for center
        int left = i - 1;
        int right = i;
        int counter = 0;
        while (left >= 0 && right < len && s[right] == s[left])
        {
            counter++;
            left--;
            right++;
        }
        if (counter * 2 > max.Length)
            max = s.Substring(left + 1, right - (left + 1));
    }

    return max;
}

double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    //FindMedianSortedArrays([], [1])
    if (nums1.Length > nums2.Length)
        return FindMedianSortedArrays(nums2, nums1);

    int m = 0;
    m = nums1.Length;

    int n = nums2.Length;
    double res = double.NaN;

    int len = m + n;
    if (m == 0)
        return (len % 2 == 0) ? (nums2[n / 2 - 1] + nums2[n / 2]) / 2.0 : (nums2[n / 2]);
    int mMiddle;
    int nMiddle;

    int low = 0;
    int high = m;

    while (true)
    {
        mMiddle = (low + high) / 2;
        nMiddle = (len + 1) / 2 - mMiddle;
        int l1, r1;
        int l2, r2;
        if (mMiddle == 0)
        {
            l1 = int.MinValue;
            r1 = nums1[mMiddle];
        }
        else if (mMiddle == m)
        {
            l1 = nums1[mMiddle - 1];
            r1 = int.MaxValue;
        }
        else
        {
            l1 = nums1[mMiddle - 1];
            r1 = nums1[mMiddle];
        }
        if (nMiddle == 0)
        {
            l2 = int.MinValue;
            r2 = nums2[nMiddle];
        }
        else if (nMiddle == n)
        {
            l2 = nums2[nMiddle - 1];
            r2 = int.MaxValue;
        }
        else
        {
            l2 = nums2[nMiddle - 1];
            r2 = nums2[nMiddle];
        }


        if (l1 <= r2 && l2 <= r1)
        {
            if (len % 2 == 0)
            {
                return (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0;
            }
            else
            {
                return Math.Max(l1, l2);
            }
        }

        if (l1 > r2)
        {
            high = mMiddle - 1;
        }

        else
        {
            low = mMiddle + 1;
        }

    }






    return res;
}

int LengthOfLongestSubstring(string s)
{
    //(LengthOfLongestSubstring("abba")
    int len = s.Length;
    if (len <= 1)
        return len;

    int max = 0;
    int pt1 = 0;
    int pt2 = 0;



    Dictionary<char, int> map = new Dictionary<char, int>();
    while (pt2 < len)
    {
        char c = s[pt2];
        if (map.ContainsKey(c))
        {
            pt1 = Math.Max(map[c] + 1, pt1);
        }
        map[c] = pt2;
        max = Math.Max(max, pt2 - pt1 + 1);
        pt2++;
    }
    return max;
}
ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    //ListNode l1 = new ListNode(9,
    //              new ListNode(9,
    //              new ListNode(9,
    //              new ListNode(9,
    //              new ListNode(9,
    //              new ListNode(9,
    //              new ListNode(9)))))));

    //// Create l2 = [9,9,9,9]
    //ListNode l2 = new ListNode(9,
    //                  new ListNode(9,
    //                  new ListNode(9,
    //                  new ListNode(9))));
    //var x = AddTwoNumbers(l1, l2);
    ListNode finalNode = new ListNode();
    ListNode currentNode = new ListNode();
    finalNode.next = currentNode;



    int carryOver = 0;
    while (l1 != null || l2 != null)
    {
        int val1 = l1 != null ? l1.val : 0;
        int val2 = l2 != null ? l2.val : 0;
        int sum;
        if (val1 + val2 + carryOver > 9)
        {
            sum = val1 + val2 + carryOver - 10;
            carryOver = 1;
        }
        else
        {
            sum = val1 + val2 + carryOver;
            carryOver = 0;
        }

        ListNode newNode = new ListNode(sum);
        currentNode.next = newNode;
        currentNode = newNode;
        l1 = l1?.next;
        l2 = l2?.next;

    }
    if (carryOver > 0)
    {
        ListNode newNode = new ListNode(carryOver);
        currentNode.next = newNode;
        currentNode = newNode;

    }
    return finalNode.next.next;
}
int[] TwoSum(int[] nums, int target)
{
    //Console.WriteLine(TwoSum([3, 2, 4], 6)[0] + " , " + TwoSum([3, 2, 4], 6)[1]);
    int length = nums.Length;

    Dictionary<int, int> dic = new Dictionary<int, int>();

    if (length == 2)
    {
        return [0, 1];
    }
    //make a set of the array, and check if set contains target-value 
    for (int i = 0; i < length; i++)
    {
        if (dic.ContainsKey(target - nums[i]) && dic[target - nums[i]] != i)
        {
            int x = dic[target - nums[i]];
            int y = i;
            return [x, y];
        }
        else
        {
            dic[nums[i]] = i;
        }
    }

    return [0, 0];
}

class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
