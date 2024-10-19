using System.Diagnostics.CodeAnalysis;
using Raffle.Domain.Exceptions;

namespace Raffle.Domain.Helpers
{
    public static class ValidatorHelper
    {
        public static void ValidateNullObject<T>([NotNull] this T obj, string message)
            where T : class
        {
            if (obj is null)
            {
                throw new ValidationException(message);
            }
        }
    }
}
