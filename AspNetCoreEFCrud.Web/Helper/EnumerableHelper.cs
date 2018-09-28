using System.Collections.Generic;

namespace AspNetCoreEFCrud.Web.Helper
{
    public class EnumerableHelper
    {
        public IEnumerable<T> Add<T>(IEnumerable<T> e, T value)
        {
            foreach (var cur in e)
            {
                yield return cur;
            }
            yield return value;
        }
    }
}
