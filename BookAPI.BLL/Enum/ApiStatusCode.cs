using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleskup.WebApi.Enums
{
    public enum ApiStatusCode
    {
        Success = 100,
        SystemError = 101,
        NoRow = 102,
        NotFound = 103,
        InvalidParameter = 104,
        AlreadyExist = 105,
        AuthorizedUserNotFound = 106,
        UpdateFailure = 107,
        UserNotFound = 108,
        CreateFailure = 109,
        APIConnectionFailure = 110,
        MailSentFailure = 111,
        PasswordMismatch = 112,
        WrongUserPassword = 113,
        DeleteFailure = 114,
        UnSupportedFileFormat = 115,
        FileSizeLimitExceeded = 116

    }
}