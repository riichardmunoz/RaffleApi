﻿using Raffle.Domain.Exceptions;
using Raffle.Raffle.Domain.Exceptions;

namespace Raffle.Domain.Helpers
{
    public static class GuidHelper
    {
        public static bool ValidateRequestGuid(this Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return false;
            }

            if (!Guid.TryParse(guid.ToString(), out _))
            {
                return false;
            }

            return true;
        }

        public static void CheckValidGuid(this Guid guid)
        {
            if (!guid.ValidateRequestGuid())
            {
                throw new ValidationException(MessagesExceptions.GuidNotValid);
            }
        }
    }
}
