namespace Solver.DataStructures;

/// <summary>
/// Trie (/ˈtraɪ/, /ˈtriː/), also called "digital tree" or "prefix tree".
/// https://en.wikipedia.org/wiki/Trie
/// </summary>
public class Trie
{
  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[26];
    public bool EndOfWord;
  }

  private readonly TrieNode root;

  public void Add(string word) => Add(root, word);

  public bool Contains(string word)
  {
    var node = root;
    foreach (var c in word)
    {
      node = node.Next[c - 'a'];
      if (node is null)
        return false;
    }
    return node.EndOfWord;
  }

  private static TrieNode Build(IList<string> dictionary)
  {
    var root = new TrieNode();
    foreach (var word in dictionary)
      Add(root, word);
    return root;
  }

  private static void Add(TrieNode root, string value)
  {
    foreach (var c in value)
      root = root.Next[c - 'a'] ??= new TrieNode();
    root.EndOfWord = true;
  }

  public Trie(IList<string> words) => root = Build(words);
}
