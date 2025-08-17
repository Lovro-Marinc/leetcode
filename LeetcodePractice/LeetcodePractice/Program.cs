// See https://aka.ms/new-console-template for more information

Console.WriteLine(LengthOfLongestSubstring("abba"));



int LengthOfLongestSubstring(string s)
{
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
