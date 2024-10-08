namespace Solver.DataStructures.Tests;

[TestFixture]
public class LruCacheTests
{
  [Test]
  public void Test1()
  {
    var lruCache = new LruCache<int, int>(2);
    lruCache.Put(1, 1); // cache is {1=1}
    lruCache.Put(2, 2); // cache is {1=1, 2=2}
    lruCache.Get(1).Should().Be(1);    // return 1
    lruCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
    lruCache.TryGet(2, out _).Should().BeFalse();    // returns -1 (not found)
    lruCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
    lruCache.TryGet(1, out _).Should().BeFalse();    // return -1 (not found)
    lruCache.Get(3).Should().Be(3);    // return 3
    lruCache.Get(4).Should().Be(4);    // return 4
  }
}
