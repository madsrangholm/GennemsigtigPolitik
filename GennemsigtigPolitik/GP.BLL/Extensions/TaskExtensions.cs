using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace GP.BLL.Extensions
{
    public static class TaskExtensions
    {
        [Pure]
        public static bool IsValid<T>(this Task<T> task)
        {
            return task != null && !task.IsFaulted && !task.IsCanceled;
        }
    }
}