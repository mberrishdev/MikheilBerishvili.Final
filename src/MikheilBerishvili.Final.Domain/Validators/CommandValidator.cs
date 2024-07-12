using System;
using System.Linq;
using MikheilBerishvili.Final.Domain.Primitives;
using MikheilBerishvili.Final.Domain.Exceptions;
using FluentValidation.Results;

namespace MikheilBerishvili.Final.Domain.Validators;

public class CommandValidator
{
    public static void Validate(Type type, ICommandBase command)
    {
        var obj = Activator.CreateInstance(type);
        var methodInfo = type.GetMethods().First(x => x.Name.Equals("Validate"));
        var par = new object[1] { command };

        if (methodInfo.Invoke(obj, par) is not ValidationResult result)
            return;

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => new CommandValidationError()
            {
                ErrorMessage = x.ErrorMessage,
                ErrorCode = x.ErrorCode,
                PropertyName = x.PropertyName,
            });

            throw new CommandValidationException(errors);
        }
    }
}