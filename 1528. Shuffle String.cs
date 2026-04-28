public class Solution {
    public string RestoreString(string s, int[] indices) {
        char[] original = s.ToCharArray();
        char[] ordered = new char[indices.Length];

        for (int i = 0; i < indices.Length; i++)
        {
            int pos = indices[i];
            ordered[pos] = original[i];
        }

        return new String(ordered);
    }
}
